using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullsController : MonoBehaviour {

    //This is the manager that will control the spawn and flight of the seagulls
    //Direction, current size Status (Big||Small) and SegullFlock prefab
    public Vector3 Target;

    public GameObject FlockSeagulls;


	// Use this for initialization
	void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {
        //// Create Flock of Seagulls in a ramdon position
        //if (GameObject.Find("SeaGullFlock") == null) {
        //    Instantiate(FlockSeagulls, RandomPosition(), Quaternion.identity);
        //}
    }


    //Create a Random Position for the Flock of Seagulls
    Vector3 RandomPosition() {
        Vector3 seaPos;
        float x = Random.Range(18f, 32f);
        float z = Random.Range(18f, 32f);
        seaPos = new Vector3(x, this.transform.position.y, z);
        return seaPos;
    }
}
