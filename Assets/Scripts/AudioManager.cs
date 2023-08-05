using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	private AudioSource source;
	private int volume;
	float pitch;
	string SoundPath;
	public static AudioManager amInstance;

	public static AudioManager instance
	{
		get
		{
			if(amInstance == null)
			{
				amInstance = GameObject.FindObjectOfType<AudioManager>();
				DontDestroyOnLoad(amInstance.gameObject);
			}
			return amInstance;
		}
	}
	
	void Awake(){
		if (amInstance == null) {
						amInstance = this;
						DontDestroyOnLoad (this);
				} else {
			if(this!=amInstance){
				Destroy(this.gameObject);
			}
		}
		source = GetComponent<AudioSource>();
	}

	void play(AudioClip x){
		source.clip = x;
		source.Play ();
		}
}
