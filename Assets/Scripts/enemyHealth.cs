using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth; 
	public GameObject enemyDeathFX;
	public Slider enemySlider;
	public bool drops;
	public GameObject theDrop; 

	public AudioClip deathKnell;

	private float currentHealth; 

	// Use this for initialization
	void Start () {
	
		currentHealth = enemyMaxHealth;
		enemySlider.maxValue = currentHealth;
		enemySlider.value = currentHealth;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addDamage(float damage)
	{
		enemySlider.gameObject.SetActive (true);
		currentHealth -= damage;
		enemySlider.value = currentHealth;

		if (currentHealth <= 0) 
		{
			makeDead ();
		}

	}

	void makeDead ()
	{
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(deathKnell, transform.position);
		Instantiate (enemyDeathFX, transform.position, transform.rotation);

		if (drops) 
		{
			Instantiate (theDrop, transform.position, transform.rotation);
		}
	}
}
