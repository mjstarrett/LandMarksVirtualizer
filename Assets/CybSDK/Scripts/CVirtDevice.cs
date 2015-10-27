/************************************************************************************

Filename    :   CVirtDevice.cs
Content     :   ___SHORT_DISCRIPTION___
Created     :   August 8, 2014
Authors     :   Lukas Pfeifhofer

Copyright   :   Copyright 2014 Cyberith GmbH

Licensed under the ___LICENSE___

************************************************************************************/

using UnityEngine;
using System;

namespace CybSDK
{

    public abstract class CVirtDevice
    {

        public abstract bool Open();
        public abstract bool IsOpen();
        public abstract bool Close();

        public abstract float GetPlayerHeight();
        public abstract void ResetPlayerHeight();
        public abstract Vector3 GetPlayerOrientation();
        public abstract float GetMovementSpeed();
        public abstract Vector3 GetMovementDirection();
        public abstract void ResetPlayerOrientation();

        public abstract bool HasHaptic();
        public abstract void SetHapticBaseplate(int value);

    }

}