using UnityEngine;
using System.Collections;

public class onCollision : MonoBehaviour {

	public FixedJoint joint;

	void OnCollisionStay(Collision c) {
		if(c.transform.parent != null)
		{
			if(c.transform.parent.name=="GrabableObjects")
			{
				if(Input.GetKeyDown(KeyCode.LeftControl))
				{
					var joint = gameObject.AddComponent<FixedJoint>(); 
					joint.connectedBody = c.rigidbody;
				}
			}
		}
	}
}