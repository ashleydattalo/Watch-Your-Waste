using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{

    public bool zoomOut = false;
    int distance = -13;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            zoomOut = !zoomOut;
        }

        if (zoomOut == true && this.transform.position.z >= distance)
        {
            Vector3 position = this.transform.position;
            position.z -= 0.01f;
            this.transform.position = position;
        }

        if (zoomOut == false && this.transform.position.z <= 0)
        {
            Vector3 position = this.transform.position;
            position.z += 0.003f;
            this.transform.position = position;
        }
    }
}
