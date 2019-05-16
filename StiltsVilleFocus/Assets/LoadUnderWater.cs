using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUnderWater : MonoBehaviour {


    public Selectable select;

    private Color flamingo;
    private Color cyan;
    private MeshRenderer ren;

    public static int house;

    // Use this for initialization
    void Start () {
        ren = GetComponent<MeshRenderer>();
        flamingo = new Color(.99f, .56f, 67f);
    }
	
	// Update is called once per frame
	void Update () {
        if (select.areYouLookingAtMe) {
            ren.material.SetColor("_Color", flamingo);
        }
        else if (!select.areYouLookingAtMe) {
            ren.material.SetColor("_Color", Color.white);
        }
        if (select.areYouLookingAtMe && select.triggerDown) {
            house = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("UnderWater");
        }
    }


}
