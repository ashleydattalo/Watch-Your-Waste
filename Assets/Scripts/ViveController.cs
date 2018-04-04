using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour
{
    private SteamVR_TrackedController controller;
    public TrashCollector trashCollector;
    private Trashable trashable;
    private GameObject trashPile;
    private GameObject trashPileRef;
    public TrashGenerator trashGenerator;
    private float trashPileHeight = 1.2f;
    private bool isGrabbingPile = false;

    private float initialPosition = 0;
    private bool generationStarted = false;

    public List<Material> skyBoxes;

    private int currSkybox = 0;


    // Use this for initialization
    void Start()
    {
        controller = this.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += this.TriggerClicked;
        controller.TriggerUnclicked += this.TriggerUnclicked;
        controller.PadClicked += this.PadClicked;
        controller.Gripped += this.GripClicked;
    }

    // Update is called once per frame
    void Update()
    {
        if (trashPile != null && trashPileRef == null)
        {
            trashPileRef = trashPile.gameObject;
        }

        if (isGrabbingPile == true && trashPile != null)
        {
            Vector3 position = this.trashPile.transform.position;
            position.y = this.transform.position.y;
            this.trashPile.transform.position = position;

            if (trashPile.transform.localScale.y >= 0.1f)
            {
                trashPile.transform.localScale *= 0.99f;
            }

            if (position.y <= 0.9f)
            {
                this.BeginGenerating();
            }
        }
        else if (trashPileRef != null)
        {
            Vector3 position = this.trashPileRef.transform.position;
            position.y = Mathf.Clamp(position.y + 0.001f, 1.2f, trashPileHeight);
            this.trashPileRef.transform.position = position;

            if (trashPileRef.transform.localScale.y < 1f)
            {
                trashPileRef.transform.localScale *= 1.01f;
            }
        }
    }

    void BeginGenerating()
    {
        if (generationStarted == false)
        {
            generationStarted = true;
            Debug.Log("Started Generating Trash!");
            this.trashGenerator.BeginGenerating();
            this.trashCollector.Hide();
            this.trashCollector.BeginGenerating();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Get the trashable component from the object.
        Trashable trashable = other.GetComponent<Trashable>();

        // If a trashable component was found, hold on to it.
        if (trashable != null)
        {
            this.trashable = trashable;
        }

        if (other.tag == "TrashPile")
        {
            this.trashPile = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Get the trashable component from the object.
        Trashable trashable = other.GetComponent<Trashable>();

        // If the object was a trashable, forget about it.
        if (trashable != null)
        {
            this.trashable = null;
        }

        if (other.tag == "TrashPile")
        {
            this.trashPile = null;
        }
    }

    private void TriggerClicked(object sender, ClickedEventArgs e)
    {
        if (this.trashable != null)
        {
            this.trashable.Add();
            trashPileHeight = Mathf.Clamp(trashPileHeight + 0.01f, 1.2f, 2f);
        }
        else if (this.trashPile != null)
        {
            initialPosition = this.transform.position.y;
            this.isGrabbingPile = true;
        }
    }

    private void TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        this.isGrabbingPile = false;
    }

    private void PadClicked(object sender, ClickedEventArgs e)
    {
        if (this.trashable != null)
        {
            this.trashable.Remove();
            trashPileHeight = Mathf.Clamp(trashPileHeight - 0.01f, 1.2f, 2f);
        }
    }

    private void GripClicked(object sender, ClickedEventArgs e)
    {
        currSkybox++;

        currSkybox = Mathf.Abs(currSkybox + skyBoxes.Count) % skyBoxes.Count;
        RenderSettings.skybox = skyBoxes[currSkybox];
    }
}
