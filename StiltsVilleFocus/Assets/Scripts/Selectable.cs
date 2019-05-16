using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;

public class Selectable : MonoBehaviour {

    public bool areYouLookingAtMe;
    public bool triggerDown;
    public bool triggerUp;
    public bool touchPadDown;
    public bool touchPadUp;
    public ControlSelector control;
    public GameObject cubeTest;

    private GameObject obj1;
    private GameObject obj2;

    WVR_DeviceType device = WVR_DeviceType.WVR_DeviceType_Controller_Right;
    WVR_InputId trigger = WVR_InputId.WVR_InputId_Alias1_Digital_Trigger;
    WVR_InputId touchPad = WVR_InputId.WVR_InputId_Alias1_Touchpad;

    void Update() {
        if (control.rayHit) {

            if (obj1 == null) {
                obj1 = control.rayHit;
                if (obj1.GetComponent<Selectable>() != null) {
                    obj1.GetComponent<Selectable>().areYouLookingAtMe = true;
                }
            }
            else if (obj1 != control.rayHit) {
                obj2 = obj1;
                obj1 = control.rayHit;
                if (obj1.GetComponent<Selectable>() != null) {
                    obj1.GetComponent<Selectable>().areYouLookingAtMe = true;
                }
                if (obj2.GetComponent<Selectable>() != null) {
                    obj2.GetComponent<Selectable>().areYouLookingAtMe = false;
                }    
            }
            else if (obj1) {
                if (obj1.GetComponent<Selectable>() != null) {
                    obj1.GetComponent<Selectable>().areYouLookingAtMe = true;
                }

            }
            
        }
        else if (control.rayHit == null) {
            GoFalse();
        }


        if (WaveVR_Controller.Input(device).GetPressDown(trigger)) {
            triggerDown = true;
            triggerUp = false;
            cubeTest.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (WaveVR_Controller.Input(device).GetPressUp(trigger)) {
            triggerDown = false;
            triggerUp = true;
            cubeTest.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (WaveVR_Controller.Input(device).GetPressDown(touchPad)) {
            touchPadDown = true;
            touchPadUp = false;
            cubeTest.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (WaveVR_Controller.Input(device).GetPressUp(touchPad)) {
            touchPadDown = false;
            touchPadUp = true;
            cubeTest.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void GoFalse() {
        if (obj1 != null) {
            if (obj1.GetComponent<Selectable>() != null) {
                obj1.GetComponent<Selectable>().areYouLookingAtMe = false;
            }
        }
        if (obj2 != null) {
            if (obj2.GetComponent<Selectable>() != null) {
                obj2.GetComponent<Selectable>().areYouLookingAtMe = false;
            }
        }

    }


}
