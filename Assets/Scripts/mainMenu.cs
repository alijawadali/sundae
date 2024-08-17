using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    int levelIsUN;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        int levelAT = PlayerPrefs.GetInt("levelAT", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 > levelAT)
            {
                buttons[i].interactable = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //nice
    public void exit()
    {
        Debug.Log("Done");
        Application.Quit();
    }
    public void restlevels()
    {
        PlayerPrefs.DeleteAll();
    }

    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);

    }
}
