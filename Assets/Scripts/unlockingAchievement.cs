using UnityEngine;
using System.Collections;

public class unlockingAchievement : MonoBehaviour {
	
	private StatManager stManager;
	public int achievementID;
	public UISprite newAchievement;
	
	// Use this for initialization
	void Start () {
	//	popup = (AchievementPopup)FindObjectOfType (typeof(AchievementPopup));
		stManager = (StatManager)FindObjectOfType (typeof(StatManager));
		if (stManager.checkAchievement (achievementID)) {
			//popup.setAchievementID(achievementID);
			newAchievement.spriteName = stManager.getAcievementName(achievementID);
			//Debug.Log ("============yo");
		}

	}

}
