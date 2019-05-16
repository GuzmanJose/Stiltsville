using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullFlock : MonoBehaviour {

    public GameObject seagullMan;
    //Direction, target and Speed
    Vector3 target;
    Vector3 direction;
    Vector3 directionBig;
    public float speed;

    //Controller Check for shrink status
    //public Controller controller;


	// Use this for initialization
	void Start () {
        //create a vector directed to the seagull manager position
        target = seagullMan.transform.position;
        transform.LookAt(target);
        direction = (target - transform.position).normalized;
        directionBig = (new Vector3(target.x, target.y + 25f, target.z ) - transform.position).normalized; 
        Destroy(this.gameObject, 45f);
    }
	
	// Update is called once per frame
	void Update () {
        //if (!controller.safe) {
        //    transform.position += directionBig * ((speed + 3) * Time.deltaTime);
        //}
        //else if (controller.safe) {
        //    transform.position += direction * (speed * Time.deltaTime);
        //}

    }
}
