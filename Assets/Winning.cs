using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public GameObject winning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winningScence()
    {
        winning.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
