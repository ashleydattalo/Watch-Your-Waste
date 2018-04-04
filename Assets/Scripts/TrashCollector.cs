using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrashCollector : MonoBehaviour
{
    public ZoomOut zoomOut;
    public GameObject trashPile;
    public GameObject trashBin;
    public GameObject trashables;
    public GameObject message;
    public GameObject trashCounter;
    public float trashHeight = 1f;
    public float trashRadius = 0.5f;
    public List<Trash> trash;

    private int months = 0;
    private int years = 0;
    private bool runOnce = true;

    private void Start()
    {
        Screen.fullScreen = true;
        this.SetupTrashables();
        message.GetComponent<Text>().text = "Watch\nYour\nWaste";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && runOnce == true)
        {
            runOnce = false;
        }
    }

    public void BeginGenerating()
    {

    }

    private void ZoomOut()
    {
        zoomOut.zoomOut = !zoomOut.zoomOut;
        Invoke("End", 15);
    }


    private void End()
    {
        SteamVR_Fade.Start(Color.black, 3);
        Invoke("ReloadScene", 10);
    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    /// <summary>
    /// Arranges the trashables in a circular layout.
    /// </summary>
    private void SetupTrashables()
    {
        // Calculate the angle between trashables.
        float angle = (Mathf.PI * 2) / trash.Count;

        // Arrange each piece of trash around a circle, seperated by the degrees we just calculated.
        for (int i = 0; i < this.trash.Count; i++)
        {
            //float x = Mathf.Sin(angle * i) * this.trashRadius;
            //float z = Mathf.Cos(angle * i) * this.trashRadius;

            float row = i / 3;
            float col = i % 3;

            float x = (col * 0.6f) + this.trashables.transform.position.x;
            float y = (row * 0.6f) + this.trashables.transform.position.y;

            // Create the trash at the specified position.
            GameObject trash = GameObject.Instantiate(this.trash[i].prefab, new Vector3(x, y, this.trashables.transform.position.z), Quaternion.identity, this.trashables.transform);
            trash.tag = "Untagged";
            trash.GetComponent<Rigidbody>().isKinematic = true;

            // Convert the trash to a trashable.
            Trashable trashable = trash.AddComponent<Trashable>();
            trashable.trash = this.trash[i];
            trashable.trashPile = this.trashPile;

            // Create the trash counter.
            GameObject trashCounter = GameObject.Instantiate(this.trashCounter, trash.transform);
            trashCounter.GetComponent<TrashCounter>().trash = this.trash[i];

            // Reset the scale of the trash counter.
            Vector3 scale = this.trash[i].prefab.transform.localScale;
            trashCounter.transform.localScale = new Vector3(0.001f / scale.x, 0.001f / scale.y, 0.001f / scale.z);
        }
    }

    public void Hide()
    {
        this.trashPile.SetActive(false);
        this.trashBin.SetActive(false);
        this.trashables.SetActive(false);
    }

    public void AddMonths(int months)
    {
        this.months += months;

        if (this.months == 10)
        {
            this.ZoomOut();
        }

        if (months < 12 || this.months % 12 == 0)
        {
            this.ShowMessage();
        }


    }

    private void ShowMessage()
    {
        if (this.months == 1)
        {
            message.GetComponent<Text>().text = months + " Month";
        }
        else
        {
            message.GetComponent<Text>().text = months + " Months";
        }
    }
}

/// <summary>
/// Represents a piece of trash, and the stats associated with it.
/// </summary>
[Serializable]
public class Trash
{
    public Trash()
    {
        this.weeks = 1;
    }

    public GameObject prefab;
    public int weeks = 1;
    private int _count = 0;

    public int count
    {
        get
        {
            return _count;
        }
        set
        {
            _count = value;
            ResetRemaining();
        }
    }
    public int countPerWeek
    {
        get
        {
            // Debug.Log("Weeks = " + this.weeks);

            return _count / 1;
        }
    }
    public int remainingInMonth;

    public void ResetRemaining()
    {
        this.remainingInMonth = countPerWeek * 4;
    }
}
