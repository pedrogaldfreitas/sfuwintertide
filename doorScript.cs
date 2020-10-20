using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string sceneToLoad;


    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Crosshair")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("quadrangleScene"))
                {
                    if ((GameObject.Find("WALLLIGHT1").GetComponent<Light>().color == Color.green) && (GameObject.Find("WALLLIGHT2").GetComponent<Light>().color == Color.green) && (GameObject.Find("WALLLIGHT3").GetComponent<Light>().color == Color.green) && (GameObject.Find("WALLLIGHT4").GetComponent<Light>().color == Color.green))
                    {
                        StartCoroutine(sceneTransition());
                    } else
                    {
                        StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag4"));
                    }
                } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BuildingMaze"))
                {
                    if (GameObject.Find("Card(Item)") == null)
                    {
                        StartCoroutine(sceneTransition());
                    }
                    else
                    {
                        StartCoroutine(GameObject.Find("Crosshair").GetComponent<objectInteraction>().DisplayDiag("diag4"));
                    }
                }
                else
                {
                    StartCoroutine(sceneTransition());
                }
            }
        }
    }

    IEnumerator sceneTransition()
    {
        GameObject.Find("Player").GetComponent<playerMovement>().enabled = false;
        GameObject.Find("Player").GetComponent<Animator>().SetFloat("Horizontal", 0f);
        GameObject.Find("Player").GetComponent<Animator>().SetFloat("Vertical", 0f);
        GameObject.Find("Main Camera").GetComponent<cameraScript>().enabled = false;
        GameObject.Find("Statue").GetComponent<statueScript>().enabled = false;

        animator.SetTrigger("dooropentrigger");
        GetComponent<AudioSource>().Play();
        //yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(GameObject.Find("CutsceneManager").GetComponent<cutsceneManager>().FadeIn(GameObject.Find("BlackScreen")));
        SceneManager.LoadScene(sceneToLoad);
    }
}
