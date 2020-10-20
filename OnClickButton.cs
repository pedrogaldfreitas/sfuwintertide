using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClickButton : MonoBehaviour
{



    public void OnClickMainScreenButton()
    {
        StartCoroutine(actualFunction());        
    }

    IEnumerator actualFunction()
    {
        StartCoroutine(FadeOut(GameObject.Find("quadrangle")));
        StartCoroutine(FadeOut(GameObject.Find("sfu logo")));
        StartCoroutine(FadeOut(GameObject.Find("title")));
        yield return StartCoroutine(FadeOutButton(GameObject.Find("Button")));

        SceneManager.LoadScene("busStop");
    }

    IEnumerator FadeOut(GameObject obj)
    {
        for (float i = 1f; i >= 0f; i -= 0.007f)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, 0f);
    }

    IEnumerator FadeOutButton(GameObject obj)
    {
        for (float i = 1f; i >= 0f; i -= 0.007f)
        {
            obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, 0f);
    }

}
