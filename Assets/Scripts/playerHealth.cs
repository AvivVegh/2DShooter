using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

	public float fullHealth;
	public GameObject deathFX;
	public AudioClip playerDeathSound;

	private float currentHealth; 

	private playerController controlMovment; 

	// HUB Variables
	public Slider healthSlider; 
	public Image damageScreen;

	// Init audio src
	public AudioClip playerHurt;

	private AudioSource playerSrc;

	private bool damaged = false;
	private Color damagedColour = new Color(0f,0f,0f,0.5f);
	private float smoothColour = 5f;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovment = GetComponent<playerController> ();

		// HUD Intiliazation
		healthSlider.maxValue = fullHealth; 
		healthSlider.value = fullHealth;

		//Init audio
		playerSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (damaged) 
		{
			damageScreen.color = damagedColour;
		}
		else 
		{
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
		}

		damaged = false;
	}

	public void addDamage(float damage)
	{
		if (damage <= 0) 
		{
			return;
		}

		currentHealth -= damage;

		playerSrc.clip = playerHurt;
		playerSrc.Play ();

		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0) 
		{
			makeDead ();
		}
	}

	public void addHealth(float healthAmount)
	{
		currentHealth += healthAmount;

		if (currentHealth > fullHealth) 
		{
			currentHealth = fullHealth;
		}

		healthSlider.value = currentHealth;

	}

	public void makeDead()
	{

		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
	
		SceneManager.LoadScene (1);

	}
}
