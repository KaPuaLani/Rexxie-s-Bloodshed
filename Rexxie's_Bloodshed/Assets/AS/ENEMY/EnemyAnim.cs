using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = GetComponent<Rigidbody2D>().velocity.x;
        float y = GetComponent<Rigidbody2D>().velocity.y;
        //tell the animator component the value for x, and y
        GetComponent<Animator>().SetFloat("x", x);
        GetComponent<Animator>().SetFloat("y", y);
    }
}
