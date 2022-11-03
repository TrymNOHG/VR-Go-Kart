using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GoKartMoveVR : MonoBehaviour
{

    public GameObject leftHand;
    public GameObject rightHand;
    public SteamVR_TrackedObject left;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        left = GetComponent<SteamVR_TrackedObject>();


        if (Input.GetAxis("Left Trigger") > 0.1f || Input.GetAxis("Left Trigger") < -0.1f)
        {
            GetComponent<Rigidbody>().velocity = transform.right * 10;
            if (leftHand.transform.rotation.y > 0)
            {
                transform.Rotate(Vector3.down, 100 * Time.deltaTime);
            }
            else if (leftHand.transform.rotation.y < 0)
            {
                transform.Rotate(Vector3.up, Time.deltaTime * 100);
            }

        }
        if (Input.GetAxis("Right Trigger") > 0.1f || Input.GetAxis("Right Trigger") < -0.1f)
        {
            GetComponent<Rigidbody>().velocity = -transform.right * 10;
            if (leftHand.transform.rotation.y > 0)
            {
                transform.Rotate(Vector3.down, 100 * Time.deltaTime);
            }
            else if (leftHand.transform.rotation.y < 0)
            {
                transform.Rotate(Vector3.up, Time.deltaTime * 100);
            }
        }

    }
}
