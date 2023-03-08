using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHel : MonoBehaviour
{
	public float maxHealth = 100f;
	public float currentHealth;
	
	public HealthBar healthBar;
	[SerializeField] GameObject gun;


	void Start()
	{
		currentHealth = 50f;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{	
		// if (currentHealth >= 100) HealthPick.healthPick.GetComponent<SphereCollider>().enabled = false;
		// else HealthPick.healthPick.canPickHealth = true;

		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
		{	
			SceneManager.LoadScene("MainScene");
		}
	}

}
