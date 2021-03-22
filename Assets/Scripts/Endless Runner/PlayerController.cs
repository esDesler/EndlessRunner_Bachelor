using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;

    public float jumpForce;
    public float gravityStrength;

    private Rigidbody myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public LayerMask whatIsObstacle;

    private Animator myAnimator;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();

        Vector3 gravityS = new Vector3(0, gravityStrength, 0);
        Physics.gravity = gravityS;

        moveSpeedStore = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, moveSpeed);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpForce, myRigidbody.velocity.z);
            grounded = false;

            // Play jump sound
            jumpSound.Play();
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.z);
        myAnimator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (1 << collision.gameObject.layer == whatIsGround)
        {
            grounded = true;
        }
    }

    // If the speed increases
    public void RestartPlayer()
    {
        moveSpeed = moveSpeedStore;
    }
}
