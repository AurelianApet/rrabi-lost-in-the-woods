using UnityEngine;
using System.Collections;

public class characterPosition : MonoBehaviour {

	private StatManager stManager;
	private GameObject checkPointObject;
	private GameObject ball, tire, smallTire,stStopper, tStopper;
	void Awake()
	{
		stManager = (StatManager)FindObjectOfType (typeof(StatManager));
		ball = GameObject.Find ("RollingBall");
		tire = GameObject.Find("Tire");
		tStopper = GameObject.Find("TireStopper");
		stStopper = GameObject.Find("SmallTireStopper");
		smallTire = GameObject.Find("SmallTire");
	//	Debug.Log ("Starting Checkpoint : " + stManager.getCheckPoint ());
		if (stManager.getCheckPoint () != null) 
		{
			if(stManager.getCheckPoint()=="CheckPoint1"){
				Destroy(ball);
			}
			if(stManager.getCheckPoint()=="CheckPoint4")
			{
				Destroy (tire);
				Destroy (smallTire);
				Destroy(stStopper);
				Destroy(tStopper);
			}

			checkPointObject = GameObject.Find (stManager.getCheckPoint ());
			gameObject.transform.position = checkPointObject.transform.position;
		}

		//if the game has started it saves the entry in player preference so the resume would work
		PlayerPrefs.SetInt ("started", 1);
		PlayerPrefs.Save ();
		Debug.Log("saved");
	}
}
