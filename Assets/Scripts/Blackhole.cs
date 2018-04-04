using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trash")
        {
            Vector3 force = this.transform.position - other.transform.position;
            other.attachedRigidbody.AddForce(force * 15);
        }
    }
}
