using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;

public class ControlSelector : MonoBehaviour {


    private LineRenderer line;
    public GameObject rayHit;

    public bool areYouLookingAtMe;


    public GameObject dot;


    WVR_DeviceType device = WVR_DeviceType.WVR_DeviceType_Controller_Right;
    WVR_InputId trigger = WVR_InputId.WVR_InputId_Alias1_Digital_Trigger;
    WVR_InputId touchPad = WVR_InputId.WVR_InputId_Alias1_Touchpad;
    WVR_InputId menu = WVR_InputId.WVR_InputId_Alias1_Menu;

    // Use this for initialization
    void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Pointer();
	}

    void Pointer() {
        line.enabled = true;
        line.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            line.SetPosition(1, new Vector3(hit.point.x, hit.point.y, hit.point.z - .08f));
            ShowReticle(hit.point);
            rayHit = hit.transform.gameObject;
        }
        else {
            line.SetPosition(1, transform.position + transform.forward * 1f);
            dot.transform.position = transform.position + (transform.forward * 1.3f);
            dot.transform.localScale = new Vector3(.2f, .2f, .2f);
            rayHit = null;
        }

    }

    void ShowReticle(Vector3 hitPoint) {
        dot.transform.position = new Vector3(hitPoint.x, hitPoint.y, hitPoint.z -.07f); 
        dot.transform.localScale = new Vector3(.5f, .5f, .5f);
    }

}
