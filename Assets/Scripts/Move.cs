using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class Move : MonoBehaviour {


	private float thrust;
	private float boost;
	private float strafe;
	private float pitch;
	private float roll;
	[SerializeField]public static float boostAmt;
	[SerializeField]public static float speedValue;
	public static float boostStart = 500f;
	private Vector3 speed;
	private Vector3 strafeSpeed;
	[SerializeField]float RollSensitivity = 1;
	[SerializeField]float PitchSensitivity = 1;
	[SerializeField]float ThrustMod = 2;
	[SerializeField]float boostMod = 2;
	public Text speedText;
	public Text boostText;
	public static Rigidbody rb;
	public Material booster; 


	public int playerNum = 0;
	Renderer shipRenderer;


	void Start () 
	{
		shipRenderer = GetComponent<Renderer> ();
		rb = GetComponent<Rigidbody>();
		boostAmt = boostStart;
		SetUIText ();
	}

	void Update()
	{
		
		var inputDevice = (playerNum < InputManager.Devices.Count) ? InputManager.Devices[playerNum] : null;
			if (inputDevice == null) 
			{
				// If no controller exists for this plane, just make it translucent.
				//shipRenderer.enabled = false;
				Debug.Log ("fag");
			} 
			else 
			{
			 
				
				Debug.Log (inputDevice);

				//UpdateShipWithInputDevice(inputDevice);
			
			}
			
	}
	

	void FixedUpdate ()
	{

		pitch = InputManager.ActiveDevice.LeftStickY;
		//pitch = Input.GetAxis(verticalType);
		roll = InputManager.ActiveDevice.LeftStickX;
		//roll = Input.GetAxis(horizontalType);
		rb.AddRelativeTorque(pitch * PitchSensitivity, 0, roll * RollSensitivity);

		//boost = Input.GetAxis (boostType);
		boost = InputManager.ActiveDevice.RightStickButton;
		//thrust = Input.GetAxis (thrustType);
		thrust = InputManager.ActiveDevice.RightTrigger;
		//strafe = Input.GetAxis (sideboostType);
		strafe = InputManager.ActiveDevice.RightStickY;

		strafeSpeed = transform.right * strafe * ThrustMod;

		rb.AddForce (strafeSpeed * 5f);
		speed = transform.forward * thrust * ThrustMod;


		if (boostAmt <= 1000) 	
		{
			boostAmt = boostAmt + 2;
		}

		if (boost > 0 && boostAmt > 0) 
		{
			speed = transform.forward * boost * boostMod;
			boostAmt = boostAmt - (10 * boost);
			booster.SetColor ("_EmissionColor", Color.red);
		} 
		else 
		{	
			booster.SetColor ("_EmissionColor", Color.black);
		}

		rb.AddForce (speed * 5f);
	}
		

	void LateUpdate()
	{
		SetUIText ();
	}

	void UpdateShipWithInputDevice( InputDevice inputDevice )
	{
		// Perform action as per buttons pressed.
		if (inputDevice.Action1)
		{
			//cubeRenderer.material.color = Color.green;
			Debug.Log("A / X");
		}
		else if (inputDevice.Action2)
		{
			//cubeRenderer.material.color = Color.red;
			Debug.Log("B / O");
		}
		else if (inputDevice.Action3)
		{
			//cubeRenderer.material.color = Color.blue;
		}
		else if (inputDevice.Action4)
		{
			//cubeRenderer.material.color = Color.yellow;
		}
		else
		{
			//cubeRenderer.material.color = Color.white;
		}

		transform.Rotate( Vector3.down, 500f * Time.deltaTime * inputDevice.Direction.X, Space.World );
		transform.Rotate( Vector3.right, 500f * Time.deltaTime * inputDevice.Direction.Y, Space.World );
		transform.Rotate( Vector3.down, 500f * Time.deltaTime * inputDevice.RightStickX, Space.World );
		transform.Rotate( Vector3.right, 500f * Time.deltaTime * inputDevice.RightStickY, Space.World );
	}

	void SetUIText()
	{
		speedValue = Mathf.Pow(Mathf.Pow(rb.velocity.x,2F) + Mathf.Pow(rb.velocity.y,2F) + Mathf.Pow(rb.velocity.z,2F),.5F);
		speedText.text = "Speed: " + speedValue.ToString();
		boostText.text = "Boost: " + boostAmt.ToString();
	}


}
