using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private bool axisInput;  //to switch the controls from keyboard to joystick
	private StatManager stManager;

	public static GameManager gmInstance;

	//find and assign already created instance if any
	public static GameManager instance
	{
		get
		{
			if(gmInstance == null)
			{
				gmInstance = GameObject.FindObjectOfType<GameManager>();
				DontDestroyOnLoad(gmInstance.gameObject);
			}
			return gmInstance;
		}
	}
	
	void Awake(){
		//checlk if there is any instance is not created then it will assign the instance that is created
		if (gmInstance == null) {
			gmInstance = this;
			DontDestroyOnLoad (this);
		} else {
			if(this!=gmInstance){
				Destroy(this.gameObject);
			}
		}

		//check the game platform
		if (Application.platform == RuntimePlatform.Android) {  //true if its unity editor, false if its touch input
						axisInput = true;
				} else
						axisInput = false;
	}

	void Start()
	{
		//assigning the statManager object to stManager by finding it
		stManager = (StatManager)FindObjectOfType (typeof(StatManager));
	}

	public bool getAxisInput()
	{
		return axisInput;
		}
	
	public void ResumeGame()
	{
		Application.LoadLevel (1);
	}

	public void StartGame()
	{
		stManager.ResetStats ();
		Application.LoadLevel (1);
	}
	public void LoadChapter(string cp)	
	{
		stManager.setCheckPoint (cp);
		ResumeGame ();
	}
	public void LoadChapterScreen()
	{
		Application.LoadLevel(3);
	}

	public void Achievements()
	{
		Application.LoadLevel (4);
	}

	public void help()
	{
		Application.LoadLevel (5);
	}

	public void quit()
	{

		PlayerPrefs.SetString ("CheckPoint", stManager.getCheckPoint ());

		for(int i=0; i<5; i++)
		{
			if(stManager.checkAchievement(i))  //checks if the achievement[i] is locked or unlocked, proceeds if unlocked
				PlayerPrefs.SetInt("Achievement"+i.ToString(),1);  // entity with the e.g Achievement1  is set to 1
			else if (!stManager.checkAchievement(i))			//if it is locked
				PlayerPrefs.SetInt("Achievement"+i.ToString(), 0); //that Acheivement is set to 0
		}
		PlayerPrefs.Save ();
		Application.Quit ();
	}

	void Update()
	{
		if (Application.loadedLevel == 0 && Input.GetKeyDown (KeyCode.Escape))
		{
			quit();		
		} else if(Application.loadedLevel != 0 && Input.GetKeyDown (KeyCode.Escape)){
			Application.LoadLevel (0);
		}

	}

}
