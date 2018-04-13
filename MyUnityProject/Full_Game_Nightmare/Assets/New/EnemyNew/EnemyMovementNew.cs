using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovementNew : MonoBehaviour
{
	Transform player;               
	PlayerHealthNew playerHealthNew;      
	EnemyHealthNew enemyHealthNew;       
	NavMeshAgent nav;              

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealthNew = player.GetComponent <PlayerHealthNew> ();
		enemyHealthNew = GetComponent <EnemyHealthNew> ();
		nav = GetComponent <NavMeshAgent> ();
	}


	void Update ()
	{
		if(enemyHealthNew.currentHealth > 0 && playerHealthNew.currentHealth > 0)
		{
			nav.SetDestination (player.position);
		}

		else
		{
			nav.enabled = false;
		}
	} 
}