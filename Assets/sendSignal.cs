using UnityEngine;
using System.Collections;

public class sendSignal : MonoBehaviour {

	private spiderControl spider;

	void Start()
	{
		spider = (spiderControl)FindObjectOfType (typeof(spiderControl));
	}
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "mesh")
						spider.setRange (false);
				else 
						spider.setRange (true);
	}
	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.name == "mesh")
						spider.setRange (true);
	}
}
