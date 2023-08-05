using UnityEngine;
using System.Collections;

public class StartLift : MonoBehaviour {
	
	public Liftup lift;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "lifter")
		{
			lift.setUpSingal (true);
		}
	}
}

