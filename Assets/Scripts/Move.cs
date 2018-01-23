using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {


	private float thrust;
	private float boost;
	private float pitch;
	private float yaw;
	private float roll;
	private int capacity;
	public int startCapacity = 1000;
	[SerializeField]float YawSensitivity = 1;
	[SerializeField]float RollSensitivity = 1;
	[SerializeField]float PitchSensitivity = 1;
	[SerializeField]float StrafeSensitivity = 1;
	[SerializeField]float ThrustMod;
	[SerializeField]float boostStrength;

	public Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		capacity = startCapacity;
	}

	void FixedUpdate ()
	{
		
		pitch = Input.GetAxis("Vertical");
		roll = Input.GetAxis("Horizontal");
		yaw = Input.GetAxis ("Strafe");
		rb.AddRelativeTorque(pitch * PitchSensitivity, 0, -roll * RollSensitivity);
		rb.AddRelativeForce (yaw * YawSensitivity, 0, 0);

		boost = Input.GetAxis ("Boost");

		if (capacity >= 1000)
		{
			if (boost == 1) 
			{
				rb.AddForce(transform.forward * boostStrength);
				capacity = capacity - 1000;
			}
		}

		thrust = Input.GetAxis ("Thrust");
		rb.AddForce(transform.forward * thrust * ThrustMod);

		if (capacity <= 1000) 
		{
			Debug.Log (capacity);
			capacity = capacity + 2;
		}
	}
}
