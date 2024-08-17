using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    [Header("Set In Inspector")]
    
    public float health = 100;
    //  public HealthBar healthBar;
   // [SerializeField]
   // Slider slider;
    public GameObject[] stars;
    public GameObject MenuGO;
    public GameObject MenuGW;
    public AudioSource source;
    public Sprite doneIce;
    public GameObject iceCream;
    public Button BUTTOSmove;
    

    private void Start()
    {
        //healthBar.MaxHealth = maxHealth;
        //   healthBar.Health = health;
        // slider.value = health;
        iceCream = GameObject.FindGameObjectWithTag("icecream");
        MenuGO.SetActive(false);
        MenuGW.SetActive(false);

    }

    private void Update()
    {
        if (health <= 35)
        {
            
            iceCream.GetComponent<Image>().sprite = doneIce;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Enemy>();
            TakeDamage(Time.deltaTime * enemy.damagePerSecond);
        }

    }

   

    private void TakeDamage(float damage)
    {
        health -= damage;
      

       

        if (health <= 0)
        {
            MenuGO.SetActive(true);
            Time.timeScale = 0f;
        }
        else
            Time.timeScale = 1f;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Trap"))
        {
            MenuGO.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            MenuGO.SetActive(false);
            Time.timeScale = 1f;
        }

            if (collision.CompareTag("won"))
        {

            source.Play();
            MenuGW.SetActive(true);
            BUTTOSmove.interactable = false;

            Time.timeScale = 0f;


            if (health <= 35) {
                stars[0].SetActive(true);


            }
            else
                 if (health < 80)
            {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
            }
            else
                 if (health >= 80)
            {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);
            }



        }

        
        

    }


}
