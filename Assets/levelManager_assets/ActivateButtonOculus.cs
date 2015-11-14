using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ActivateButtonOculus: MonoBehaviour {

//	public GameObject startButton;
	public Button Button;

	void Start()
	{
		Button.image.color = Color.white;
	}

	void OnTriggerEnter(Collider OculusActivationBox)
	{
		Button.image.color = Color.green;
	}
	void OnTriggerExit(Collider OculusActivationBox)
	{
		Button.image.color = Color.white;
	}


void Update()
	{
		if(Input.GetKeyDown	(KeyCode.Space) & Button.image.color == Color.green)
		{
			Application.LoadLevel("demo");
		}

	}

}