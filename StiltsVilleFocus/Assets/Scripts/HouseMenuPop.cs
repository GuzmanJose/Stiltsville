using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMenuPop : MonoBehaviour {

    public GameObject viveHead;

    public float time;
    public float speed;

    private Vector3 firstScale;
    private Vector3 secondScale;
    private Vector3 offset;
    private bool menuOn = false;

    Selectable select;

    HouseMenuPop [] menus;

	// Use this for initialization
	void Start () {
        menus = FindObjectsOfType<HouseMenuPop>();
        select = transform.parent.gameObject.GetComponent<Selectable>();
        firstScale = transform.localScale;
        secondScale = new Vector3(0.4473167f, 0.4473167f, 0.4473167f);
        offset = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y + 1.5f, transform.parent.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (select.areYouLookingAtMe && select.triggerDown && !menuOn) {          
            StartCoroutine(PopOut());
            HideOtherMenus();
        }
        else if (select.areYouLookingAtMe && select.triggerDown && menuOn) {
            
            StartCoroutine(HideMenu());
        }
	}

    public IEnumerator PopOut() {
        transform.LookAt(viveHead.transform);
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            transform.LookAt(viveHead.transform);
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(firstScale, secondScale, i);
            transform.position = Vector3.Lerp(transform.position, offset, i);
            yield return null;
        }
        menuOn = true;
    }

    public IEnumerator HideMenu() {
        transform.LookAt(viveHead.transform);
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            transform.LookAt(viveHead.transform);
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(secondScale, firstScale, (i * 3));
            transform.position = Vector3.Lerp(transform.position, transform.parent.transform.position, i);
            yield return null;
        }
        menuOn = false;
    }

    void HideOtherMenus() {
        foreach (HouseMenuPop menu in menus) {
            if (menu.name != this.gameObject.name && menu.menuOn) {
                menu.menuOn = false;
                StartCoroutine(menu.HideMenu());
            }
        }
    }


}
