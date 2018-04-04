using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public float force;
    public Vector3 direction;

    // Use this for initialization
    void Start()
    {
        //this.GetComponentInChildren<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trash")
        {
            Vector3 direction = Vector3.up;
            direction.x += Random.Range(0, 0.1f);
            direction.z += Random.Range(0, 0.1f);

            //Debug.Log(force);

            other.GetComponent<Rigidbody>().AddForce((this.transform.rotation * direction) * force);
            //other.GetComponent<Rigidbody>().AddTorque(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), ForceMode.Impulse);
        }
    }
}
