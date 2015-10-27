/************************************************************************************

Filename    :   CVirtDeviceNative.cs
Content     :   Implentation of the native plugin device
Created     :   August 8, 2014
Authors     :   Lukas Pfeifhofer

Copyright   :   Copyright 2014 Cyberith GmbH

Licensed under the ___LICENSE___

************************************************************************************/

using UnityEngine;
using System;

namespace CybSDK
{

    public class CVirtDeviceNative : CVirtDevice
    {

        private IntPtr devicePtr;

        public CVirtDeviceNative(IntPtr devicePtr)
        {
            this.devicePtr = devicePtr;
        }

        public override bool Open()
        {
            return CVirt.CybSDK_VirtDevice_Open(this.devicePtr);
        }

        public override bool IsOpen()
        {
            return CVirt.CybSDK_VirtDevice_IsOpen(this.devicePtr);
        }

        public override bool Close()
        {
            return CVirt.CybSDK_VirtDevice_Close(this.devicePtr);
        }

        public override float GetPlayerHeight()
        {
            return CVirt.CybSDK_VirtDevice_GetPlayerHeight(this.devicePtr);
        }

        public override void ResetPlayerHeight()
        {
            CVirt.CybSDK_VirtDevice_ResetPlayerHeight(this.devicePtr);
        }

        public override Vector3 GetPlayerOrientation()
        {
            float playerOrient =  CVirt.CybSDK_VirtDevice_GetPlayerOrientation(this.devicePtr);
            return new Vector3(
                Mathf.Cos(playerOrient * 2.0f * Mathf.PI - Mathf.PI / 2.0f),
                0.0f,
                -Mathf.Sin(playerOrient * 2.0f * Mathf.PI - Mathf.PI / 2.0f)
            ).normalized;
        }

        public override float GetMovementSpeed()
        {
            return CVirt.CybSDK_VirtDevice_GetMovementSpeed(this.devicePtr);
        }

        public override Vector3 GetMovementDirection()
        {
            float movDir =  CVirt.CybSDK_VirtDevice_GetMovementDirection(this.devicePtr);
            return new Vector3(
                Mathf.Cos(movDir * Mathf.PI - Mathf.PI / 2.0f),
                0.0f,
                -Mathf.Sin(movDir * Mathf.PI - Mathf.PI / 2.0f)
            ).normalized;
        }

        public override void ResetPlayerOrientation()
        {
            CVirt.CybSDK_VirtDevice_ResetPlayerOrientation(this.devicePtr);
        }

        public override bool HasHaptic()
        {
            return CVirt.CybSDK_VirtDevice_HasHaptic(this.devicePtr);
        }

        public override void SetHapticBaseplate(int value)
        {
            CVirt.CybSDK_VirtDevice_SetHapticBaseplate(this.devicePtr, (short)value);
        }

        public bool IsPtrNull()
        {
            return (devicePtr.ToInt32() == 0);
        }

    }

}