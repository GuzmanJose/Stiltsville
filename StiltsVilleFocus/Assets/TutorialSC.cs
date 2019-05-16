using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSC : MonoBehaviour {


    public Transform player;
    public Selectable select;

    private MeshRenderer ren;
    Color flamingo;
    Color cyan;

    static int count = 0;



    // Use this for initialization
    void Start () {
        ren = GetComponent<MeshRenderer>();
        flamingo = new Color(.99f, .56f, 67f);
        cyan = Color.cyan;
        FindTheRightPlace();
        count++;
	}
	
	// Update is called once per frame
	void Update () {
        if (select.areYouLookingAtMe) {
            //Change Button Color
            ren.material.SetColor("_Color", flamingo);
        }
        else if (!select.areYouLookingAtMe) {
            ren.material.SetColor("_Color", Color.white);
        }
        if (select.areYouLookingAtMe && select.triggerDown || count >= 3) {
            this.gameObject.SetActive(false);
        }
	}


    void FindTheRightPlace() {
        Vector3 playerFor = player.forward * 4f;
        transform.position = new Vector3(playerFor.x, 1.098f, playerFor.z);
       // transform.LookAt(player);

    }

}
