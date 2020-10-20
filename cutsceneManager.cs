using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BlackScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("busStop"))
        {
            StartCoroutine(FadeOut(BlackScreen));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeIn(GameObject obj)
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
    }

    public IEnumerator FadeOut(GameObject obj)
    {
        for (float i = 1f; i >= 0f; i -= 0.01f)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(0.01f);
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
    }


}
