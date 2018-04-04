using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashable : MonoBehaviour
{
    public Trash trash;
    public GameObject trashPile;
    private List<GameObject> instances;

    private void Start()
    {
        this.instances = new List<GameObject>();
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<OrbitAroundCylinder>().enabled = false;
    }

    private void Update()
    {
        // Tumble the trashable.
        transform.Rotate(Vector3.up, 40 * Time.deltaTime);
        transform.Rotate(Vector3.left, 10 * Time.deltaTime);
    }

    /// <summary>
    /// Adds an instance of the thrashable to the pile.
    /// </summary>
    public void Add()
    {
        this.trash.count++;

        // Create a new instance of the trash prefab.
        GameObject instance = GameObject.Instantiate(this.trash.prefab, trashPile.transform);

        // Provide a small random force so that items don't stack.
        float randomX = Random.Range(1, 10);
        float randomY = Random.Range(1, 10);
        float randomZ = Random.Range(1, 10);
        instance.GetComponent<Rigidbody>().AddForce(new Vector3(randomX, randomY, randomZ));

        // Track the instance.
        this.instances.Add(instance);

        // Move the trashpile up as trash builds.
        Vector3 position = trashPile.transform.position;
        position.y = Mathf.Clamp(position.y + 0.01f, 1.2f, 2f);
        trashPile.transform.position = position;
    }

    /// <summary>
    /// Removes an instance of the thrashable from the pile.
    /// </summary>
    public void Remove()
    {
        if (this.trash.count > 0)
        {
            this.trash.count--;

            GameObject lastInstance = this.instances[this.instances.Count - 1];

            // Remove the instance from the list.
            this.instances.Remove(lastInstance);

            // Destroy the object.
            Destroy(lastInstance);

            // Move the trashpile up as trash builds.
            Vector3 position = trashPile.transform.position;
            position.y = Mathf.Clamp(position.y + 0.01f, 1.2f, 3f);
            trashPile.transform.position = position;
        }
    }
}
