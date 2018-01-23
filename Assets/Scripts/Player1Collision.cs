using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Collision : MonoBehaviour {


	// Use this for initialization
	void OnCollisionEnter (Collision collisionInfo) 
	{
		if (collisionInfo.collider.tag == "Asteroids") 
		{
			Debug.Log ("Player1 hit an Asteroid!");
		}
		if (collisionInfo.collider.tag == "Barrier") 
		{
			Debug.Log ("Player1 hit the Barrier!");
		}
	}
}
