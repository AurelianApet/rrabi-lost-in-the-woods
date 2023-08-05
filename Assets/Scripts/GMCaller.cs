using UnityEngine;
using System.Collections;

public class GMCaller : MonoBehaviour {

	private GameManager gmManager;  //empty object for gameManager
	// Use this for initialization

	void Start () {  //finding the single instance and assigning it
		gmManager = (GameManager)FindObjectOfType (typeof(GameManager));  
	}
	public void resumeGame()
	{
		if(PlayerPrefs.HasKey("started")) //makes sure the game doesn't resume if the user plays game for the first time
										//if the entity with the name started has saved in hte player prefernce
			gmManager.ResumeGame ();	
	}
	public void startGame()
	{
		gmManager.StartGame ();
	}


	//passes these strings to game manager and game manager does the rest
	public void loadChapter1()
	{
		gmManager.LoadChapter ("CheckPoint0");
	}

	public void loadChapter2()
	{
		gmManager.LoadChapter ("CheckPoint1");
	}

	public void loadChapter3()
	{
		gmManager.LoadChapter ("CheckPoint2");
	}

	public void loadChapter4()
	{
		gmManager.LoadChapter ("CheckPoint3");
	}

	public void loadChapter5()
	{
		gmManager.LoadChapter ("CheckPoint4");
	}

	//chapter selecetion menu
	public void loadChapterScreen()
	{
		gmManager.LoadChapterScreen ();
	}

	public void achievements()
	{
		gmManager.Achievements ();
	}
	public void help()
	{
		gmManager.help ();
	}
	public void quit()
	{
		gmManager.quit ();
	}
}
