using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {


    GameObject _player;
    GameObject _lookAt;
    Vector3 _oldPos;
    Vector3 _offset;
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player");
        _lookAt = GameObject.Find("LookAt");
        _oldPos = _player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        _offset = _player.transform.position - _oldPos;
        _oldPos = _player.transform.position;
        this.transform.position += _offset;
        this.transform.LookAt(_lookAt.transform);
	}
}
