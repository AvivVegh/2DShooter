using UnityEngine;
using System.Collections;

public class healthPickUp : MonoBehaviour {

	public float healthAmount; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			playerHealth theHealth = other.gameObject.GetComponent<playerHealth> ();
			theHealth.addHealth (healthAmount);

			Destroy (gameObject);
		}
	}

}
