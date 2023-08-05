using UnityEngine;
using System.Collections;

public class loader : MonoBehaviour {
	public UISlider bar;
	private AsyncOperation sceneLoadingOperation;
	// Use this for initialization
	void Start () {
		sceneLoadingOperation = Application.LoadLevelAsync("mainScene");
	}
	
	// Update is called once per frame
	void Update () {
		bar.value = sceneLoadingOperation.progress;
	}
}
