using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {


	private float thrust;
	private float boost;
	private float sideBoost;
	private float pitch;
	private float roll;
	[SerializeField]public static float capacity;
	[SerializeField]public static float speedValue;
	public static float startCapacity = 500f;
	private Vector3 speed;
	private Vector3 speedSide;
	[SerializeField]float RollSensitivity = 1;
	[SerializeField]float PitchSensitivity = 1;
	[SerializeField]float ThrustMod;
	[SerializeField]float boostMod;
	public Text speedText;
	public Text boostText;
	public static Rigidbody rb;
	public Material booster; 
	public GameObject Player1Controller;

	private string verticalType;
	private string horizontalType;
	private string boostType;
	private string thrustType;
	private string sideboostType;


	void Start () 
	{
		Controller controllerscript = Player1Controller.GetComponent<Controller> ();
		Debug.Log ("Move Player 1 Controller Type " + controllerscript.Player1ControllerType);
			
		if (controllerscript.Player1ControllerType == 0) 
		{
			verticalType = "Vertical";
			horizontalType = "Horizontal";
			boostType = "Boost";
			thrustType = "Thrust";
			sideboostType = "Sideboost";

		} 
		else if (controllerscript.Player1ControllerType == 1) 
		{
			verticalType = "Vertical1";
			horizontalType = "Horizontal1";	
			boostType = "Boost1";
			thrustType = "Thrust1";
			sideboostType = "Sideboost1";
		}
			
		rb = GetComponent<Rigidbody>();
		capacity = startCapacity;
		SetUIText ();
	}


	void FixedUpdate ()
	{
		pitch = Input.GetAxis(verticalType);
		roll = Input.GetAxis(horizontalType);
		rb.AddRelativeTorque(pitch * PitchSensitivity, 0, -roll * RollSensitivity);

		boost = Input.GetAxis (boostType);
		thrust = Input.GetAxis (thrustType);
		sideBoost = Input.GetAxis (sideboostType);

		speedSide = transform.right * sideBoost * ThrustMod;
		rb.AddForce (speedSide * 5f);
		speed = transform.forward * thrust * ThrustMod;


		if (capacity <= 1000) 	
		{
			capacity = capacity + 2;
		}

		if (boost > 0 && capacity > 0) 
		{
			speed = transform.forward * boost * boostMod;
			capacity = capacity - (10 * boost);
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


	void SetUIText()
	{
		speedValue = Mathf.Pow(Mathf.Pow(rb.velocity.x,2F) + Mathf.Pow(rb.velocity.y,2F) + Mathf.Pow(rb.velocity.z,2F),.5F);
		speedText.text = "Speed: " + speedValue.ToString();
		boostText.text = "Boost: " + capacity.ToString();
	}


}
