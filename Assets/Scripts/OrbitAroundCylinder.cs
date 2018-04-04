using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundCylinder : MonoBehaviour
{
    public Vector3 axis, rotateArround, rotationVec;
    public float speed;
    // Use this for initialization
    void Start()
    {
        axis = new Vector3(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
        rotateArround = Vector3.zero;
        speed = Random.Range(2f, 8f);
        rotationVec = new Vector3(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speed);
        GameObject cylinder = GameObject.FindGameObjectWithTag("Cylinder");
        //Vector3 rotateArround = cylinder.transform.position;
        transform.RotateAround(rotateArround, axis, speed * Time.deltaTime);
        transform.Rotate(rotationVec);
    }
}
