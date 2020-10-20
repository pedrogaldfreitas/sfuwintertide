using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vineScript : MonoBehaviour
{
    int health;
    GameObject childToDelete;

    private void Start()
    {
        health = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void LowerVineHealth()
    {
        this.transform.GetChild(health).gameObject.SetActive(false);
        health -= 1;
        return;
    }
}
