using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    // public TrashInput trashInput;
    public TrashCollector trashCollector;
    public List<Trash> trash;
    public int spawnTime = 100;
    // public int weekTime = 2000;
    public bool isStarted = false;
    private int months = 0;
    private bool rateIncreased = false;

    private int frameCount;

    // Use this for initialization
    void Start()
    {
        if (this.trashCollector != null)
        {
            trash = this.trashCollector.trash;
        }
    }
    int trashCount = 0;
    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            frameCount++;
            if (frameCount % spawnTime == 0)
            {
                SpawnObject();
                trashCount++;
            }

            int totalRemaining = 0;

            foreach (Trash trash in this.trash)
            {
                totalRemaining += trash.remainingInMonth;
            }

            if (totalRemaining == 0)
            {
                if (months < 12)
                {
                    AddTrash(1);
                }
            }
        }
    }

    public void BeginGenerating()
    {
        isStarted = true;
    }

    // cycles through list of objects and adds one if the user has one left
    // then updates the trash list by decreasing that object's trash count by 1
    void SpawnObject()
    {
        float xPos, yPos, zPos;
        float scaleX, scaleY, scaleZ;
        scaleX = 10;
        scaleY = 20;
        scaleZ = 10;

        foreach (Trash trash in this.trash)
        {
            if (trash.remainingInMonth > 0)
            {
                GameObject cylinder = GameObject.FindGameObjectWithTag("Cylinder");
                xPos = Random.Range(-5, 5);
                yPos = Random.Range(0, 5);
                zPos = Random.Range(-5, 5);
                //Vector3 newPos = cylinder.transform.position + new Vector3(xPos, yPos, zPos);
                Vector3 newPos = new Vector3(xPos, yPos, zPos);

                GameObject instance = Instantiate(trash.prefab, newPos, Quaternion.identity);
                float randomX = Random.Range(-10, 10);
                float randomY = Random.Range(-10, 10);
                float randomZ = Random.Range(-10, 10);
                //instance.GetComponent<Rigidbody>().AddForce(new Vector3(randomX, randomY, randomZ) * 10);

                trash.remainingInMonth--;
            }
        }
    }

    void AddTrash(int months)
    {
        this.months += months;

        if (this.trashCollector != null)
        {
            this.trashCollector.AddMonths(months);
        }

        for (int i = 0; i < months; i++)
        {
            AddOneMonthTrash();
        }
    }

    // adds a month's worth of trash to the user's trash list
    void AddOneMonthTrash()
    {
        foreach (Trash trash in this.trash)
        {
            trash.ResetRemaining();
        }
    }
}