using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseButton : MonoBehaviour {




    public Selectable select;
    public LevelChanger levelChanger;


    private MeshRenderer ren;
    private string houseName;
    Color flamingo;
    Color cyan;
    

    // Use this for initialization
    void Start () {
        ren = GetComponent<MeshRenderer>();
        houseName = transform.parent.name;
        flamingo = new Color(.99f, .56f, 67f);
        cyan = Color.cyan;
    }
	
	// Update is called once per frame
	void Update () {
        if (select.areYouLookingAtMe) {
            ren.material.SetColor("_Color", flamingo); // Set Design colors 
            //Change something in the button so it looks clickable 
        }
        else if (!select.areYouLookingAtMe) {
            ren.material.SetColor("_Color", Color.black);
        }
         if (select.areYouLookingAtMe && select.triggerDown) {
            ren.material.SetColor("_Color", cyan);
            levelChanger.FadeToBlack(houseName);
        }

    }
}
