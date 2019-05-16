using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {


    Animator anim;
    string levelName;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeToBlack(string level) {
        //levelName = level;
        SceneManager.LoadScene(level);
        //anim.SetTrigger("FadeOut");
    }

    //public void LoadLevel() {
    //    SceneManager.LoadScene(levelName);
    //}

}
