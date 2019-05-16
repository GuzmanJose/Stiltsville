using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Controller : MonoBehaviour {

    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_TouchController;

    public ControlTargetPosition controlPos;
    public Transform aHouse;
    public ShrinkingManager shrinkMan;
    public bool safe;

    private bool isCheck;
    private Transform currentTarget;
    private Scaling scale;
    private Scaling prevScale;
    private LineRenderer line;

    GameObject[] targets;


    private void Awake() {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
        m_TouchController = SteamVR_Actions._default.Teleport;

    }


    // Use this for initialization
    void Start() {
        targets = GameObject.FindGameObjectsWithTag("Target");
        safe = true;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {

        if (m_TouchController.GetStateDown(SteamVR_Input_Sources.RightHand)) {
            AntMan();
        }

    }


    bool Check() {
        Transform closestGO = controlPos.GetClosestTarget();
        isCheck = closestGO.gameObject.GetComponent<Scaling>().isBig;
        Debug.Log(controlPos.GetClosestTarget().name);
        Debug.Log(isCheck);
        return isCheck;
    }


    //The reason why this didnt work is because the viewfield of the camera didnt shrink relative to the camera rig scale

    //IEnumerator Shrink(Vector3 a, Vector3 b, float time) {
    //    float i = 0.0f;
    //    float rate = (1.0f / time) * speed;

    //        while (i < 1.0f) {
    //        i += Time.deltaTime * rate;
    //        viveTransform.localScale = Vector3.Lerp(a, b, i);
    //        yield return null;
    //    }

    //}


    void AntMan() {
        if (prevScale == null) {
            if (safe && Check()) {
                safe = false;
                currentTarget = controlPos.GetClosestTarget();
                aHouse.parent = currentTarget;
                scale = currentTarget.gameObject.GetComponent<Scaling>();
                StartCoroutine(scale.Enlarge());
                shrinkMan.BigWavesOn();
            }
            else if (!safe && !currentTarget.gameObject.GetComponent<Scaling>().isBig) {
                safe = true;
                aHouse.parent = null;
                StartCoroutine(scale.Shrink());
                scale = null;
                prevScale = currentTarget.gameObject.GetComponent<Scaling>();
                currentTarget = null;
                shrinkMan.SmallWavesOn();
            }
        }
        else {
            if (safe && Check() && prevScale.isBig) {
                safe = false;
                currentTarget = controlPos.GetClosestTarget();
                aHouse.parent = currentTarget;
                scale = currentTarget.gameObject.GetComponent<Scaling>();
                StartCoroutine(scale.Enlarge());
                shrinkMan.BigWavesOn();
            }
            else if (!safe && !currentTarget.gameObject.GetComponent<Scaling>().isBig) {
                safe = true;
                aHouse.parent = null;
                StartCoroutine(scale.Shrink());
                scale = null;
                prevScale = currentTarget.gameObject.GetComponent<Scaling>();
                currentTarget = null;
                shrinkMan.SmallWavesOn();
            }
        }
    }

}
