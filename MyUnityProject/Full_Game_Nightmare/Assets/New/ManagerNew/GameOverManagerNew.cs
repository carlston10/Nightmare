using UnityEngine;

public class GameOverManagerNew : MonoBehaviour
{
	public PlayerHealthNew playerHealthNew;

	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (playerHealthNew.currentHealth <= 0)
		{
			anim.SetTrigger("GameOver");
		}
	}
		
}
