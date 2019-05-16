using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using UnityEngine.SceneManagement;

public class ControllerInputFocus : MonoBehaviour {


    private Material mat;
    private bool isCheck;
    private Transform currentTarget;
    private Scaling scale;
    private Scaling prevScale;
    private TextMesh button;
    private Color flamingo;

    private MeshRenderer letters;
    private BoxCollider boxColl;

    public ControlTargetPosition controlPos;
    public Transform aHouse;
    public bool safe;
    public Animator animRoof;
    
    public WVR_DeviceType device = WVR_DeviceType.WVR_DeviceType_Controller_Right;
    public Selectable select;

    WVR_InputId trigger = WVR_InputId.WVR_InputId_Alias1_Digital_Trigger;
    WVR_InputId touchPad = WVR_InputId.WVR_InputId_Alias1_Touchpad;
    WVR_InputId menu = WVR_InputId.WVR_InputId_Alias1_Menu;


    

    

    // Use this for initialization
    void Start () {
        boxColl = GetComponent<BoxCollider>();
        letters = GetComponent<MeshRenderer>();
        button = GetComponent<TextMesh>();
        mat = GetComponent<Renderer>().material;
        safe = true;
        flamingo = new Color(.99f, .56f, 67f);
    }
	
	// Update is called once per frame
	void Update () {
        if (select.areYouLookingAtMe) {
            button.color = flamingo;
        }
        else if (!select.areYouLookingAtMe) {
            button.color = Color.white;
        }

        if (WaveVR_Controller.Input(device).GetPressDown(trigger) && select.areYouLookingAtMe) {
            button.color = Color.yellow;
            LoadMainMenu();
        }

        else if (WaveVR_Controller.Input(device).GetPressDown(touchPad)) {   
            AntMan();
        }
    }

    public void AntMan() {
        if (prevScale == null) {
            if (safe && Check()) {
                safe = false;
                currentTarget = controlPos.GetClosestTarget();
                aHouse.parent = currentTarget;
                scale = currentTarget.gameObject.GetComponent<Scaling>();
                StartCoroutine(scale.Enlarge());
                boxColl.enabled = false;
                letters.enabled = false;
                animRoof.SetTrigger("RoofOff");
            }
            else if (!safe && !currentTarget.gameObject.GetComponent<Scaling>().isBig) {
                safe = true;
                aHouse.parent = null;
                StartCoroutine(scale.Shrink());
                scale = null;
                prevScale = currentTarget.gameObject.GetComponent<Scaling>();
                currentTarget = null;           
                boxColl.enabled = true;
                letters.enabled = true;
                animRoof.SetTrigger("RoofIn");
            }
        }
        else {
            if (safe && Check() && prevScale.isBig) {
                safe = false;
                currentTarget = controlPos.GetClosestTarget();
                aHouse.parent = currentTarget;
                scale = currentTarget.gameObject.GetComponent<Scaling>();
                StartCoroutine(scale.Enlarge());             
                boxColl.enabled = false;
                letters.enabled = false;
                animRoof.SetTrigger("RoofOff");
            }
            else if (!safe && !currentTarget.gameObject.GetComponent<Scaling>().isBig) {
                safe = true;
                aHouse.parent = null;
                StartCoroutine(scale.Shrink());
                scale = null;
                prevScale = currentTarget.gameObject.GetComponent<Scaling>();
                currentTarget = null;              
                boxColl.enabled = true;
                letters.enabled = true;
                animRoof.SetTrigger("RoofIn");
            }
        }
    }

    bool Check() {
        Transform closestGO = controlPos.GetClosestTarget();
        isCheck = closestGO.gameObject.GetComponent<Scaling>().isBig;
        Debug.Log(controlPos.GetClosestTarget().name);
        Debug.Log(isCheck);
        return isCheck;
    }

    void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");

    }

}
