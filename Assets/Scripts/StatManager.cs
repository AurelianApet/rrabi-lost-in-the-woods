using UnityEngine;
using System.Collections;

public class StatManager : MonoBehaviour {
	
	public static StatManager smInstance;

	private string[] achievementName = {"RollingBallAchievement","PillarsAndWreckingBall","TireAchievement","SpiderKillerAchievement","TheEnd"};
	
	private string currentCheckPoint;
	private int unlockedAchievement;

	private bool[] achievementsArray;

	public static StatManager instance
	{
		get
		{
			if(smInstance == null)
			{
				smInstance = GameObject.FindObjectOfType<StatManager>();
				DontDestroyOnLoad(smInstance.gameObject);
			}
			return smInstance;
		}
	}

	public void ResetStats()
	{
		currentCheckPoint="CheckPoint0";
		achievementsArray = new bool[5];
		for (int i=0; i<5; i++) {
			achievementsArray[i]=false;
		}
	}
	void Awake(){
		if (smInstance == null) {
			smInstance = this;
			DontDestroyOnLoad (this);
		} else {
			if(this!=smInstance){
				Destroy(this.gameObject);
			}
		}
		ResetStats ();
		//currentCheckPoint = "CheckPoint4";
	
	}

	void Start()
	{
			currentCheckPoint = PlayerPrefs.GetString ("CheckPoint");
			for(int i=0; i<5; i++)
			{
				if(PlayerPrefs.GetInt("Achievement"+i.ToString()) ==0)
					achievementsArray[i] = false;
				else if(PlayerPrefs.GetInt("Achievement"+i.ToString()) ==1)
					achievementsArray[i] = true;
			}
		//	Debug.Log(currentCheckPoint);
	}

	public bool checkAchievement(int id){ 
		return achievementsArray[id];
	}

	public string getAcievementName(int id){
		return achievementName [id];
	}

	public void setUnlockedAchievement(int id){ achievementsArray[id] = true; }

	public void setCheckPoint(string name){	currentCheckPoint = name;	}
	public string getCheckPoint(){	return currentCheckPoint;	}
	
}
