using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macheteStrikeScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("MOUSE CLICKED: " + Input.GetMouseButtonDown(0));
        Debug.Log("MACHETE EQUIPPED: " + (GameObject.Find("Inventory").GetComponent<Inventory>().itemCheck == "Machete"));
        Debug.Log("BRANCH IN CROSSHAIR: " + (other.tag == "DestructibleByMachete"));
        Debug.Log("IS ATTACKING = FALSE: " + (GameObject.Find("Machete").GetComponent<macheteScript>().isAttacking == false));

        if (other.tag == "DestructibleByMachete")
        {
            Debug.Log("STAGE 1 PASSED");
            if (GameObject.Find("Inventory").GetComponent<Inventory>().itemCheck == "Machete")
            {
                Debug.Log("STAGE 2 PASSED");
                if  (GameObject.Find("Machete").GetComponent<macheteScript>().isAttacking == false)
                {
                    Debug.Log("STAGE 3 PASSED");
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("Registered Hit.");
                        RegisterHit(other.gameObject);
                    }
                }
            }
        }

    }

    public void RegisterHit(GameObject branch)
    {
        Destroy(branch);
    }
}
