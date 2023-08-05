using UnityEngine;
using System.Collections;

public class stopShip : MonoBehaviour {
	public GameObject boatForce;
	public OurControl player;
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "Boat") {
			Destroy(boatForce);
			player.setOnShip(false);
		}
	}
}
