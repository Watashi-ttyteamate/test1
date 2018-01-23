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
	[SerializeField]public static float capacity;
	[SerializeField]public static float speedValue;
	public static float startCapacity = 1000f;
	private Vector3 speed;
	[SerializeField]float YawSensitivity = 1;
	[SerializeField]float RollSensitivity = 1;
	[SerializeField]float PitchSensitivity = 1;
	[SerializeField]float StrafeSensitivity = 1;
	[SerializeField]float ThrustMod;
	[SerializeField]float boostMod;
	public Text speedText;
	public Text boostText;
	public static Rigidbody rb;


	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		capacity = startCapacity;
		SetUIText ();
	}

	void FixedUpdate ()
	{
		
		pitch = Input.GetAxis("Vertical");
		roll = Input.GetAxis("Horizontal");
		yaw = Input.GetAxis ("Strafe");
		rb.AddRelativeTorque(pitch * PitchSensitivity, 0, -roll * RollSensitivity);
		rb.AddRelativeForce (yaw * YawSensitivity, 0, 0);

		boost = Input.GetAxis ("Boost");


		thrust = Input.GetAxis ("Thrust");
		speed = transform.forward * thrust * ThrustMod;
		rb.velocity = speed;

		if (Input.GetAxis ("Boost") > 0 && capacity > 0) 
		{
			speed = speed * boostMod * Input.GetAxis("Boost");
			capacity = capacity - (5 * Input.GetAxis ("Boost"));
		}

		if (capacity <= 1000) 
		{
			Debug.Log (capacity);
			Debug.Log (rb.velocity);
			capacity = capacity + 2;
		}

	}

	void LateUpdate()
	{
		SetUIText ();
	}

	void SetUIText()
	{
		speedValue = Mathf.Pow(Mathf.Pow(rb.velocity.x,2F) + Mathf.Pow(rb.velocity.y,2F) + Mathf.Pow(rb.velocity.z,2F),.5F);
		speedText.text = "Speed: " + speedValue.ToString();
		boostText.text = "Boost: " + capacity.ToString();
	}


}
