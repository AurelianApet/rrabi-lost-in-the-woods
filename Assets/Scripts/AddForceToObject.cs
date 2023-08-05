using UnityEngine;
using System.Collections;

public class AddForceToObject : MonoBehaviour {

	public float force = 0f;
	public bool check = false;
	public string direction = null;

	void FixedUpdate(){
		TireRotateForce (check,force,direction);
	}

	void TireRotateForce (bool chk, float frc, string dir){
		if(check && (direction != null)){
			if(direction.ToLower() == "left"){
				this.GetComponent<Rigidbody>().AddForce (Vector3.left * force);
			}else if(direction.ToLower() == "right"){
				this.GetComponent<Rigidbody>().AddForce (Vector3.right * force);
			}else if(direction.ToLower() == "up"){
				this.GetComponent<Rigidbody>().AddForce (Vector3.up * force);
			}else if(direction.ToLower() == "down"){
				this.GetComponent<Rigidbody>().AddForce (Vector3.down * force);
			}
		}
	}
}
