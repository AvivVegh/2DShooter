using UnityEngine;
using System.Collections;

public class ninjaDamage : MonoBehaviour {

	public float damage;
	public float damageRate;
	public float pushBackForce;

	private Animator enemyAnimator;

	float nextDamage;

	// Use this for initialization
	void Start () 
	{
		nextDamage = 0f;
		enemyAnimator = GetComponentInChildren<Animator> ();

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other)
	{
//		if (other.tag == "Player" && nextDamage < Time.time) 
//		{
//			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
//			thePlayerHealth.addDamage (damage);
//			nextDamage = Time.time + damageRate;
//
//			pushBack (other.transform);
//		}

		if (enemyAnimator.GetBool("isCharging") && other.tag == "Player" && nextDamage < Time.time) 
		{
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
			nextDamage = Time.time + damageRate;

			pushBack (other.transform);
		}


	}

	void pushBack(Transform pushObject)
	{
		Vector2 pushDirection = new Vector2 (0, (pushObject.position.y - transform.position.y)).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}
