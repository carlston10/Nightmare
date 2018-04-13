using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerNew : MonoBehaviour
{
	public PlayerHealthNew playerHealthNew;       
	public GameObject enemy;                
	public float spawnTime = 3f;           
	public Transform[] spawnPoints;         


	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{
		if(playerHealthNew.currentHealth <= 0f)
		{
			return;
		}
			
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}