﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class videos_startup_gui : VRGUI 
{
	private string subID 	= "";
	private string errID;
	private string subAge = "";
	public string levelName;
	private Config config;
	private string appDir = "";
	private bool dirCreated = false;
	private bool dirError = false;
	public bool reorient;

	public override void OnVRGUI()
	{
		GUILayout.BeginArea (new Rect (0f,0f,Screen.width/2,Screen.height));
		GUILayout.Label("Please Enter Subject ID:");
		subID = GUILayout.TextField (subID, 25);
		GUILayout.Label("Please Enter Subject Age:"); 
		subAge = GUILayout.TextField (subAge, 25);
		if (GUILayout.Button ("Begin Experiment")) {
			errID = subID;
			StartLevel ();
		}
		if (dirError == true) {
			GUILayout.Label("The ID " + errID + " is already in use. Try again.");
		}

		GUILayout.EndArea();
	}

	void Start () {
		
		config = Config.instance;
		appDir = Directory.GetCurrentDirectory();
		if (  !Directory.Exists(appDir + "/data/" + levelName) ) {
			Directory.CreateDirectory(appDir + "/data/" + levelName);
		}
	}

	public void StartLevel(){	
		readyConfig ();
		if (dirError != true) {
			if (reorient == true) {
				PlayerPrefs.SetString ("levelName", levelName);
				PlayerPrefs.SetString ("subID",subID);
				Application.LoadLevel ("reorient");
			} else {
				Application.LoadLevel (levelName);
			}
		}
	}

	void readyConfig(){
		config.runMode = ConfigRunMode.NEW;
		config.bootstrapped = true;
		config.expPath = appDir + "/data/" + levelName;
		config.subjectPath = appDir + "/data/" + levelName + "/" + subID;
		
		config.appPath = appDir;
		config.level = levelName;
		config.subject = subID;
		
		if (!Directory.Exists (appDir + "/data/" + levelName + "/" + subID)) {
			dirError = false;
			Directory.CreateDirectory (appDir + "/data/" + levelName + "/" + subID);
			dirCreated = true;
		} else {
			dirError = true;
			Start ();
		}
		
	}
}