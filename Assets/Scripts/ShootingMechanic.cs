using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour {

	public Transform Player;
	public Transform bulletPosition;
	public GameObject Bullet;
	public Transform objectpos;
	private float bulletSpeed = 3000f;
	private float fire;
	private float fireBuffer = 0;
	public float fireRate = 0.3f;
	public GameObject Player1Controller;

	private string fireType;

	// Use this for initialization	
	void Start () 
	{
		Controller controllerscript = Player1Controller.GetComponent<Controller> ();
		Debug.Log ("ShootingMechanic Player 1 Controller Type " + controllerscript.Player1ControllerType);

		if (controllerscript.Player1ControllerType == 0) 
		{
			fireType = "Fire";
		} 
		else if (controllerscript.Player1ControllerType == 1) 
		{
			fireType = "Fire1";
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		fire = Input.GetAxis (fireType);

		if (fireBuffer == 0)
		{

			if (fire == 1) 
			{
				fireBuffer = 1;

				GameObject bulletclone = (GameObject)Instantiate (Bullet, bulletPosition.position, bulletPosition.rotation); //Spawns Bullet Clone

				Rigidbody bulletRigid = bulletclone.GetComponent<Rigidbody> ();

				bulletRigid.AddForce (objectpos.transform.forward * bulletSpeed);

				Destroy (bulletclone, 1f); //Destroys Warning Clone

				Invoke ("FireBuffer",fireRate);
			}
		}
	}

	void FireBuffer ()
	{
		fireBuffer = 0;
	}
}
