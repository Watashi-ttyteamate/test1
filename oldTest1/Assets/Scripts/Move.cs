using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;
//using InputManager;

public class Move : MonoBehaviour {


	private float thrust;
	private float boost;
	private float strafe;
	private float pitchSens = 120f;
	private float rollSens = 120f;
	private float yawSens = 120f;
	[SerializeField]public static float boostAmt;
	[SerializeField]public static float speedValue;
	public static float boostStart = 500f;
	private Vector3 speed;
	private Vector3 strafeSpeed;
	[SerializeField]float ThrustMod = 2;
	[SerializeField]float boostMod = 2;
	public Text speedText;
	public Text boostText;
	public static Rigidbody rb;
	public Material booster; 


	public int playerNum = 2;
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
          
        
        var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
        if (inputDevice == null)
        {
        	// If no controller exists for this cube, just make it translucent.
        	//cubeRenderer.material.color = new Color( 1.0f, 1.0f, 1.0f, 0.2f );
        	//shipRenderer.enable(false);
          Debug.Log(InputManager.Devices[playerNum]);
          Debug.Log("Player 1 is : " + InputManager.Devices[playerNum].ToString());
        }
        else
        {
        	UpdateShipWithInputDevice( inputDevice );
            Debug.Log("ELSE : MOVE.UPDATE()" + "  ::  " + InputManager.Devices[playerNum]);
        }
        
        

    }
	    
        
    void FixedUpdate ()
    {
  
  
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
	    	//Debug.Log("A / X");
	    }
	    else if (inputDevice.Action2)
	    {
            
	    	//Debug.Log("B / O");
	    }
	    else if (inputDevice.Action3)
	    {
	    	
	    	//Debug.Log("X / Triangle");
	    }
	    else if (inputDevice.Action4)
	    {
	    	//Debug.Log("Y / Square");
	    }
	    else if (inputDevice.LeftStick.Left)
	    {
            return;
        
	    }
	    else if (inputDevice.LeftStick.Right.WasPressed)
	    {
	    	//Debug.Log ("LeftStickRight");
        
	    }
	    else if (inputDevice.LeftStick.Up.WasPressed)
	    {
	    	//Debug.Log ("LeftStick.Up");
        
	    }
	    else if (inputDevice.LeftStick.Down.WasPressed)
	    {
	    	//Debug.Log ("LeftStick.Down");
        
	    }
	    else if (inputDevice.RightStick.Left.WasPressed)
	    {
	    	//Debug.Log ("RightStickLeft");
            
	    }
	    else if (inputDevice.RightStick.Right.WasPressed)
	    {
	    	//Debug.Log ("RightStickRight");
        
	    }
        
	    else if (inputDevice.RightStick.Down.WasPressed)
	    {
	    	//Debug.Log ("RightStickDown");
        
	    }
	    else if (inputDevice.RightStick.Up.WasPressed)
	    {
	    	//Debug.Log ("RightStickUp");
        
	    }
        
	    else if (inputDevice.RightTrigger)
	    {
	         //player.addRelativeForce (ThrustMod * inputDevice.RightTrigger);
        
	    }
	    else if (inputDevice.LeftTrigger.WasPressed)
	    {
	    	//Debug.Log ("LeftTriggerDown");
	    }
        
	    else
	    {
	    	//if no buttons are being pressed.
	    }
        
        //rb.rotation(
        //Vector3.right, pitchSens * Time.deltaTime * inputDevice.LeftStick.Up, Space.World );
//        rb.rotation( Vector3.down, yawSens * Time.deltaTime * inputDevice.RightStick.Left, Space.World );
//        rb.rotation( Vector3.left, pitchSens * Time.deltaTime * inputDevice.LeftStick.Down, Space.World );
//        rb.rotation( Vector3.up, yawSens * Time.deltaTime * inputDevice.RightStick.Right, Space.World );
//        rb.rotation( Vector3.forward, rollSens * Time.deltaTime * inputDevice.LeftStick.Left, Space.World );
//        rb.rotation( Vector3.back, rollSens * Time.deltaTime * inputDevice.LeftStick.Right, Space.World );

	
	
	
//		pitch = InputManager.ActiveDevice.LeftStickY;
		//pitch = Input.GetAxis(verticalType);
//		roll = InputManager.ActiveDevice.LeftStickX;
		//roll = Input.GetAxis(horizontalType);
//		rb.AddRelativeTorque(pitch * PitchSensitivity, 0, roll * RollSensitivity);

		//boost = Input.GetAxis (boostType);
//		boost = InputManager.ActiveDevice.RightStickButton;
		//thrust = Input.GetAxis (thrustType);
//		thrust = InputManager.ActiveDevice.RightTrigger;
		//strafe = Input.GetAxis (sideboostType);
//		strafe = InputManager.ActiveDevice.RightStickY;

//		strafeSpeed = transform.right * strafe * ThrustMod;

//		rb.AddForce (strafeSpeed * 5f);
//		speed = transform.forward * thrust * ThrustMod;
//
//
//		if (boostAmt <= 1000) 	
//		{
//			boostAmt = boostAmt + 2;
//		}
//
//		if (boost > 0 && boostAmt > 0) 
//		{
//			speed = transform.forward * boost * boostMod;
//			boostAmt = boostAmt - (10 * boost);
//			booster.SetColor ("_EmissionColor", Color.red);
//		} 
//		else 
//		{	
//			booster.SetColor ("_EmissionColor", Color.black);
//		}

	
	
	
	}

	void SetUIText()
	{
		speedValue = Mathf.Pow(Mathf.Pow(rb.velocity.x,2F) + Mathf.Pow(rb.velocity.y,2F) + Mathf.Pow(rb.velocity.z,2F),.5F);
		speedText.text = "Speed: " + speedValue.ToString();
		boostText.text = "Boost: " + boostAmt.ToString();
	}
    

}
