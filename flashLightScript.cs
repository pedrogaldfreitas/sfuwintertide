using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLightScript : MonoBehaviour
{
    Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GameObject.Find("Main Camera").transform;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = cameraTransform.position;
        //this.transform.rotation = cameraTransform.rotation;
        Quaternion.RotateTowards(this.transform.rotation, cameraTransform.rotation, 100f);
        //Vector3.MoveTowards();
    }
}
