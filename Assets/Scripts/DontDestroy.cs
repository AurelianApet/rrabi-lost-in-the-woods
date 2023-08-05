using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	static DontDestroy instance;

	void Awake(){
				DontDestroyOnLoad (gameObject);
		}
}
