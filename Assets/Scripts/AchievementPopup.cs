using UnityEngine;
using System.Collections;

public class AchievementPopup : MonoBehaviour {
	
	public UISprite popup;

	private StatManager stManager;
	//private int achievementID;
	private bool check = false;


	void Start(){
		stManager = (StatManager)FindObjectOfType (typeof(StatManager));
		popup.enabled = false;
	}

	public void PopAchievement(int id){
		popup.spriteName = stManager.getAcievementName(id);
		popup.enabled = true;
		StartCoroutine (WaitFunction(4));
	}

	IEnumerator WaitFunction(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		popup.enabled = false;
	}

/*	public void setAchievementID(int id){
		achievementID = id;
	}
	public void setAchievementBool(bool c){
		check = c;
	}*/
}
