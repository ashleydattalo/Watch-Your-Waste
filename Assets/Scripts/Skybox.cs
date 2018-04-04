using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class Skybox : MonoBehaviour
{
    public int currSkybox = 0;
    public List<Material> skyBoxes;
    private int frame;

    void Start()
    {
        RenderSettings.skybox = skyBoxes[currSkybox];
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(3);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currSkybox++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currSkybox--;
        }
        currSkybox = Mathf.Abs(currSkybox + skyBoxes.Count) % skyBoxes.Count;
        RenderSettings.skybox = skyBoxes[currSkybox];

    }


}