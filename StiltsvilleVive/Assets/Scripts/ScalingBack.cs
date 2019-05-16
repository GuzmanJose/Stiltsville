using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingBack : MonoBehaviour {


    private Vector3 minScale;
    private Vector3 maxScale;
    private Vector3 firstPos;
    private Vector3 endPos;

    public float speed;
    public float time;


	// Use this for initialization
	void Start () {
        minScale = transform.localScale;
        firstPos = transform.position;
         
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public IEnumerator Shrink() {
        transform.parent = null;
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(transform.localScale, minScale, i);
            transform.position = Vector3.Lerp(transform.position, firstPos, i);
            yield return null;
        }
        
    }



    //public IEnumerator Shrink() {
    //    float i = 0.0f;
    //    float rate = (1.0f / time) * speed;
    //    while (i < 1.0f) {
    //        i += Time.deltaTime * rate;
    //        transform.localScale = Vector3.Lerp(transform.localScale, minScale, i);
    //        transform.position = Vector3.Lerp(transform.position, firstPos, i);
    //        yield return null;
    //    }
    //    isBig = true;
    //}


}
