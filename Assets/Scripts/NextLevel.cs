using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int nextlevel;

   
  
  


    // Start is called before the first frame update
    void Start()
    {
       

        nextlevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void next()
    {

        
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            Debug.Log("you win (thr end )");
        }
        else
        {
            
            SceneManager.LoadScene(nextlevel); 

            if (nextlevel > PlayerPrefs.GetInt("levelAT"))
            {
                PlayerPrefs.SetInt("levelAT", nextlevel);
            }
        }
    }
}
