using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroys bullet after 1sec
        Destroy (gameObject, 1.0f);

        //Pushes bullet in direction it is facing
        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * 400);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
