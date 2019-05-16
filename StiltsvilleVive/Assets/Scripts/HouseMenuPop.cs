using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMenuPop : MonoBehaviour {



    HouseSelection houseSelect;
    private GameObject viveHead;

    public float speed;
    public float time;


    Vector3 firstScale;
    Vector3 secondScale;
    Vector3 offset;

    private void Awake() {
        
    }

    // Use this for initialization
    void Start () {
        houseSelect = GetComponentInParent<HouseSelection>();
        viveHead = GameObject.FindGameObjectWithTag("MainCamera");
        secondScale = new Vector3(.95f,.95f,.95f);
        firstScale = new Vector3(0, 0, 0);
        offset = transform.position + new Vector3(0, 1.1f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public IEnumerator PopOut() {
        transform.LookAt(viveHead.transform);
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            transform.LookAt(viveHead.transform);
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(firstScale, secondScale, i);
            transform.position = Vector3.Lerp(transform.position, offset, i);
            yield return null;
        }
        houseSelect.menuOn = true;

    }

    public IEnumerator HideMenu() {
        transform.LookAt(viveHead.transform);
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            transform.LookAt(viveHead.transform);
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(secondScale, firstScale, (i * 3));
            transform.position = Vector3.Lerp(transform.position, transform.parent.transform.position, i);
            yield return null;
        }
        houseSelect.menuOn = false;
    }


}
