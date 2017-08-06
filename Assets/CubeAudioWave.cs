using UnityEngine;
using System.Collections;

public class CubeAudioWave : MonoBehaviour {

	public Transform cube;
	public int numberOfCubes = 10;
	public float amplitude = 1.0f;
	public float frequency = 1.0f;
	public float speed = 1.0f;
	public float d = 1.0f;

	private Transform[] cubes;
	private float jump = 100.0f;
	private float amplify = 50.0f;
	private bool up = false;
	private float prevCube = 0.0f;
	private bool play = false;
	private bool sineComplete = true;
	private bool cubeNegative = false;
	private bool cubePositive = false;
	private float t = 1.0f;
	private float duration = .5f;
	private float startTime;
	private float startSpeed;

	void Start () {
		cubes = new Transform[numberOfCubes];
		cubes [0] = cube;

		for(int i = 1; i < numberOfCubes; i++){
			cubes[i] = (Transform) Instantiate (cube, new Vector3(cubes[i-1].position.x + 1.5f, cubes[i-1].position.y, cubes[i-1].position.z), Quaternion.identity);
		}
	}

	void Update () {
		float[] spectrum = new float[256];
		AudioListener.GetSpectrumData (spectrum, 0, FFTWindow.Rectangular);

		if (Input.GetKeyDown ("p"))
			play = true;

		if (!play)
			return;

		//if (sineComplete) {
		if(t >= 1.0f){
			startSpeed = speed;
			speed = spectrum [1];
			startTime = Time.time;
			//print (speed);
			sineComplete = false;
		}

		t = (Time.time - startTime) / duration;
		float s = Mathf.Lerp (startSpeed, speed, t);
		print (s);

		for(int i = 0; i < numberOfCubes; i++){				
			cubes[i].position = new Vector3 (cubes[i].position.x, amplitude*Mathf.Sin(frequency*(s*Time.time + d*i)), cubes[i].position.z);
		}

		if (!cubeNegative) {
			if (cubes [0].position.y < 0) {
				cubeNegative = true;
			}
		} else if (!cubePositive) {
			if (cubes [0].position.y > 0) {
				cubePositive = true;
			}
		} else{
			sineComplete = true;
			cubeNegative = false;
			cubePositive = false;
		}
	}
}
