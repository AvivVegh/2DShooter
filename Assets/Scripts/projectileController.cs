using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {

	Rigidbody2D myRB;
	public float rocketSpeed;

	void Awake()
	{
		myRB = GetComponent<Rigidbody2D> ();

		// if facing left fly left 
		if (transform.localRotation.z > 0) 
		{
			myRB.AddForce (new Vector2 (-1, 0) * rocketSpeed, ForceMode2D.Impulse);
		}
		else // if facing right fly right
		{
			myRB.AddForce (new Vector2 (1, 0) * rocketSpeed, ForceMode2D.Impulse);
		}

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void removeForce()
	{
		myRB.velocity = new Vector2 (0, 0);
	}
}
