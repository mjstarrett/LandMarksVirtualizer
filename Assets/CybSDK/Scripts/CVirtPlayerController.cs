using UnityEngine;
using System.Collections;
using CybSDK;

[RequireComponent (typeof (CVirtDeviceController))]
public class CVirtPlayerController : MonoBehaviour {
    
    private CVirtDeviceController deviceController;
    private CharacterController characterController;

    public float movementSpeedMultiplier = 1.5f;
     
    // Use this for initialization
    void Start () {
        //Check if this object has a CVirtDeviceController attached
        deviceController = GetComponent<CVirtDeviceController>();
        if(deviceController == null)
            Debug.LogError("CVirtPlayerController gameobject does not have a CVirtDeviceController attached.");

        this.characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
        if(deviceController != null)
        {
            CVirtDevice virtDevice = deviceController.GetDevice();
            if(virtDevice != null)
            {
                // Get Virtualizer raw inputs
                /////////////////////////////
                Vector3 virtOrientation = virtDevice.GetPlayerOrientation();
                /*float virtHeight = virtDevice.GetPlayerHeight();*/
                Vector3 virtDirection = virtDevice.GetMovementDirection();
                float virtSpeed = virtDevice.GetMovementSpeed();

                // Turn
                ///////
                Quaternion rotation = new Quaternion();
                rotation.SetLookRotation(virtOrientation, Vector3.up);
                transform.localRotation = rotation;

                //TODO: Crouch
                /////////

                // Move Character
                /////////////////
                if (virtSpeed != 0.0f)
                {
                    virtSpeed = virtSpeed * movementSpeedMultiplier;

                    if (characterController != null)
                    {
                        this.characterController.SimpleMove(transform.TransformDirection(virtDirection * virtSpeed));
                    }
                }

            }

        }
    }

}
