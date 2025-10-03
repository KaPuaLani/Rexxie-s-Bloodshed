using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //store the players health
    public float health = 20;
    float maxHealth;
    public Image healthBar;
    //if we collide with something tagged as enemy, take damage
    //if health gets too low, we die (reload the level)
    //if we collide with something tagged health pack, increase health
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                //if health is to low, reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (collision.gameObject.tag == "Boss")
        {
            health -= 5;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                //if health is to low, reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        //if we collide with the health pack collectable
        if (collision.gameObject.tag == "Soul")
        {
            //increase the health value
            health += 2;
            healthBar.fillAmount = health / maxHealth;
            Destroy(collision.gameObject);
            //if our health is trying to exceed our max health
            if (health >= maxHealth)
            {
                //cap our health at max health
                health = maxHealth;
            }
        }
        if (collision.gameObject.tag == "HATEFULSoul")
        {
            //increase the health value
            health += 6;
            healthBar.fillAmount = health / maxHealth;
            Destroy(collision.gameObject);
            //if our health is trying to exceed our max health
            if (health >= maxHealth)
            {
                //cap our health at max health
                health = maxHealth;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
