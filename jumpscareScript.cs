using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpscareScript : MonoBehaviour
{

    int timer;
    [SerializeField]
    GameObject camera;
    bool flag;

    // Start is called before the first frame update
    void Awake()
    {
        flag = false;
        GameObject.Find("Hints").GetComponent<Text>().color = new Color(0.222f, 0.222f, 0.222f, 0f);
        GameObject.Find("Text").GetComponent<Text>().color = new Color(0.222f, 0.222f, 0.222f, 0f);
        timer = 0;
        transform.position = new Vector3(-0.02f, -2.1f, 13f);
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (transform.position.z > -4f)
        {
            transform.position -= new Vector3(0, 0, 5f);
        } else
        {
            transform.position = new Vector3(-0.02f, -2.1f, -4.24f);
        }

        if ((timer >= 100)&&(flag == false))
        {
            flag = true;
            camera.transform.position = new Vector3(0, 55.26f, -10f);
            StartCoroutine(FadeOut(GameObject.Find("redbg")));
        }
    }

    public IEnumerator FadeOut(GameObject obj)
    {
        for (float i = 1f; i >= 0f; i -= 0.005f)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, 0f);
        yield return StartCoroutine(wait(3f));
        yield return StartCoroutine(FadeIn(GameObject.Find("Hints")));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeIn(GameObject.Find("Text")));
    }

    IEnumerator FadeIn(GameObject obj)
    {
        for (float i = 0f; i <= 1f; i += 0.05f)
        {
            obj.GetComponent<Text>().color = new Color(222f, 222f, 222f, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<Text>().color = new Color(222f, 222f, 222f, 1f);
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void Death()
    {
        //Make statue animator's "scare" trigger
        //Statue shows up right in your face, mouth appears, etc
    }
}
