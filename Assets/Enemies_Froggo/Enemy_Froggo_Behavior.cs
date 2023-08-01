using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Froggo_Behavior : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float speed = 2;
    public int patrolDestination;
    private Animator anim;

  
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("run", true);

       
        if (patrolDestination == 0)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, patrolpoints[0].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolpoints[0].position) < .2f)
            {
                transform.localScale = new Vector3(6, 6, 6);
                patrolDestination = 1;
                
            }
        }

        if (patrolDestination == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolpoints[1].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolpoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(-6, 6, 6);
                patrolDestination = 0;
            }
        }

        
    }

   
}
