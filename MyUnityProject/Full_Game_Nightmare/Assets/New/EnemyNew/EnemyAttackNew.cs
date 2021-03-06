﻿using UnityEngine;
using System.Collections;


public class EnemyAttackNew : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     
	public int attackDamage = 10;               


	Animator anim;                              
	GameObject player;                          
	PlayerHealthNew playerHealthNew;                  
	EnemyHealthNew enemyHealthNew;                    
	bool playerInRange;                        
	float timer;                                


	void Awake ()
	{
		
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealthNew = player.GetComponent <PlayerHealthNew> ();
		enemyHealthNew = GetComponent<EnemyHealthNew>();
		anim = GetComponent <Animator> ();
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}


	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange && enemyHealthNew.currentHealth > 0)
		{
			Attack ();
		}
			
		if(playerHealthNew.currentHealth <= 0)
		{
			anim.SetTrigger ("PlayerDead");
		}
	}


	void Attack ()
	{
		timer = 0f;

		if(playerHealthNew.currentHealth > 0)
		{
			playerHealthNew.TakeDamage (attackDamage);
		}
	}
}