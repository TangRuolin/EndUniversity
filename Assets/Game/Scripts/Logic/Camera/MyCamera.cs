using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {


    GameObject cameraPos;
    GameObject cube;
	// Use this for initialization
	void Start () {
        cameraPos = GameObject.Find("CameraPos");
        cube = GameObject.Find("LookAt");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = cameraPos.transform.position;
        this.transform.LookAt(cube.transform);
	}
}
