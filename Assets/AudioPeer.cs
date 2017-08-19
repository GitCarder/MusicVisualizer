using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {

    private AudioSource audioSource;
    private float[] samples;
    public int sampleCount = 512;    
	
	void Start () {
        samples = new float[sampleCount];
        audioSource = GetComponent<AudioSource>();        
	}
		
    public float[] GetSpectrum()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        return samples;
    }            
}
