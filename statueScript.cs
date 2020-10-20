using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class statueScript : MonoBehaviour
{

    private GameObject player;
    [SerializeField]
    private bool seesPlayer;
    private Animator animator;
    [SerializeField]
    private AudioSource[] StatueSounds;
    private AudioSource[] PlayerSounds;

    public Rigidbody rb;

    [SerializeField]
    private GameObject flashlight;

    [SerializeField]
    private GameObject spotToGoTo;

    [SerializeField]
    [Range(0, 20)] float seesPlayerRadius;

    float distanceMultiplier;

    bool seesPlayerFlag;

    // Start is called before the first frame update
    void Start()
    {
        seesPlayerFlag = false;
        animator = GetComponent<Animator>();
        StatueSounds = GetComponents<AudioSource>();
        PlayerSounds = GameObject.Find("StatueSoundEffect").GetComponents<AudioSource>();

        seesPlayerRadius = 10;

        seesPlayer = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < 2) {
            SceneManager.LoadScene("Jumpscare");
        }

        // TURNING ON FLASHLIGHT MAKES IT EASIER FOR STATUE TO SEE YOU:
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("BuildingMaze"))
        {
            if (GameObject.Find("Player").GetComponent<playerMovement>().isSprinting)
            {
                seesPlayerRadius = 9;
            }
            else if (flashlight.activeSelf == true)
            {
                if (flashlight.GetComponent<Light>().isActiveAndEnabled == true)
                {
                    seesPlayerRadius = 14;
                }
                    
            } else
            {
                seesPlayerRadius = 9;
            }
        } else
        {
            if (flashlight.GetComponent<Light>().isActiveAndEnabled == true)
            {
                seesPlayerRadius = 10;
            }
            else
            {
                seesPlayerRadius = 5;
            }
        }
        

        //IF STATUE IS WITHIN THE PLAYER'S RADIUS...
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) <= seesPlayerRadius)
        {
            //IF NOTHING IS HIDING YOU FROM THE STATUE...
            if (!Physics.Linecast(GameObject.Find("StatueHead").transform.position, GameObject.Find("Player").transform.position))
            {
                SpotPlayer();
            }
        }

        if (seesPlayer == true)
        {
            //if (scene)
            transform.LookAt(player.transform);
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("parkingLot"))
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 8f);
                //transform.position += transform.forward * Time.deltaTime * 8;

            } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BuildingMaze"))
            {
                //transform.position += transform.forward * Time.deltaTime * 6;
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 8f);

            }
            else
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 7f);

                //transform.position += transform.forward * Time.deltaTime * 5;
            }

            if (seesPlayerFlag == false)
            {
                PlayerSounds[0].Play();
                seesPlayerFlag = true;
            }

            if ((Vector3.Distance(transform.position,player.transform.position) > 20) && (Physics.Linecast(GameObject.Find("StatueHead").transform.position, GameObject.Find("Player").transform.position)) && (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("parkingLot")))
            {
                seesPlayer = false;
                spotToGoTo = FindClosestSpot();
            }
        }
        
        if ((seesPlayer == false)&&(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("parkingLot"))) {
            //wander aroudn on his own path
            StatueSounds[0].enabled = true;
            StatueSounds[1].enabled = true;
            seesPlayerFlag = false;

            if (Vector3.Distance(transform.position, player.transform.position) >= 30)
            {
                distanceMultiplier = 20;
            } else
            {
                distanceMultiplier = 1;
            }

            if (Vector3.Distance(spotToGoTo.transform.position, transform.position) > 1)
            {
                if (SceneManager.GetActiveScene().name == "quadrangleScene") {
                    transform.LookAt(spotToGoTo.transform);
                    rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 4* distanceMultiplier);

                    //transform.position += transform.forward * Time.deltaTime * 4 * distanceMultiplier;
                }
                else if (SceneManager.GetActiveScene().name == "BuildingMaze")
                {
                    transform.LookAt(spotToGoTo.transform);
                    //transform.position += transform.forward * Time.deltaTime * 2 * distanceMultiplier;
                    rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 2 * distanceMultiplier);

                }
            } else
            {
                int randomNum = 0;
                if (spotToGoTo.GetComponent<SpotScript>().branchingPaths == false)
                {
                    spotToGoTo = spotToGoTo.GetComponent<SpotScript>().NextSpot1;
                } else
                {
                    if (spotToGoTo.GetComponent<SpotScript>().NextSpot3 != null)
                    {
                        if (spotToGoTo.GetComponent<SpotScript>().NextSpot4 != null)
                        {
                            randomNum = (int)Mathf.Round(Random.Range(1, 5));
                        }
                        else {
                            randomNum = (int)Mathf.Round(Random.Range(1, 4));
                        }
                    } else
                    {
                        randomNum = (int)Mathf.Round(Random.Range(1, 3));
                    }
                }
                if (randomNum == 1)
                {
                    spotToGoTo = spotToGoTo.GetComponent<SpotScript>().NextSpot1;
                } else if (randomNum == 2)
                {
                    spotToGoTo = spotToGoTo.GetComponent<SpotScript>().NextSpot2;
                } else if (randomNum == 3)
                {
                    spotToGoTo = spotToGoTo.GetComponent<SpotScript>().NextSpot3;
                } else if (randomNum == 4)
                {
                    spotToGoTo = spotToGoTo.GetComponent<SpotScript>().NextSpot4;
                }
            }

        }
        animator.SetBool("SeesPlayer", seesPlayer);
    }

    public void SpotPlayer()
    {
        seesPlayer = true;
        return;
    }

    private GameObject FindClosestSpot()
    {
        GameObject[] spots = GameObject.FindGameObjectsWithTag("Spot");
        GameObject closestSpot = null;
        float distance = Mathf.Infinity;

        foreach (GameObject spot in spots)
        {
            Vector3 diff = spot.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestSpot = spot;
                distance = curDistance;
            }
        }
        return closestSpot;
    }
}
