using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTargetPosition : MonoBehaviour {


    GameObject[] targets;


	// Use this for initialization
	void Start () {
        targets = GameObject.FindGameObjectsWithTag("Target");
	}
	
	// Update is called once per frame
	void Update () {

	}

    public Transform GetClosestTarget() {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in targets) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        return bestTarget;
    }


}
