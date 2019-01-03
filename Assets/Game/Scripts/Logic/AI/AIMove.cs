using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour {

    NavMeshAgent agent;
    GameObject target;
	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
       // agent.SetDestination(target.transform.position);
	}
}
