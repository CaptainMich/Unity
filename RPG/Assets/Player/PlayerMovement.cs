using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public GameObject backSword;
    public GameObject backShield;
    public GameObject handSword;
    public GameObject handShield;
    public static bool combatMode;

    public Rigidbody rb;
    public CapsuleCollider col;
    private float inputH;
    private float inputV;
    public float speed;
    private float w_speed = 0.05f;
    private float r_speed = 0.2f;
    private float c_speed = 0.025f;
    public float rotSpeed;
    public float jumpHeight;
    private bool isGrounded;
    private bool isRunning;
    private bool isJumping;
    private bool isCrouching;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        handSword.SetActive(false);
        handShield.SetActive(false);
        combatMode = false;
        isGrounded = true;
        isCrouching = false;
        isRunning = false;
        isJumping = false; 
    }

    // Update is called once per frame
    void Update()
    {
        speed = w_speed;

        // check if the player is running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isRunning)
            {
                isRunning = true;
                anim.SetBool("run", isRunning);                
            }
            speed = r_speed;
        }
        else
        {
            isRunning = false;
            anim.SetBool("run", isRunning);

        }


        // check if the player is jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            anim.SetBool("jump", isJumping);
            rb.AddForce(0, jumpHeight, 0);
            isCrouching = false;
            isGrounded = false;
        }
        else
        {
            isJumping = false;
            anim.SetBool("jump", isJumping);
            rb.AddForce(0, -jumpHeight, 0);
            isGrounded = true;
        }

        // check if the player is crouching
        if (Input.GetKey(KeyCode.C))
        {
            isCrouching = true;
            anim.SetBool("crouch", isCrouching);
            speed = c_speed;
            col.height = 1;
            col.center = new Vector3(0, 0.5f, 0);
        }
        else
        {
            isCrouching = false;
            anim.SetBool("crouch", isCrouching);
            col.height = 2;
            col.center = new Vector3(0, 1, 0);
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        float inputMouseH = Input.GetAxis("Mouse X");
        float inputMouseV = Input.GetAxis("Mouse Y");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
       
        float moveY = inputH * rotSpeed;
        float moveZ = inputV * speed;

        transform.Translate(0, 0, moveZ);
        transform.Rotate(0, moveY, 0);


        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Press R");
            anim.Play("2W_weapons_ready", -1, 0f);
            if (!combatMode)
            {
                StartCoroutine(FromBackToHand());
            }

            if (combatMode)
            {
                StartCoroutine(FromHandToBack());
            }
        }

        if (combatMode)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (isJumping)
                {
                    print("Press Mouse Button Left and Jump");
                    anim.Play("1H_Jump_Swing", -1, 0f);
                }
                else
                {
                    print("Press Mouse Button Left");
                    anim.Play("1H_Heavy_Smash", -1, 0f);
                }
            }
        }
    }

    IEnumerator FromBackToHand()
    {
        if (backShield.activeSelf && backSword.activeSelf)
        {
            backShield.SetActive(false);
            backSword.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            handShield.SetActive(true);
            handSword.SetActive(true);

            combatMode = true;
        }
    }

    IEnumerator FromHandToBack()
    {
        if (handShield.activeSelf && handSword.activeSelf)
        {
            handShield.SetActive(false);
            handSword.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            backShield.SetActive(true);
            backSword.SetActive(true);

            yield return new WaitForSeconds(1.3f);
            anim.Play("IDLE", -1, 0f);

            combatMode = false;
        }
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
