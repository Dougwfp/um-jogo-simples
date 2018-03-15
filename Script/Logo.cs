using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Logo : MonoBehaviour {

    float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (time >= 1.0f)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            time = time + Time.deltaTime;
        }
    }
}
