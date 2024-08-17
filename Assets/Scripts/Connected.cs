using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connected : MonoBehaviour
{
    public bool clientConnected;
    public GameObject NOwifi_;
    bool isConnected()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
            
        }

        else return true;
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
         clientConnected = isConnected();

        if (clientConnected == false)
        {
            NOwifi_.SetActive(true);
            Time.timeScale = 0f;


        }
        else
        {
            NOwifi_.SetActive(false);
            Time.timeScale = 1f;
        }
        }
}
