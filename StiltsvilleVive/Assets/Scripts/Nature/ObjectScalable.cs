using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScalable : MonoBehaviour {



    private Vector3 smallSize;
    private Vector3 bigSize;


    public float time;
    public float speed;

    public Controller controller;



	// Use this for initialization
	void Start () {
        smallSize = this.transform.localScale;
        bigSize = new Vector3(0.324f,0.324f,0.324f);
        if (controller == null) {
            //GameObject.Find("Controller (right)").GetComponent<Controller>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        //if (!controller.safe) {
        //    GetBig();
        //}
        //else if (controller.safe) {
        //    GetSmall();
        //} 
		
	}
    // if Controller.safe ENLARGE
    public void GetBig() {
        if (this.transform.localScale.x < bigSize.x) {
            float rate = (1.0f / time) * speed;
            float t = Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(this.transform.localScale, bigSize, t);
        }
    }


    public void GetSmall() {
        if (this.transform.localScale.x > smallSize.x) {
            float rate = (1.0f / time) * speed;
            float t = Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(this.transform.localScale, smallSize, t);
        }
    }


}
