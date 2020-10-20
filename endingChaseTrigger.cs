using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingChaseTrigger : MonoBehaviour
{
    bool flag;
    [SerializeField]
    GameObject statue;

    private void Start()
    {
        flag = false;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("parkingLot"))
        {
            statue.SetActive(false);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player")&&(flag == false))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("parkingLot"))
            {
                flag = true;
                statue.SetActive(true);
                GameObject.Find("bigdoor").GetComponent<AudioSource>().Play();
                statue.GetComponent<statueScript>().SpotPlayer();
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("quadrangleScene"))
            {
                StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag3"));
                flag = true;
            }
        }
        
    }
}
