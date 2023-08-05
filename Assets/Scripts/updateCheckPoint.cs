using UnityEngine;
using System.Collections;

public class updateCheckPoint : MonoBehaviour {

	private StatManager stManager;
	public BoxCollider spiderStopperCollider;
	private AchievementPopup UA;

	void Start()
	{
		stManager = (StatManager)FindObjectOfType (typeof(StatManager));
		UA = (AchievementPopup)FindObjectOfType (typeof(AchievementPopup));
	}


	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "pythonMesh"){
				stManager.setCheckPoint (gameObject.name);
			if(gameObject.name == "CheckPoint1"){
				if(!stManager.checkAchievement(0)){
					stManager.setUnlockedAchievement(0);
					UA.PopAchievement(0);
				}
			}else if(gameObject.name == "CheckPoint2"){
				if(!stManager.checkAchievement(1)){
					stManager.setUnlockedAchievement(1);
					UA.PopAchievement(1);
				}
			}else if(gameObject.name == "CheckPoint4"){
				spiderStopperCollider.enabled=false;
				if(!stManager.checkAchievement(2)){
					stManager.setUnlockedAchievement(2);
					UA.PopAchievement(2);
				}
			}

		}
	}
}
