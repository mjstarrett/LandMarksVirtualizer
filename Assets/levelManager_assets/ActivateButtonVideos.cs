using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ActivateButtonVideos : MonoBehaviour {

//	public GameObject startButton;
	public Button Button;

	void Start()
	{
		Button.image.color = Color.white;
	}

	void OnTriggerEnter(Collider other)
	{
		Button.image.color = Color.green;
	}
	void OnTriggerExit(Collider other)
	{
		Button.image.color = Color.white;
	}


void Update()
	{
		if(Input.GetKeyDown	(KeyCode.Space) & Button.image.color == Color.green)
		{
			Application.LoadLevel("videOS_v4");
		}

	}

}