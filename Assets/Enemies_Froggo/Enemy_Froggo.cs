using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy_Froggo : MonoBehaviour
{
    // Start is called before the first frame update

    public float health = 100;
    public GameObject deatheffect;
    public GameObject deadsounds;
    static private int killcount = 0;
    private bool isdead = false;

  public void TakeDamage(float damage)
    {
        
        health -= damage;
        isdead = false;
        if(health <= 0)
        {
            
            Die();


          
        }
    }

   



    void Die()
    {
        isdead = true;
        GameObject effect = Instantiate(deatheffect, transform.position, Quaternion.identity);
        Instantiate(deadsounds, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1f);
        killcount++;
        Debug.Log("Kill: " + killcount);
        
    }

   


}
