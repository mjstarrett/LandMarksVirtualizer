using UnityEngine;
using System.Collections;

public class avatarLog : MonoBehaviour {

	[HideInInspector] public bool navLog = false;
	private Transform avatar;
	private Transform camerarig;
	private Transform OVRCameraRig;
	private GameObject experiment;
	private dbLog log;
	private Experiment manager;

	void Start () {

		camerarig =GameObject.Find("OVRCameraRig").transform as Transform;
		experiment = GameObject.FindWithTag ("Experiment");
		manager = experiment.GetComponent("Experiment") as Experiment;
		log = manager.dblog;
		avatar = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (navLog){

			log.log("AVATAR_POS	" + "\t" +  avatar.position.ToString("f3") + "\t" + "AVATAR_HPR	" + "\t" +  avatar.localEulerAngles.ToString("f3"),2);

		}

	}
}
