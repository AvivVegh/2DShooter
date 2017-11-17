using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	// Movment variables 
	public float maxSpeed; 
	Rigidbody2D myRB;
	Animator myAnim;

	bool facingRight;

	// Juming variables 
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	//for shooting
	public Transform gunTip;
	public GameObject builet;
	float fireRate = 0.5f;
	float nextFire = 0f;

	// Use this for initialization
	void Start () 
	{
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		facingRight = true;
	}
	// Update is called every frame
	void Update()
	{
		if (grounded && Input.GetAxis ("Jump") > 0) 
		{
			grounded = false;
			myAnim.SetBool ("isGrounded", grounded);
			myRB.AddForce (new Vector2 (0, jumpHeight));
		}

		// Player shooting
		if (Input.GetAxisRaw ("Fire1") > 0) 
		{
			fireRocket ();
		}
	}

	// Update is called every millisecond~
	void FixedUpdate () 
	{
		// Check if we are grounded --> if we are falling
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
		myAnim.SetBool ("isGrounded", grounded);

		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y);

		float move = 0;
		move = Input.GetAxis ("Horizontal");	

		myAnim.SetFloat ("speed", Mathf.Abs(move));

		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);

		// if move right
		if (move > 0 && !facingRight) 
		{	
			flip ();
		}
		else if (move < 0 && facingRight)
		{
			flip ();
		}
	}

	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;

		// Flipping the player
		theScale.x *= -1; 
		transform.localScale = theScale;
	}

	void fireRocket()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;

			if (facingRight) 
			{
				Instantiate (builet, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			}
			else if (!facingRight) 
			{
				Instantiate (builet, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		}
	}
}

