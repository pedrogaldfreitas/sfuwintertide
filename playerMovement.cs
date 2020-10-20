using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private CapsuleCollider PlayerCollider;
    private Rigidbody rb;
    private float playerHeight;
    private float playerCenterY;
    private bool playerCrouched; //returns if player is crouched
    private float iniSpeed; //Determines initial set speed "0.095f"
    [SerializeField]public bool isSprinting;//This bool determines if the player is sprinting or not
    public bool canSprint; //This bool determines if the player can sprint or not
    [Range(0f, 0.01f)] [SerializeField] private float acc; //Player acceleration
    [Range(0f, 2f)] [SerializeField] private float sprintSpeed; /// <summary>Top Speed of Player</summary>

    [SerializeField]
    private Animator playerMovementAnim;


    // Start is called before the first frame update
    void Awake()
    {
        //canSprint = false;
        rb = GetComponent<Rigidbody>();
        PlayerCollider = this.gameObject.GetComponent<CapsuleCollider>();


        //Determines if player is crouched or not
        playerCrouched = false;

        /* When Crouching you need to reduce the Collider Height(CH), as well as,
         * reduce the Center.y by the same amount as the CH*/
        playerHeight = PlayerCollider.height;
        playerCenterY = PlayerCollider.center.y;

        iniSpeed = speed;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();

        if (!canSprint) return;//Checks if the player canSprint before calling the sprint function
        Sprint(iniSpeed, sprintSpeed, acc);

    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + move * speed);

        playerMovementAnim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        playerMovementAnim.SetFloat("Vertical", Input.GetAxis("Vertical"));

    }
    /// <summary>
    /// Determines when the Shift button is held down
    /// </summary>
    private void Sprint(float _iniSpeed, float _sprintSpeed, float _acc)
    {
        var _isAttacking = GameObject.Find("Inventory").GetComponent<Inventory>().isAttacking;
        if (_isAttacking) return;
        if (speed < 1.5f) isSprinting = false; else if (speed > 1.5f){ isSprinting = true; }
        if (!Input.GetKey(KeyCode.LeftShift) && (speed > _iniSpeed)){ speed -= _acc * 3f; return; }
        if (speed >= _sprintSpeed) return;//Checks if speed has been applied
        speed += acc;
        //if (speed > 0.2f) isSprinting = true;

    }

    private void Crouch()
    {
        //Variable for the speed of the crouching
        float speedOfCrouch = 0.01f;



        //For Crouching
        if (Input.GetKey(KeyCode.LeftControl) && !playerCrouched)
        {

            for (; playerHeight > 1f; playerHeight -= speedOfCrouch)
            {
                playerCenterY -= speedOfCrouch;
                //yield return new WaitForSeconds(0.01f);
            }
        }

        //For Standing Up
        else
        {
            for (; playerHeight < 2f; playerHeight += speedOfCrouch)
            {
                playerCenterY += speedOfCrouch;
                //yield return new WaitForSeconds(0.01f);
            }
        }
    }
    
}
