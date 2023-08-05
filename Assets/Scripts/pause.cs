using UnityEngine;
using System.Collections;
using UnitySampleAssets.Utility;

public class pause : MonoBehaviour {

	bool escape = false;
	public GameObject pauseMenu;
	public GameObject CamRig;

	// Use this for initialization
	void Start () {
		pauseMenu.SetActive(false);
		CamRig.SetActive(true);
		Cursor.visible = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKey(KeyCode.Y)){
			Application.LoadLevel(4);
		}*/

		if(Input.GetKeyDown(KeyCode.Escape)){
			if(escape == false){
				escape = true;
				pauseMenu.SetActive(true);
				Time.timeScale = 0;
				CamRig.SetActive(false);
			}
			else{
				escape = false;
				pauseMenu.SetActive(false);
				Time.timeScale = 1;
				CamRig.SetActive(true);
			}

		}
	
	}
}
