using UnityEngine;
using System.Collections;

public class WaterDepth : MonoBehaviour {

	private GameManager manager;

	private OurControl player;
	// Use this for initialization
	void Start () {
		manager = (GameManager)FindObjectOfType (typeof(GameManager));
		player = (OurControl)FindObjectOfType (typeof(OurControl));
	
	}

	// this function is use to wait after the object is died
	IEnumerator WaitBeforeDestroy(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		//float counter = 0; float target = 10;
		Destroy(gameObject);
		manager.ResumeGame();
		//while(counter < target) { counter += Time.deltaTime; yield return null; }
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name=="pythonMesh")
		{
			player.Death();
			StartCoroutine(WaitBeforeDestroy(3));
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
