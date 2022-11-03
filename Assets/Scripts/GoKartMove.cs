using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoKartMove : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = Vector3.zero;  
        
        
        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().velocity = transform.right * 10;
            if (Input.GetKey("a"))
            {
                transform.Rotate(Vector3.down, 100 * Time.deltaTime);
            }
           else if (Input.GetKey("d"))
            {
                transform.Rotate(Vector3.up, Time.deltaTime * 100);
            }
           
        } 
        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().velocity = - transform.right * 10;
            if (Input.GetKey("a"))
            {
                transform.Rotate(Vector3.down, 100 * Time.deltaTime);
            }
            else if (Input.GetKey("d"))
            {
                transform.Rotate(Vector3.up, Time.deltaTime * 100);
            }
        }
        
    }
}
