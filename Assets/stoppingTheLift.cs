using UnityEngine;
using System.Collections;

public class stoppingTheLift : MonoBehaviour {
	public Liftup lu;
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "lifter") {
						lu.setUpSingal (false);
		}
	}
}
