using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour {

    public Transform Target;

    private Vector3 firstPos;
    private Vector3 prePos;
    private Vector3 nextPos;
    private Vector3 minScale;
    private Vector3 maxScale;
    private Vector3 minSizeHouse;
    private Vector3 firstPosHouse;
    private Vector3 housePos;
    private Vector3 houseSize;

    public GameObject aHouse;
    public float speed;
    public float time;
    public bool isBig;

    // Use this for initialization
    void Start() {
        //Target = GameObject.FindGameObjectWithTag("MainCamera").transform;
        minSizeHouse = aHouse.transform.localScale;
        firstPosHouse = aHouse.transform.position;
        isBig = true;
        firstPos = this.transform.position;
        minScale = transform.localScale;
        maxScale = new Vector3(21f, 21f, 21f);
        nextPos = Target.position;
        prePos = transform.position;
    }

    // Update is called once per frame
    void Update() {
    }

    public IEnumerator Enlarge() {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(minScale, maxScale, i);
            transform.position = Vector3.Lerp(prePos, new Vector3(nextPos.x, nextPos.y, nextPos.z), i);
            yield return null;
        }
        isBig = false;
    }

    public IEnumerator Shrink() {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(transform.localScale, minScale, i);
            transform.position = Vector3.Lerp(transform.position, firstPos, i);
            aHouse.transform.localScale = Vector3.Lerp(aHouse.transform.localScale, minSizeHouse, i);
            aHouse.transform.position = Vector3.Lerp(aHouse.transform.position, firstPosHouse, i);
            yield return null;
        }
        isBig = true;
    }


}