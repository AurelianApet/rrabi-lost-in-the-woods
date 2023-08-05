using UnityEngine;
using System.Collections;

public class ChracterBallDeath : MonoBehaviour {

	private OurControl player;

	void Start(){
		player = (OurControl)FindObjectOfType (typeof(OurControl));
	}

	void FixedUpdate(){
//		Debug.Log ("Velocity: " + this.rigidbody.velocity.magnitude);
		this.GetComponent<Rigidbody>().AddForce (Vector3.left*3000f);
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name=="pythonMesh")
		{
			if(this.GetComponent<Rigidbody>().velocity.magnitude > 3f){
				player.Death();
			}
		}
	}
}
