/************************************************************************************

Filename    :   COVRPlayerControllerCoupled.cs
Content     :   ___SHORT_DISCRIPTION___
Created     :   August 8, 2014
Authors     :   Lukas Pfeifhofer

Copyright   :   Copyright 2014 Cyberith GmbH

Licensed under the ___LICENSE___

************************************************************************************/

using UnityEngine;
using System.Collections;
using CybSDK;

public class COVRPlayerControllerCoupled : CVirtPlayerControllerCoupled {

    OVRGamepadController ovrGamepadController;
    OVRPlayerController ovrPlayerController;

    public override void activate()
    {
        ovrGamepadController = GetComponent<OVRGamepadController>();
        ovrPlayerController = GetComponent<OVRPlayerController>();

        if (ovrPlayerController == null)
        {
            CLogger.LogError("Fallback to COVRPlayerControllerCoupled failed. Missing OVRGamepadController component.");
            return;
        }
        else
        {
            //Enable OVRPlayerController to support keyboard movement
            ovrPlayerController.enabled = true;
        }

        if (ovrGamepadController == null)
        {
            CLogger.LogWarning("COVRPlayerControllerCoupled is missing OVRGamepadController component.");
        }
        else
        {
            //Enable OVRGamepadController to support gamepad movement
            ovrGamepadController.enabled = true;
        }
    }

    // Use this for initialization
    void Start () {

    }


    // Update is called once per frame
    void Update () {
	
    }

}
