using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingManager : MonoBehaviour {

    public ParticleSystem bigWave;
    public ParticleSystem smallWave;

    private GameObject [] waveTargets;


	// Use this for initialization
	void Start () {
        waveTargets = GameObject.FindGameObjectsWithTag("TargetParticle");
        SmallWavesOn();
	}
	
	// Update is called once per frame
	void Update () {
		//Add Listener to scale and Shrink
	}

    public void BigWavesOn() {
        foreach (var target in waveTargets) {
            if (target.transform.childCount > 0) {
                Destroy(target.transform.GetChild(0).gameObject);
            }
                Instantiate(bigWave, target.transform);
                Debug.Log("BigWaves On");
        }
        
    }

    public void SmallWavesOn() {
        foreach (var target in waveTargets) {
            if (target.transform.childCount > 0) {
                Destroy(target.transform.GetChild(0).gameObject);
            }
            Instantiate(smallWave, target.transform);
        }
        Debug.Log("SmallWaves On");
    }

}
