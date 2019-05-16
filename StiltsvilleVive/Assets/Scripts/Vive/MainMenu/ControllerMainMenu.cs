using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerMainMenu : MonoBehaviour {

    //public Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    //public Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    ////public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    //SteamVR_TrackedObject trackedObj;




   
    //private LineRenderer line;
    //bool lineOn;

    //// Use this for initialization
    //void Start() {
    //    lineOn = false;
    //    trackedObj = GetComponent<SteamVR_TrackedObject>();
    //    line = GetComponent<LineRenderer>();
    //}

    //// Update is called once per frame
    //void Update() {

    //    //if (controller.GetPressDown(touchPad) && !lineOn) {
    //    //    lineOn = true;
    //    //}
    //    //else if (controller.GetPressDown(touchPad) && lineOn) {
    //    //    lineOn = false;
    //    //    line.enabled = false;
    //    //}
    //    //if (lineOn) {
    //    //    PointerOn();
    //    //}


    //}






    //void PointerOn() {
    //    line.enabled = true;
    //    line.SetPosition(0, transform.position);
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit)) {
    //        Debug.Log(hit.transform.gameObject.name);
    //        line.SetPosition(1, hit.point);
    //        //if (hit.transform.tag == "House" && controller.GetPressDown(triggerButton)) {
    //        //    hit.transform.gameObject.GetComponent<HouseSelection>().ShowMenu();
    //        //}
    //    }
    //    else {
    //        line.SetPosition(1, transform.position + transform.forward * 10);
    //    }
    //}





    

}

