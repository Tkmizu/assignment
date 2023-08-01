using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Froggo_Chasing : MonoBehaviour
{
    public Transform player;
    private bool isChasing;
    public float chaseDistence;
    public float speed = 5f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isChasing)
        {
            anim.SetBool("run", true);
            
            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(6f, 6f, 6f);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(-6f, 6f, 6f);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) < chaseDistence)
            {
                isChasing = true;
            }
        }
    }
}
