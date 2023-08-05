using UnityEngine;
using System.Collections;

public class Liftup : MonoBehaviour {

	private Vector3 targetPosition;
	public float smoothFactor = 2;
	private bool upSignal;
	private bool trigger;

	void Awake()
	{
		upSignal = true;
	}

	public void setUpSingal(bool x)
	{
		upSignal = x;
	}
	

	void FixedUpdate()
	{
		if (upSignal) {
						targetPosition = transform.position;
						targetPosition.y += 1f;
						transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smoothFactor);
		}
		else if(!upSignal)
		{
			targetPosition = transform.position;
			targetPosition.y -= 1f;
			transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smoothFactor);
			
		}
	}
}