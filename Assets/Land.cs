using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    // Start is called before the first frame update

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + ": Trigger");

        if (collision.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject);

            // disapear muc tieu


        }

        



    }
}

