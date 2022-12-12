using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;

	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;

	private Rigidbody2D myRigidBody;
	private CapsuleCollider2D myCollider;
	private Animator myAnimator;

	public bool grounded;
	public bool sliding;

	public LayerMask isItGrounded;

    // Start is called before the first frame update
    void Start()
    {
		myRigidBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<CapsuleCollider2D>();
		myAnimator = GetComponent<Animator>();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
	}

    // Update is called once per frame
    void Update()
    {
		grounded = Physics2D.IsTouchingLayers(myCollider, isItGrounded);
		CharMovement();
	}

	void CharMovement()
	{
		if(transform.position.x > speedMilestoneCount)
		{
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			speed = speed * speedMultiplier;
		}

		myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
			}
		}

		if (Input.GetKey(KeyCode.Space))
		{
			if(jumpTimeCounter > 0)
			{
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			jumpTimeCounter = 0;
		}
		if (grounded)
		{
			jumpTimeCounter = jumpTime;
		}

		if (Input.GetKey(KeyCode.S))
		{
			myAnimator.SetBool("isSliding", true);
			gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
			gameObject.GetComponent<CircleCollider2D>().enabled = true;
		}
		else
		{
			myAnimator.SetBool("isSliding", false);
			gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
		}
		myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
		myAnimator.SetBool("isGrounded", grounded);
	}
}
