/************************************************************************************

Filename    :   COVRMainMenu.cs
Content     :   ___SHORT_DISCRIPTION___
Created     :   August 8, 2014
Authors     :   Lukas Pfeifhofer

Copyright   :   Copyright 2014 Cyberith GmbH

Licensed under the ___LICENSE___

************************************************************************************/
using UnityEngine;
using System.Collections;
using CybSDK;

public class COVRMainMenu : MonoBehaviour {

	// Handle to CVirtDeviceController
	private CVirtDeviceController deviceController;

	private bool enableInfo = true;	

	// Handle to OVRMainMenu
	private OVRMainMenu ovrMainMenu;

	// Handle to OVRCameraRig
	private OVRCameraRig CameraController = null;

	void Awake()
	{
		// Find camera controller
		OVRCameraRig[] CameraControllers;
		CameraControllers = gameObject.GetComponentsInChildren<OVRCameraRig>();
		
		if (CameraControllers.Length == 0)
			Debug.LogWarning("OVRMainMenu: No OVRCameraRig attached.");
		else if (CameraControllers.Length > 1)
			Debug.LogWarning("OVRMainMenu: More then 1 OVRCameraRig attached.");
		else
		{
			CameraController = CameraControllers[0];
		}
		
		//Check if this object has a CVirtDeviceController attached
		deviceController = GetComponent<CVirtDeviceController>();
		if (deviceController == null)
			Debug.LogError("CVirtPlayerController gameobject does not have a CVirtDeviceController attached.");
	}

	// Use this for initialization
	void Start () {
		
		ovrMainMenu = GetComponent<OVRMainMenu> ();
		
		if (ovrMainMenu == null) {
			CLogger.LogWarning ("COVRMainMenu could not find an instance of OVRMainMenu.");
		}
	}

	// Update is called once per frame
	void Update () {
		//If device controller is not present switch to OVRMainMenu automatically
		if (deviceController != null && deviceController.GetDevice() != null)
		{
			// R will reset the orientation based on player input ('R' key)
			UpdateResetOrientation();
		}
		else
		{
			SwitchToOVRMainMenu();
		}
	}
	
	void UpdateResetOrientation()
	{
		// Reset the view on 'R'
		if (Input.GetKeyDown(KeyCode.R) == true)
		{
			CLogger.Log("HMD and Virtualizer reset to origin.");
			
			// Reset tracker position.
			//OVRCamera.ResetCameraPositionOrientation(Vector3.one, Vector3.zero, Vector3.up, Vector3.zero);
			OVRManager.display.RecenterPose();
			
			// Reset Virtualizer orientation and player height
			if (deviceController.GetDevice() != null)
			{
				deviceController.GetDevice().ResetPlayerOrientation();
				deviceController.GetDevice().ResetPlayerHeight();
			}
			
			SwitchToOVRMainMenu();
			
		}
	}
	
	private void SwitchToOVRMainMenu()
	{
		//Hide COVRMainMenu and show OVRMainMenu if available
		enableInfo = false;
		
		if (ovrMainMenu != null)
		{
			ovrMainMenu.enabled = true;
		}
	}

}
