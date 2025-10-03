using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Echancekill : MonoBehaviour
{
    //store the Enemys health
    public float Enemyhealth = 15;
    float Enemymax;
    //the thing we want to drop
    public GameObject prefab;
    public int dropChance = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Nbullet")
        {
            Enemyhealth--;
            if (Enemyhealth <= 0)
            {
                //see if we should drop an item
                //max is exclsive for random.range of ints
                int r = Random.Range(1, 101); // possible outcomes range of 1-100 = 1-99, possible outcomes range of 1-101 = 1-100
                if (dropChance >= r)
                {
                    //drop the item
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Hbullet")
        {
            Enemyhealth -= 2;
            if (Enemyhealth <= 0)
            {
                //see if we should drop an item
                //max is exclsive for random.range of ints
                int r = Random.Range(1, 101); // possible outcomes range of 1-100 = 1-99, possible outcomes range of 1-101 = 1-100
                if (dropChance >= r)
                {
                    //drop the item
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Enemymax = Enemyhealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
