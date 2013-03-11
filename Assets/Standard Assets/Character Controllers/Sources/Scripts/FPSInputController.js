
private var GUIDisplay : GameObject;
private var Player : GameObject;
private var motor : CharacterMotor;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
	GUIDisplay = GameObject.Find("GUIDisplay");
	Player = GameObject.FindGameObjectWithTag("Player");
}

// Update is called once per frame
function Update () {
	// Get the input vector from kayboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	
	motor.inputJump = Input.GetButton("Jump");
	motor.inputCrouch = Input.GetButton("Crouch");
	
	//Debug.Log(Player.GetComponent("EnergySystem").ReturnEnergy());
	if (Input.GetButton("Fly") && Player.GetComponent("EnergySystem").ReturnEnergy() > 0.0f){
		motor.inputFly = true;
		Player.SendMessage("DecreaseEnergy", Time.deltaTime);
		motor.inputMoveDirection = transform.rotation * directionVector * 5.0f;
	}
	else{
		motor.inputFly = false;
		motor.inputMoveDirection = transform.rotation * directionVector;
	}
	
	if(Input.GetKeyUp("m"))
		GameObject.Find("MinimapCamera").SendMessage("ChangeMapSize");
		
	if(Input.GetKeyUp("1"))
		GUIDisplay.SendMessage("ChangeWeapon", 1);
		
	if(Input.GetKeyUp("2"))
		GUIDisplay.SendMessage("ChangeWeapon", 2);
		
	if(Input.GetKeyUp("3"))
		GUIDisplay.SendMessage("ChangeWeapon", 3);
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
