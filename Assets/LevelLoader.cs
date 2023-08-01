using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator anim;
    public float transitiontime = 3f;
    // Start is called before the first frame update
 

    

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelindex)
    {
        anim.SetTrigger("start");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(levelindex);
    }
}
