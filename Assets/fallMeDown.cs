using UnityEngine;
using System.Collections;

public class fallMeDown : MonoBehaviour {

	public BoxCollider bc;
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "pythonMesh") {
			this.GetComponent<Rigidbody>().AddForce (Vector3.right * 15000f);
			bc.enabled=false;
		}
	}
}
