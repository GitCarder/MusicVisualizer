using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {

	public AudioClip clip;
	private AudioSource audio;
	private bool play = false;
	
	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.clip = clip;
	}
	
	void Update () {
		if (Input.GetKeyDown ("p")) {			
			if (!play) {				
				audio.Play ();
			} else {
				audio.Pause ();
			}
			play = !play;
		}
	}
}
