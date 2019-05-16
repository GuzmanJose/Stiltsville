using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedProjector : MonoBehaviour {

    public float fps = 30f;
    public Texture2D[] frames;

    private int frameIndex;
    private Projector projector;



	// Use this for initialization
	void Start () {
        projector = GetComponent<Projector>();
        NextFrame();
        InvokeRepeating("NextFrame", 1/fps, 1/fps);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NextFrame() {
        projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }

}
