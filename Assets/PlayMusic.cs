using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {

	public AudioClip clip;
	private AudioSource audio;
	private bool play = false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.clip = clip;
	}
	
	// Update is called once per frame
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
