using UnityEngine;
using System.Collections;

public class CubeSinusWave : MonoBehaviour {

	public Transform cube;
	public int numberOfCubes = 10;
	public float a = 1.0f;
	public float b = 1.0f;
	public float c = 1.0f;
	public float d = 1.0f;

	private Transform[] cubes;
	private int NoC;


	void Start () {
		NoC = numberOfCubes;
		cubes = new Transform[NoC];
		cubes [0] = cube;

		for(int i = 1; i < NoC; i++){
			cubes[i] = (Transform) Instantiate (cube, new Vector3(cubes[i-1].position.x + 1.5f, cubes[i-1].position.y, cubes[i-1].position.z), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (NoC != numberOfCubes)
			resetCubes ();

		for(int i = 0; i < NoC; i++){
			//print (amplify * spectrum[i]);
			cubes[i].position = new Vector3 (cubes[i].position.x, a*Mathf.Sin(b*(c*Time.time + d*i)), cubes[i].position.z);
		}
	}

	private void resetCubes(){
		for(int i = NoC-1; i > 0; i--)
			Destroy (cubes[i].gameObject);


		NoC = numberOfCubes;
		cubes = new Transform[NoC];
		cubes [0] = cube;

		for(int i = 1; i < NoC; i++){
			cubes[i] = (Transform) Instantiate (cube, new Vector3(cubes[i-1].position.x + 1.5f, cubes[i-1].position.y, cubes[i-1].position.z), Quaternion.identity);
		}
	}
}
