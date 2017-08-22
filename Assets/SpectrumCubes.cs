using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumCubes : MonoBehaviour {

    public AudioPeer ap;
    public Transform[] cubes;
    private float[] samples;

    public float decreaseSpeed = 0.05f;
    public float decreaseAcceleration = 1.0f;    
    
    private float[] bands = new float[8];
    private float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];

    void Start () {
        samples = new float[ap.sampleCount];        

        for (int i = 0; i < bandBuffer.Length; i++)
        {
            bandBuffer[i] = 1;
        }
    }
		
	void Update () {
        samples = ap.GetSpectrum();
        CalculateBands();
        ProcessBands();
        ScaleCubes();
    }  

    void CalculateBands()
    {
        int count = 0;
        for (int i = 1; i <= bands.Length; i++)
        {
            int end = (int)Mathf.Pow(2, i);
            float average = 0;
            int beginCount = count;
            for (int j = 0; j < end; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= (count - beginCount);
            bands[i - 1] = average * 10;
        }
    }

    void ProcessBands()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            if (bands[i] > bandBuffer[i])
            {
                bandBuffer[i] = bands[i];
                bufferDecrease[i] = decreaseSpeed;
            }
            else if (bands[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= decreaseAcceleration;

                if (bandBuffer[i] < 1)
                {
                    bandBuffer[i] = 1;
                }
            }
        }
    }

    void ScaleCubes()
    {        
        for (int i = 0; i < cubes.Length; i++)
        {
            Vector3 scale = cubes[i].localScale;
            //cubes[i].localScale = new Vector3(scale.x, bandBuffer[i], scale.z);
            cubes[i].localScale = new Vector3(scale.x, scale.y, bandBuffer[i]);
        }
    }
}
