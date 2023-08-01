using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int maxHealth = 100;
    private Animator anim;
    private bool dead;
    public AudioSource[] sounds;
    private Rigidbody2D rb;

    public HealthBar healthBar;


    [Header("iFrames")]
    public float iFramesDuration;
    public int numberofFlashes;
    private SpriteRenderer spriteRenderer;
    public GameOver gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
   public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health > 0)
        {
            sounds[0].Play();
            anim.SetTrigger("hit");
          
          
            StartCoroutine(CantHurt());
            
        }
        else
        {
            if (!dead)
            {
                sounds[1].Play();
                anim.SetTrigger("dead");
                rb.bodyType = RigidbodyType2D.Static;
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PlayerAttack>().enabled = false;
                dead = true;
                gameOver.gameover();
            }
            
        }
    }

    private IEnumerator CantHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 6, true);
        for(int i = 0; i < numberofFlashes; i++)
        {
            spriteRenderer.color = new Color(255, 0, 0, 255);
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(7, 6, false);
    }
}
