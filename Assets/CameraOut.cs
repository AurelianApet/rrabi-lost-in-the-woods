using UnityEngine;
using System.Collections;

public class CameraOut : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Transform character;

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name=="pythonMesh")
		{
		//	cam1.enabled=false;
			cam2.enabled=true;
			cam1.GetComponent<smoothfollow2DCsharp>().target=cam2.transform;
			Debug.Log("maholing in");
		}
	}

	void OnTriggerExit(Collider c)
	{
		if(c.gameObject.name=="pythonMesh")
		{
			cam2.enabled=false;
			cam1.GetComponent<smoothfollow2DCsharp>().target=character;
			cam1.enabled=true;
			Debug.Log("maholing out");
		}
	}
}
