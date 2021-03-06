﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealthNew : MonoBehaviour
{
	public int startingHealth = 100;                            
	public int currentHealth;                                   
	public Slider healthSlider;                                 
	public Image damageImage;                                   
	public AudioClip deathClip;                                 
	public float flashSpeed = 5f;                               
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);    
	bool gameHasEnded = false;
	public float restartDelay = 5f;

	Animator anim;                                              
	AudioSource playerAudio;                                    
	PlayerMovementNew playerMovementNew;                            
	PlayerShootingNew playerShootingNew;                            
	bool isDead;                                                
	bool damaged;                                               


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		playerMovementNew = GetComponent <PlayerMovementNew> ();
		playerShootingNew = GetComponentInChildren <PlayerShootingNew> ();

		currentHealth = startingHealth;
	}

	public void EndGame()
	{
		if (gameHasEnded == false) {
			gameHasEnded = true;
			Invoke ("RestartScene", restartDelay);
		} 
	}


	void Update ()
	{
		
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
			
		damaged = false;
	}


	public void TakeDamage (int amount)
	{

		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		playerAudio.Play ();

		if(currentHealth <= 0 && !isDead)
		{

			Death ();
		}
	}


	void Death ()
	{

		isDead = true;

		playerShootingNew.DisableEffects ();
	
		anim.SetTrigger ("Die");

		playerAudio.clip = deathClip;
		playerAudio.Play ();

		playerMovementNew.enabled = false;
		playerShootingNew.enabled = false;

		EndGame ();
	}       

	void RestartScene()
	{
		Scene thisScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene(thisScene.name);
	}



}



