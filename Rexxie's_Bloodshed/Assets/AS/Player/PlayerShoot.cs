using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public float shootSpeed = 10f;
    public float bulletLifetime = 2.0f;
    public float shootDelay = 0.5f;
    float timer = 0;
    int souls = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int tempSouls = FindObjectOfType<Collectables>().souls;
        if (tempSouls > souls)
        {
            shootSpeed += 1;
            shootDelay -= (float)0.2;
            souls = tempSouls;

        }
        
        //time slivers of time that passes between frame updates
        //0.016666 if 60f/second
        timer += Time.deltaTime;
        //IF we press the "shoot button" (left click)
        //GetButtonDown = click fire, GetButton = hold fire
        if(Input.GetButton("Fire1") && timer > shootDelay)
        {
            timer = 0;
            //get the mouse's position in the game
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            mousePos.z = 0;
            //spawn in a bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet towards the mouse position
            //destination (mousePosition) - starting position (my current posistion)
            Vector3 mouseDir = mousePos - transform.position;
            mouseDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * shootSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}
