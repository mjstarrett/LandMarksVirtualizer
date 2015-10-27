/************************************************************************************

Filename    :   COVRPlayerController.cs
Content     :   ___SHORT_DISCRIPTION___
Created     :   August 8, 2014
Authors     :   Lukas Pfeifhofer

Copyright   :   Copyright 2014 Cyberith GmbH

Licensed under the ___LICENSE___

************************************************************************************/
using UnityEngine;
using System.Collections;
using CybSDK;

[RequireComponent (typeof (CVirtDeviceController))]
public class COVRPlayerController : MonoBehaviour {

    public bool useProfileHeight = true;

    private OVRPose? initialPose;
    private OVRCameraRig cameraController = null;
    private Transform forwardDirection;

    private CVirtDeviceController deviceController;
    private CharacterController characterController;

    public float movementSpeedMultiplier = 1.0f;
     
    // Use this for initialization
    void Start () {
        //Check if this object has a CVirtDeviceController component attached
        deviceController = GetComponent<CVirtDeviceController>();
        if(deviceController == null)
            Debug.LogError("COVRPlayerController gameobject does not have a CVirtDeviceController component attached.");

        //Check if this object has a fowardDirection object child
        forwardDirection = transform.FindChild("ForwardDirection");
        if (forwardDirection == null)
            Debug.LogError("COVRPlayerController gameobject does not have a forwardDirection object attached.");

        //Check if this object has a OVRCameraRig child
        cameraController = gameObject.GetComponentInChildren<OVRCameraRig>();
        if (cameraController == null)
            Debug.LogError("COVRPlayerController gameobject does not have an OVRCameraRig child.");

        //Check if this object hast a CharacterController component attached
        characterController = gameObject.GetComponent<CharacterController>();
        if (characterController == null)
            Debug.LogError("COVRPlayerController gameobject does not have an CharacterController component attached.");
    }

    // Update is called once per frame
    void Update () {

        float playerHeight = 0.0f;

        if(deviceController != null)
        {
            CVirtDevice virtDevice = deviceController.GetDevice();
            if(virtDevice != null)
            {
                // Get Virtualizer raw inputs
                /////////////////////////////
                Vector3 virtOrientation = virtDevice.GetPlayerOrientation();
                float virtHeight = virtDevice.GetPlayerHeight();
                Vector3 virtDirection = virtDevice.GetMovementDirection();
                float virtSpeed = virtDevice.GetMovementSpeed();

                // Turn
                ///////
                Quaternion rotation = new Quaternion();
                rotation.SetLookRotation(virtOrientation, Vector3.up);
                forwardDirection.localRotation = rotation;

                // Hip Height
                /////////
                playerHeight = virtHeight / 100.0f;                

                // Move Character
                /////////////////
                if (virtSpeed != 0.0f)
                {
                    virtSpeed = virtSpeed * movementSpeedMultiplier;

                    if (characterController != null)
                    {
						this.characterController.SimpleMove((forwardDirection.TransformDirection(virtDirection)).normalized * virtSpeed);
                    }
                }

            }

        }

        if (useProfileHeight)
        {
            if (initialPose == null)
            {
                initialPose = new OVRPose()
                {
                    position = cameraController.transform.localPosition,
                    orientation = cameraController.transform.localRotation
                };
            }

            var p = cameraController.transform.localPosition;
            p.y = (OVRManager.profile.eyeHeight - 0.5f * characterController.height) + playerHeight;
            p.z = OVRManager.profile.eyeDepth;
            cameraController.transform.localPosition = p;
        }
        else if (initialPose != null)
        {
            cameraController.transform.localPosition = initialPose.Value.position;
            cameraController.transform.localRotation = initialPose.Value.orientation;
            initialPose = null;
        }

    }

}
