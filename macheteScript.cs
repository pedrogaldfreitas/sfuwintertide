using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macheteScript : MonoBehaviour
{
    [SerializeField]
    private Animator macheteAnimator;
    public bool isAttacking; //boolean to determine when machete is playing its animation(attacking)

    void Start()
    {
        isAttacking = false;
    }

    void Update()
    {
            //Debug.Log(isAttacking);
        if (macheteAnimator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
        {
            isAttacking = true;

        }
        else
        {
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) //Also include the condition that the machete is equipped
        {
            StartCoroutine(MouseClick(0.2f));
        }

    }

    IEnumerator MouseClick(float time)
    {
        macheteAnimator.SetTrigger("Click");
        yield return new WaitForSeconds(time);
    }


}
