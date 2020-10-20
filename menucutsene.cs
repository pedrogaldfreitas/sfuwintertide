using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menucutsene : MonoBehaviour
{
    [SerializeField]
    GameObject playbutton;
    [SerializeField]
    GameObject title;
    [SerializeField]
    GameObject sfu;
    [SerializeField]
    GameObject ournames;

    private void Start()
    {
        title.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 1f);
        sfu.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 1f);
        ournames.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 1f);
        playbutton.GetComponent<Image>().color -= new Color(0f, 0f, 0f, 1f);
        playbutton.SetActive(false);
        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        yield return StartCoroutine(FadeIn(ournames));
        yield return StartCoroutine(wait(3f));
        yield return StartCoroutine(FadeOut(ournames));
        yield return StartCoroutine(wait(2f));
        yield return StartCoroutine(FadeIn(sfu));
        yield return StartCoroutine(wait(1f));
        yield return StartCoroutine(FadeIn(title));
        yield return StartCoroutine(wait(1f));
        playbutton.SetActive(true);
        yield return StartCoroutine(FadeInButton(playbutton));

    }

    IEnumerator FadeIn(GameObject obj)
    {
        for (float i = 0f; i <= 1f; i += 0.007f)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(obj.GetComponent<SpriteRenderer>().color.r, obj.GetComponent<SpriteRenderer>().color.g, obj.GetComponent<SpriteRenderer>().color.b, 1f);
    }

    IEnumerator FadeInButton(GameObject obj)
    {
        for (float i = 0f; i <= 1f; i += 0.007f)
        {
            obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, 1f);
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

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

}
