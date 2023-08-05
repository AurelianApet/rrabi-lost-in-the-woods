using UnityEngine;
using System.Collections;

public class moveShip : MonoBehaviour {

	private bool moveSignal;
	public GameObject Boat;
	private FixedJoint joint;
	public CapsuleCollider cc;
	public OurControl player;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "pythonMesh") {
			moveSignal = true;
			this.GetComponent<Collider>().enabled = false;
			cc.enabled=true;
			player.setOnShip(true);
		}
	}
	
    void FixedUpdate()
	{
		if(moveSignal)
			Boat.GetComponent<Rigidbody>().AddForce(Vector3.right*250f);
	}

}
