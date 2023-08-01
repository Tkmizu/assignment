using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public Text chirumirutext;
    private int chirumiru = 0;
    public AudioSource sounds;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("chirumiru"))
        {
            sounds.Play();
            Destroy(collision.gameObject);
            chirumiru++;
            chirumirutext.text = "" + chirumiru;
        }
    }
}
