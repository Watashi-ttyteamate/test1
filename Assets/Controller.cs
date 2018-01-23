using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


	private int x;
	public float Player1ControllerType;

	void Start() //Determintes What type of controller Player1 is
	{
		string[] names = Input.GetJoystickNames();

		if(names[1].Length == 33)
		{
			Debug.Log ("Player 1 is XBOX");
			x = 1;
		}
		else if(names[1].Length == 19)
		{
			Debug.Log("Player 1 is PS4");
			x = 0;
		}

		Player1ControllerType = x;
	}
}
