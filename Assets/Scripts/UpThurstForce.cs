using UnityEngine;
using System.Collections;

public class UpThurstForce : MonoBehaviour {

	public float UpwardForce = 50f; // 9.81 is the opposite of the default gravity, which is 9.81. If we want the boat not to behave like a submarine the upward force has to be higher than the gravity in order to push the boat to the surface
	private bool isInWater = false;
	private Rigidbody obj;
	
	void OnTriggerEnter(Collider c) {
		if (c.gameObject.name == "Boat") {
						isInWater = true;
						c.GetComponent<Rigidbody>().drag = 5f;
						obj = c.GetComponent<Rigidbody>();
				}
	}
	
	void OnTriggerExit(Collider c) {
		if (c.gameObject.name == "Boat") {
						isInWater = false;
						c.GetComponent<Rigidbody>().drag = 0.05f;
				}
	}

	void FixedUpdate(){
		if (isInWater) {
				obj.AddForce (Vector3.up * UpwardForce);
		}
	}
}
	
	/*void FixedUpdate() {
		if(isInWater) {
			// apply upward force
			Vector3 force = transform.up * UpwardForce;
			this.rigidbody.AddRelativeForce(force, ForceMode.Acceleration);
			this.rigidbody.AddForce(-Vector3.forward * 5, ForceMode.Acceleration);
			Debug.Log("Upward force: " + force+" @"+Time.time);
		}
	}*/
