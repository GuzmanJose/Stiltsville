using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;

public class ControlShrink : MonoBehaviour {


    private LineRenderer line;
    private bool isCheck;
    private Transform currentTarget;
    private Scaling scale;
    private Scaling prevScale;


    public ControlTargetPosition controlPos;
    public Transform aHouse;   
    public bool safe;
    public GameObject rayHit;
    public bool areYouLookingAtMe;
    public GameObject dot;
    public GameObject cubeTest;

    public WVR_DeviceType device = WVR_DeviceType.WVR_DeviceType_Controller_Right;
    WVR_InputId trigger = WVR_InputId.WVR_InputId_Alias1_Digital_Trigger;
    WVR_InputId touchPad = WVR_InputId.WVR_InputId_Alias1_Touchpad;
    WVR_InputId menu = WVR_InputId.WVR_InputId_Alias1_Menu;

    // Use this for initialization
    void Start() {
        line = GetComponent<LineRenderer>();
        safe = true;
    }

    // Update is called once per frame
    void Update() {
        Pointer();

        //if (WaveVR_Controller.Input(device).GetPressDown(touchPad) || Input.GetMouseButtonDown(0)) {
        //    cubeTest.GetComponent<Renderer>().material.color = Color.black;
        //    AntMan();
            
        //}
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
            line.SetPosition(1, transform.position + transform.forward * 2.5f);
            dot.transform.position = transform.position + (transform.forward * 3.5f);
            dot.transform.localScale = new Vector3(.2f, .2f, .2f);
            rayHit = null;
        }

    }

    void ShowReticle(Vector3 hitPoint) {
        dot.transform.position = new Vector3(hitPoint.x, hitPoint.y, hitPoint.z - .07f);
        dot.transform.localScale = new Vector3(.8f, .8f, .8f);
    }

    bool Check() {
        Transform closestGO = controlPos.GetClosestTarget();
        isCheck = closestGO.gameObject.GetComponent<Scaling>().isBig;
        Debug.Log(controlPos.GetClosestTarget().name);
        Debug.Log(isCheck);
        return isCheck;
    }

    public void AntMan() {
        if (prevScale == null) {
            if (safe && Check()) {
                safe = false;
                currentTarget = controlPos.GetClosestTarget();
                aHouse.parent = currentTarget;
                scale = currentTarget.gameObject.GetComponent<Scaling>();
                StartCoroutine(scale.Enlarge());
            }
            else if (!safe && !currentTarget.gameObject.GetComponent<Scaling>().isBig) {
                safe = true;
                aHouse.parent = null;
                StartCoroutine(scale.Shrink());
                scale = null;
                prevScale = currentTarget.gameObject.GetComponent<Scaling>();
                currentTarget = null;
            }
        }
        else {
            if (safe && Check() && prevScale.isBig) {
                safe = false;
                currentTarget = controlPos.GetClosestTarget();
                aHouse.parent = currentTarget;
                scale = currentTarget.gameObject.GetComponent<Scaling>();
                StartCoroutine(scale.Enlarge());
            }
            else if (!safe && !currentTarget.gameObject.GetComponent<Scaling>().isBig) {
                safe = true;
                aHouse.parent = null;
                StartCoroutine(scale.Shrink());
                scale = null;
                prevScale = currentTarget.gameObject.GetComponent<Scaling>();
                currentTarget = null;
            }
        }
    }

}
