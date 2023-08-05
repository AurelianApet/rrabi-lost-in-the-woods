using UnityEngine;
using System.Collections;

public class relax : MonoBehaviour {

	public SpiderActions spido;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "mesh")
						spido.stay ();
	}
}
