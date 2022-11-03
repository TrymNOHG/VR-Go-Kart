using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager inst;

    void Awake()
    {
        if (inst== null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(inst);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
