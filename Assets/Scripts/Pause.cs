using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public GameObject PuasePanl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause()
    {
        PuasePanl.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Offpause()
    {
        PuasePanl.SetActive(false);
        Time.timeScale = 1f;

    }
    public void ResetStart() 
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }
    public void BackMneu()
    {
        SceneManager.LoadScene("MainMenu");
        Offpause();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
