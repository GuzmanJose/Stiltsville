using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour {

    public Transform Target;

    private Vector3 prePos;
    private Vector3 nextPos;

    public float speed;
    public float time;


	// Use this for initialization
	void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        nextPos = Target.position;
        prePos = transform.position;
        if (Input.GetKey(KeyCode.A)) {
            StartCoroutine(Moving());
        }
    }

    IEnumerator Moving() {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (transform.position != nextPos) {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(prePos, nextPos, i);
            yield return null;
        }
    }

}
