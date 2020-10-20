using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectInteraction : MonoBehaviour
{

    private GameObject diagText;
    private bool diagActive;
    private bool isAttacking;
    private bool[] activeVerification;
    private string itemCheck;

    public AudioClip bushhitclip;
    public AudioSource bushhitsound;

    //PEDRO's VARIABLE
    private GameObject chosenObject;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        diagActive = false;
        diagText = GameObject.Find("DiagText");

        bushhitsound = gameObject.AddComponent<AudioSource>();
        bushhitsound.volume = 0.5f;
        bushhitsound.clip = bushhitclip;
    }


    
    private void OnTriggerStay(Collider other)
    {
        /// <summary>
        /// For Dialog
        /// </summary>
        /// <param name="other"></param>
        /// 
        activeVerification = GameObject.Find("Inventory").GetComponent<Inventory>().activeVerification;
        itemCheck = GameObject.Find("Inventory").GetComponent<Inventory>().itemCheck;

        // **********************  PEDRO's CODE - MACHETE HIT DETECTION ON BUSHES ********************************
        if (itemCheck == "Machete")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //if (isAttacking = false)
                //{
                    //Debug.Log("ISATTACKING IS FALSE");
                    if (other.tag == "DestructibleByMachete")
                    {              
                            other.GetComponent<vineScript>().LowerVineHealth();
                            bushhitsound.Play();
                            
                    }
                //}
            }
        }
        // **********************  PEDRO's CODE ENDS HERE ********************************

        if (activeVerification[2] && itemCheck == "Machete")//Change the 0 to 2 after you're done TESTING!!!!
        {
            isAttacking = GameObject.Find("Machete").GetComponent<macheteScript>().isAttacking;
        }

        if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
        {
        ///For Inventory Objects
        ///Use this to activate the activation script on items
            if(other.tag == "Item")
            {
                other.gameObject.GetComponent<ActivationScript>().enabled = true;
            }

            //TRIGGERS DIALOGUE
            else if ((other.tag == "InteractObject") && (diagActive == false))
            {
                StartCoroutine(DisplayDiag(other.GetComponent<objectInteractInfo>().diagOption));
            }



           
        }

    }

    //Use this to display dialogue.
    public IEnumerator DisplayDiag(string diag)
    {
        diagActive = true;
        diagText.GetComponent<Text>().text = diagText.GetComponent<AllDiagOptions>().GetProperDiagOption(diag);
        StartCoroutine(FadeInDiag());
        yield return wait(5f);
        diagActive = false;
        StartCoroutine(FadeOutDiag());
    }

    public IEnumerator DisplayDiagLong(string diag)
    {
        diagActive = true;
        diagText.GetComponent<Text>().text = diagText.GetComponent<AllDiagOptions>().GetProperDiagOption(diag);
        yield return StartCoroutine(FadeInDiag());
        yield return wait(10f);
        diagActive = false;
        yield return StartCoroutine(FadeOutDiag());
    }

    IEnumerator FadeOutDiag()
    {
        for (float i = 1f; i >= 0f; i -= 0.05f)
        {
            diagText.GetComponent<Text>().color = new Color(222f, 222f, 222f, i);
            yield return new WaitForSeconds(0.01f);
        }
        diagText.GetComponent<Text>().color = new Color(222f, 222f, 222f, 0f);
    }

    IEnumerator FadeInDiag()
    {
        for (float i = 0f; i <= 1f; i += 0.05f)
        {
            diagText.GetComponent<Text>().color = new Color(222f, 222f, 222f, i);
            yield return new WaitForSeconds(0.01f);
        }
        diagText.GetComponent<Text>().color = new Color(222f, 222f, 222f, 222f);
    }

    IEnumerator wait(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
    }

}
