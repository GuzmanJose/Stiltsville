using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSelection: MonoBehaviour {



    public bool menuOn;

    HouseMenuPop houseMenu;


	// Use this for initialization
	void Start () {
       houseMenu =  GetComponentInChildren<HouseMenuPop>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowMenu() {
        if (!menuOn) {
            StartCoroutine(houseMenu.PopOut());
            // Turn on particle system
        }
        if (menuOn) {
            StartCoroutine(houseMenu.HideMenu());
        }
    }
}
