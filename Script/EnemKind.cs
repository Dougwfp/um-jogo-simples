using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemKind : MonoBehaviour {

    public Material normal;
    public Material outono;
    public Material inverno;
    public Material doce;

    public Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        float fase = PlayerPrefs.GetInt("fase");
        if (fase == 0)
        {
            rend.sharedMaterial = normal;
        }
        if (fase == 1)
        {
            rend.sharedMaterial = outono;
        }
        if (fase == 2)
        {
            rend.sharedMaterial = inverno;
        }
        if (fase >= 3)
        {
            rend.sharedMaterial = doce;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
