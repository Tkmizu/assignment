
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;



	public bool isInvulnerable = false;

	private Animator anim;

    private void Start()
    {
		anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		anim.SetTrigger("ded");
		
	}

}
