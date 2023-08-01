using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    
    private float attackRate = 2f;
    private float nextTimeAttack = 0f;
    private Animator anim;
    private PlayerMovement playerMovement;
    public GameObject bullet;
    public Transform firepoint;
    public AudioSource shoot;
    public int bulletammo = 100;

    private Text text;

    // Start is called before the first frame update

    void Start()
    {

        text = GameObject.FindWithTag("BulletAmmo").GetComponent<Text>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame

    private void Update()
    {
        if (Time.time >= nextTimeAttack)
        {
            if (Input.GetKey(KeyCode.F) && playerMovement.driX == 0)
            {

                if (bulletammo <= 0)
                {
                    text.text = "Out of Ammo";
                }
                else
                {
                    shoot.Play();
                    Attack();
                    nextTimeAttack = Time.time + 1f / attackRate;
                    bulletammo--;

                    text.text = bulletammo + "/100";
                }
            }
            

        }

        
    }

   

    private void Attack()
    {
        float angle = playerMovement.isFacingRight ? 0f : 180f;
        Instantiate(bullet, firepoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        anim.SetTrigger("attack");
        
       
    }


}
