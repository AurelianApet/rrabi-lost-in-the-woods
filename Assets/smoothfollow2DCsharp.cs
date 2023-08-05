using UnityEngine;
using System.Collections;

public class smoothfollow2DCsharp : MonoBehaviour {
	
	public Transform target;
	private float smoothTime = 0.3f;
	private Transform thisTransform;
	private Vector3 velocity;

	private float tempX, tempY;

	// Use this for initialization
	void Start () {
		thisTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		tempX= Mathf.SmoothDamp( thisTransform.position.x, 
		                 target.position.x, ref velocity.x, smoothTime);

		tempY= Mathf.SmoothDamp( thisTransform.position.y, 
		                 target.position.y + 3, ref velocity.y, smoothTime);

		thisTransform.position = new Vector3 (tempX, tempY, this.transform.position.z);
	}
}
