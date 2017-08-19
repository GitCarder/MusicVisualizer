using UnityEngine;
using System.Collections;

public class CubeAudioSpectrumData : MonoBehaviour {

	public Transform cube;
	public int numberOfCubes = 10;

	private Transform[] cubes;
	private float jump = 100.0f;
	private float amplify = 5.0f;

	void Start () {
		cubes = new Transform[numberOfCubes];
		cubes [0] = cube;

		for(int i = 1; i < numberOfCubes; i++){
			cubes[i] = (Transform) Instantiate (cube, new Vector3(cubes[i-1].position.x + 1.5f, cubes[i-1].position.y, cubes[i-1].position.z), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[256];
		AudioListener.GetSpectrumData (spectrum, 0, FFTWindow.Rectangular);

		for(int i = 0; i < numberOfCubes; i++){
			//print (amplify * spectrum[i]);
			cubes[i].position = new Vector3 (cubes[i].position.x, amplify * spectrum[i], cubes[i].position.z);
		}
	}
}
