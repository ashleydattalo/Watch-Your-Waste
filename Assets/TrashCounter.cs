using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCounter : MonoBehaviour
{
    public Trash trash;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        this.Billboard();

        this.SetCount((int)trash.count);
    }

    /// <summary>
    /// Forces the text to face the camera.
    /// </summary>
    private void Billboard()
    {
        Camera hmd = Camera.main;
        Quaternion rotation = hmd.transform.rotation;
        rotation.x = 0;
        rotation.z = 0;

        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    /// <summary>
    /// Updates the text to reflect the current count.
    /// </summary>
    /// <param name="count">The count to display.</param>
    public void SetCount(int count)
    {
        this.GetComponentInChildren<Text>().text = count.ToString();
    }
}
