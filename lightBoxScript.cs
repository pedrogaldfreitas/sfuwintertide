using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBoxScript : MonoBehaviour
{
    public bool flicked;
    public GameObject otherLight;


    private void Update()
    {
        if (flicked == false)
        {
            transform.Find("Point Light").GetComponent<Light>().color = Color.red;
        } else
        {
            transform.Find("Point Light").GetComponent<Light>().color = Color.green;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.name == "Crosshair")&&(Input.GetKeyDown(KeyCode.E)))
        {
            flicked = true;
            otherLight.GetComponent<Light>().color = Color.green;
        }
    }
}
