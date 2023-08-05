using UnityEngine;
using System.Collections;

public class LoadChaptersUnlocker : MonoBehaviour {

	public UIGrid chapters;
	private StatManager stManager;
	private GameObject checkPointObject;
	private string[] loopCheckpoint;
	private int i = 0;

	// Use this for initialization
	void Start () {
		chapters = (UIGrid)FindObjectOfType (typeof(UIGrid));
		stManager = (StatManager)FindObjectOfType (typeof(StatManager));
		loopCheckpoint = new string[5];
		loopCheckpoint [0] = "CheckPoint0";
		loopCheckpoint [1] = "CheckPoint1";
		loopCheckpoint [2] = "CheckPoint2";
		loopCheckpoint [3] = "CheckPoint3";
		loopCheckpoint [4] = "CheckPoint4";

		//first chapter is always unlocked, it locks all the remaining chapters which user has unlocked
		while(loopCheckpoint[i] !=stManager.getCheckPoint()){
			chapters.GetChild(i+1).GetComponent<UISprite>().enabled = true;
			if(i == 4){
				break;
			}
			i++;
		}
	}
}
