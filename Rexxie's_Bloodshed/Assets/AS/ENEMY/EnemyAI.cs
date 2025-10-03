using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    GameObject player;
    //the speed at which the enemy will move
    public float chasespeed = 4.0f;
    //how close the player needs to be for the enemy to start chasing
    public float chaseTriggerDistance = 10f;
    //do we want the enemy to return home when the player gets away?
    public bool returnHome = true;
    Vector3 home;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //figure out where the player is, how far away they are
        //how far away is the player from me, the enemy???
        //destination (player position) - startong position (enemy position)
        Vector3 chaseDir = player.transform.position - transform.position;
        //if the player is "close", chase the player
        if (chaseDir.magnitude < chaseTriggerDistance)
        {
            //chase the player!
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chasespeed;
        }
        //if the returnhome variable is true, try to go home
        else if (returnHome)
        {
            //return home
            Vector3 homeDIr = home - transform.position;
            if(homeDIr.magnitude > 0.2)
            {
                //go towars home
                homeDIr.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDIr * chasespeed;
            }
            //if we're close to home
            else
            {
                //stop moving, so we don't twitch like crazy
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

        }
        //otherwise, stop moving
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
