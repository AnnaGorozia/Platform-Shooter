using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LifeController : MonoBehaviour
{
    public int life = 100;
    public String tagName;

    public void Start()
    {
        life = 100;
    }

    public void Update()
    {
        float perc = (float)life / 100;
        GameObject[] indicator = GameObject.FindGameObjectsWithTag(tagName);
        foreach(GameObject i in indicator)
        {
            i.transform.localScale = new Vector3(perc, 1, 1);
        }
    }
}
