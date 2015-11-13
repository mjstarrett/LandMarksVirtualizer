using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class activate_button : MonoBehaviour {

//	public GameObject startButton;
	public Button Button;

	void Start()
	{
		Button.image.color = Color.white;
	}

	void OnTriggerEnter(Collider other)
	{
		Button.image.color = Color.green;
		if(Input.GetKeyDown	(KeyCode.Space))
		{
			Application.LoadLevel("bigCity_cyberith_v4");
		}

	}
	void OnTriggerExit(Collider other)
	{
		Button.image.color = Color.white;
	}


void Update(){


		;
		if(Input.GetKeyDown	(KeyCode.Space) & Button.image.color == Color.green)
		{
			Application.LoadLevel("bigCity_cyberith_v4");
		}

}

}