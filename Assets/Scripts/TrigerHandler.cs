using UnityEngine;
using System.Collections;

public class TrigerHandler : MonoBehaviour {

	public int id = 1;

	private GameObject ballStoper;
	private GameObject tireStoper;
	private GameObject smallTireStoper;
	private GameObject WBS;
	private AchievementPopup UA;
//	private GameObject player;

	private StatManager stManager;

	void Start(){
		stManager = (StatManager)FindObjectOfType(typeof(StatManager));
		ballStoper = GameObject.Find("ballStopper");
		tireStoper = GameObject.Find("TireStopper");
		smallTireStoper = GameObject.Find("SmallTireStopper");
		UA = (AchievementPopup)FindObjectOfType (typeof(AchievementPopup));
//		player = GameObject.Find("pythonMesh");
		WBS = GameObject.Find("WBStopper");
	}

	void OnTriggerEnter(Collider c)
	{
		if((c.gameObject.name=="pythonMesh") && (id == 0))
		{
			DestroyObject(ballStoper);
		}else if((c.gameObject.name=="pythonMesh") && (id == 1)){
			DestroyObject(tireStoper);
		}else if((c.gameObject.name=="pythonMesh") && (id == 2)){
			DestroyObject(smallTireStoper);
		}else if((c.gameObject.name=="pythonMesh") && (id == 3)){
			if(!stManager.checkAchievement(4)){
				stManager.setUnlockedAchievement(4);
				UA.PopAchievement(0);
			}
			Application.LoadLevel(6);
		}else if((c.gameObject.name=="pythonMesh") && (id == 4)){
			DestroyObject(WBS);
		}
	}
	
}