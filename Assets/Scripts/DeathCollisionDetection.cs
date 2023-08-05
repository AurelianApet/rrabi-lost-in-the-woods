using UnityEngine;
using System.Collections;

public class DeathCollisionDetection : MonoBehaviour {

	private OurControl player;

	void Start(){
		player = (OurControl)FindObjectOfType (typeof(OurControl));
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name=="pythonMesh")
		{
			player.Death();
		}
	}
}
