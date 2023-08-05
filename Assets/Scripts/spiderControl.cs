using UnityEngine;
using System.Collections;

public class spiderControl : MonoBehaviour {

	RaycastHit hit;
	RaycastHit hit2;
	SpiderActions spiderAnim;
	GameObject spiderObj;
	private bool stay;
	private bool isGrounded;
	//private bool turned;
	private bool inRange;
	private AchievementPopup UA;
	private bool dead;
	private bool atWall;
	Vector3 direction=Vector3.zero;
	Vector3 direction2=Vector3.zero;
	private bool walking = true;
	
	private StatManager stManager;

	// Use this for initialization
	void Start () {
		spiderAnim = GetComponent<SpiderActions> ();
		stManager = (StatManager)FindObjectOfType(typeof(StatManager));
		UA = (AchievementPopup)FindObjectOfType (typeof(AchievementPopup));
		spiderObj = GameObject.Find ("spider");
//		turned = false;
		inRange = true;
		dead = false;
		atWall = false;
	}

	public void setRange(bool x)
	{
		inRange = x;
	}

	void OnCollisionExit(Collision c) {
		if (c.gameObject.name == "lastWall")
				atWall = false;
	}

	void OnCollisionEnter(Collision c) {
		/*if(c.gameObject.name=="UnderWater")
		{
			dead=true;
			spiderAnim.die();
			StartCoroutine(WaitBeforeDestroy(2));
		}

		if (c.gameObject.tag == "Terrain") {
			spiderAnim.walk ();
		}*/
		if (c.gameObject.name == "lastWall" ) {
			/*if(!turned)
			{
				transform.eulerAngles=new Vector3(0,270);
				turned=true;
			}*/
			atWall=true;
		}
		if(c.gameObject.name == "lastWall"){
			spiderAnim.stay();
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "Crate2") {
			dead=true;
			spiderAnim.die();
			if(!stManager.checkAchievement(3)){
				stManager.setUnlockedAchievement(3);
				UA.PopAchievement(3);
			}
			StartCoroutine(WaitBeforeDestroy(2));
		}
	}

	IEnumerator WaitBeforeDestroy(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(spiderObj);
		
	}

	// Update is called once per frame
	void FixedUpdate () {

		if(!dead){
		float rotation = transform.rotation.eulerAngles.y;
		if(rotation<100){
			direction = Vector3.right;
			direction2 = Vector3.right;
			}
		else if (rotation>260){
			direction = Vector3.left;
			direction2 = Vector3.left;
		}

			Ray characterRay = new Ray (transform.position + transform.up * 0.7f, direction);
			Ray characterRay2 = new Ray (transform.position + transform.up * 0.7f, direction2);

			if (Physics.Raycast (characterRay2, out hit2, 15f))
			{
				if (Physics.Raycast (characterRay, out hit, 3.8f)) {
					if (hit.collider.name == "pythonMesh")
						spiderAnim.attack ();
				}

				else if(hit2.collider.name=="pythonMesh")
					spiderAnim.walk();

				else if(!atWall)
					spiderAnim.walkBackwards();
			}
		}
	}
}

//to control spider from input
		/*float spiderRotation = transform.rotation.eulerAngles.y;

		if(Input.GetKeyDown(KeyCode.D)  && spiderRotation<300){
			transform.eulerAngles=new Vector3(0,90);
			spiderAnim.walk();
		}

		else if(Input.GetKeyUp(KeyCode.D) ){
			spiderAnim.stay();
			
		}

		else if((Input.GetKeyDown(KeyCode.A)  && spiderRotation<100 )){
			transform.eulerAngles=new Vector3(0,270);
			spiderAnim.walk();
		}

		else if(Input.GetKeyUp(KeyCode.A) ){
			spiderAnim.stay();
			
		}
		if(Input.GetKey(KeyCode.W)){
			spiderAnim.jump();
		}*/