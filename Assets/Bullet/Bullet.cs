using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed = 14f;
    public int damage = 50;
    public Rigidbody2D rb;
    public GameObject onhit;
    public int timerboom = 2;



    // Start is called before the first frame update


    // Update is called once per frame


 
    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletspeed;

       
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
     
        Enemy_Froggo enemy = collision.GetComponent<Enemy_Froggo>();
        BossHealth boss = collision.GetComponent<BossHealth>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if(boss != null)
        {
            boss.TakeDamage(damage);
        }



        GameObject effect = Instantiate(onhit, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.5f);

       
    }

   





}









