using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    public float offX, offY, offZ;
    private float initX, initY, initZ, initFrames;

    // Use this for initialization
    void Start()
    {
        offX = Random.value;
        offY = Random.value;
        offX = Random.value;

        initX = transform.position.x;
        initY = transform.position.y;
        initZ = transform.position.z;

        initFrames = Time.frameCount;

        Debug.Log(initFrames);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * Time.deltaTime);
        // transform.Translate(Vector3.up * Time.deltaTime, Space.World);

        //transform.RotateAround(Camera.main.transform.position, Vector3.up, 20 * Time.deltaTime);
        // transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);

        // //trying to do spiral curve
        // Vector3 newPosition = new Vector3(0f, 0f, 0f);
        // float radius = 15f;

        // float frameCount = initFrames + Time.frameCount / 100;
        // newPosition.x = radius * Mathf.Cos(frameCount);
        // newPosition.y = 0.001f * frameCount;
        // newPosition.z = radius * Mathf.Sin(frameCount);

        // //transform.position = newPosition;

        // //Debug.Log(frameCount);

        // float rotationX = offX * Mathf.Sin(offX * Time.time);
        // float rotationY = offY * Mathf.Sin(offY * Time.time);
        // float rotationZ = offZ * Mathf.Sin(offZ * Time.time);
        // // Vector3 rotation = new Vector3(rotationX, rotationY, rotationZ);
        // transform.rotation = new Quaternion(rotationX, rotationY, rotationZ, 1.0f);
    }
}