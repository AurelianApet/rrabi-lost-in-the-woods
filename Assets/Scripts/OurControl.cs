using UnityEngine;
using System.Collections;

public class OurControl : MonoBehaviour {

	public JoyStick joystick;  //Joystick object is passed here from inspector
	private FixedJoint joint;  //joint used to grab objects
	Actions playerAnim;        //to call the functions of Action script

	private bool attached;     //if player has grabbed any object
	private bool Dead;         //if the player is dead or alive
	private bool isGrounded;
	private GameManager manager;
	private bool isPushing;
	private bool onShip;
	private bool onLadder;
	
	public Camera cam2;


	private float x=0, y=0;    //position of the joystick, i.e x is positive if
							//the joystick is pressed in forward direction


	void Awake(){
		cam2.enabled = false;
		}

	//Variables initialization in start function which only executes first time when game starts
	void Start(){
		playerAnim = GetComponent<Actions> ();
		attached=false;
		Dead = false;
		manager = (GameManager)FindObjectOfType (typeof(GameManager));
		onShip = false;
	}
	public void setOnShip(bool t)
	{
		onShip = t;
		playerAnim.Stay ();
	}

	// this function is use to wait after the object is died
	IEnumerator WaitBeforeDestroy(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
		manager.ResumeGame();

	}

	IEnumerator WaitFunction(float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}

	public void Death()
	{
		Dead = true;
		playerAnim.Death ();
		StartCoroutine(WaitBeforeDestroy(3));
	}


	//This Function is use to grab Grabable Objects
	public void grabObject(){
		float rotation = transform.rotation.eulerAngles.y;
		Vector3 direction=Vector3.zero;
		if(rotation<100)
			direction = Vector3.right;
		else if (rotation>260)
			direction = Vector3.left;
		
		if (attached == false) {
			RaycastHit hit;
			Ray characterRay = new Ray (transform.position + transform.up * 0.7f, direction);
			//Debug.DrawRay(transform.position+transform.up *0.7f, direction,  Color.white, 3f, false);
			if (Physics.Raycast (characterRay, out hit, 1f)) {
				if (hit.transform.parent.name == "GrabableObjects") {
					joint = gameObject.AddComponent<FixedJoint> (); 
					joint.connectedBody = hit.rigidbody;
					attached = true;
				}
			}
			
		} else if (attached == true) {
			Destroy (joint);
			attached=false;
		}
	}



	// An automatic calling function which check collision between objects "c" contains the collided object
	void OnCollisionEnter(Collision c) {
		if(c.gameObject.name=="spider")
		{
			Death();
		}
		if(c.gameObject.name=="Tire"){
			Death();
		}
		if(c.gameObject.tag == "Terrain"){
			isGrounded = true;
		}
		if(c.gameObject.name == "Torus1"){
			Death();
		}
		if(c.gameObject.name == "SmallTire"){
			Death();
		}
		//if(c.gameObject.name == "ladder"){
		//	onLadder=true;
		//}
	}


	void OnCollisionStay(Collision c)
	{
		if (c.gameObject.tag == "Terrain") {
						isGrounded = true;
				}
	}

	void OnCollisionExit(Collision c)
	{
		if (c.gameObject.tag == "Terrain") {
			isGrounded = false;
		}
	/*	if(c.gameObject.name == "ladder"){
			this.rigidbody.useGravity=false;
			onLadder=false;
		}*/
	}
	
	void FixedUpdate()
	{
		push ();
		if(Input.GetKey(KeyCode.Space ) && !Dead && !onShip){
			jump();
		}
	/*	if((Input.GetKeyDown(KeyCode.UpArrow ) || y>0 ) && !Dead && !onShip && onLadder){
			playerAnim.Climb(1);
		}

		if((Input.GetKeyDown(KeyCode.DownArrow ) || y<0) && !Dead && !onShip && onLadder){
			playerAnim.Climb(-1);
		}*/

		if (Input.GetKeyUp (KeyCode.LeftControl) && !onLadder && !Dead) {
			grabObject();	
		}
	}

	// Update is called once per frame
	void Update () {
		if (!Dead && !onShip && !onLadder) {
			Movement ();
		}
		if (manager.getAxisInput()) {
			x = joystick.position.x;
			y= joystick.position.y;
		}
	}

	// Chracter Movement handled here
	void Movement(){


		float characterRotation = transform.rotation.eulerAngles.y;

		if((Input.GetKeyDown(KeyCode.RightArrow) || x>0 ) && characterRotation<100 ){
			if(isPushing)
				playerAnim.Push();
			else
				playerAnim.Run();
		}
		else if((Input.GetKeyDown(KeyCode.RightArrow) || x>0 ) && characterRotation<300 && !attached){
			transform.eulerAngles=new Vector3(0,90);

			if(isPushing)
				playerAnim.Push();
			else
				playerAnim.Run();
		}
		else if((Input.GetKeyDown(KeyCode.RightArrow) || x>0) && characterRotation<300 && attached){
			playerAnim.walkBackwards();
		}
		else if(Input.GetKeyUp(KeyCode.RightArrow) || (x==0 && manager.getAxisInput())){
			playerAnim.Stay();

		}

		else if((Input.GetKeyDown(KeyCode.LeftArrow) || x<0) && characterRotation>260 ){
			if(isPushing)
				playerAnim.Push();
			else
				playerAnim.Run();
		}
		else if((Input.GetKeyDown(KeyCode.LeftArrow) || x<0) && characterRotation<100 && !attached){
			transform.eulerAngles=new Vector3(0,270);
			if(isPushing)
				playerAnim.Push();
			else
				playerAnim.Run();
		}
		else if((Input.GetKeyDown(KeyCode.LeftArrow) || x<0) && characterRotation<100 && attached){
			playerAnim.walkBackwards();
		}
		else if(Input.GetKeyUp(KeyCode.LeftArrow) || (x==0 && manager.getAxisInput() )){
			playerAnim.Stay();
		}

	}


	void push()
	{
		float rotation = transform.rotation.eulerAngles.y;
		Vector3 direction=Vector3.zero;
		if(rotation<100)
			direction = Vector3.right;
		else if (rotation>260)
			direction = Vector3.left;
		RaycastHit hit;
		Ray characterRay = new Ray (transform.position + transform.up * 0.7f, direction);
		//Debug.DrawRay(transform.position+transform.up *0.7f, direction,  Color.white, 3f, false);
		if (Physics.Raycast (characterRay, out hit, 1f)) {
				if (hit.transform.gameObject.tag == "Grabable") {
					isPushing = true;
				} else {
					isPushing = false;
				}
			}
			else {
				isPushing = false;
			}
		}

	public void jump(){
		if(isGrounded == true){
			Vector3 dir = new Vector3(0,5f,0);
			this.GetComponent<Rigidbody>().velocity=transform.TransformDirection(dir);
		}
	}
	
}



	/*void RayOnJump()
	{
		float rotation = transform.rotation.eulerAngles.y;
		Vector3 direction=Vector3.zero;
		if(rotation<100)
			direction = Vector3.right;
		else if (rotation>260)
			direction = Vector3.left;
		
		if (ropeAttach == false) {
			RaycastHit hit;
			Ray characterRay = new Ray (transform.position + transform.up * 2f, direction);
			Debug.DrawRay(transform.position+transform.up *2f, direction,  Color.white, 3f, false);
			if (Physics.Raycast (characterRay, out hit, 1f)) {
				if (hit.transform.name == "rope") {
					joint = gameObject.AddComponent<FixedJoint> (); 
					joint.connectedBody = hit.rigidbody;
					ropeAttach = true;
				}
			}
		}
		if(ropeAttach &&  (Input.GetKeyDown(KeyCode.DownArrow) || (y<0 && manager.getAxisInput() ) ) )
		{
			Debug.Log("in here");
			Destroy(joint);
			StartCoroutine(WaitFunction(1));
		}
	}*/



