using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform Player;
	public GameObject Play;
	public Vector3 offset; 

	// Use this for initialization
	void Start () 
	{
	}
		
	// Update is called once per frame
	void LateUpdate () {

		transform.position = Player.position + Player.rotation * offset;
		transform.rotation = Play.transform.rotation;
	}
}
// test	