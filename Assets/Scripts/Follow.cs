using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform Player;
	public Vector3 offset; 

	private const float YangleMax = 50f;
	private const float YangleMin = -50f;

	// Use this for initialization
	void Start () {

	}
		
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Player.position + Player.rotation * offset;
		transform.LookAt (Player.position);

	}
}
// test	