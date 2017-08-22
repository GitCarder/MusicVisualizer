using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {

    public bool microphoneOn = false;
    private AudioSource audioSource;
    private float[] samples;
    public int sampleCount = 512;    
	
	void Start () {
        samples = new float[sampleCount];
        audioSource = GetComponent<AudioSource>();

        if (microphoneOn)
        {            
            if (!Microphone.IsRecording(null))
            {
                audioSource.clip = Microphone.Start(null, true, 10, 44100);
                audioSource.loop = true;

                while (!(Microphone.GetPosition(null) > 0));

                audioSource.Play(); // Play the audio source
            }
        }
    }
		
    public float[] GetSpectrum()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        return samples;
    }               
}
