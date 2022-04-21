using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus : MonoBehaviour 
{

 
    // Update is called once per frame
    void Update () {
 
        // Teleport the game object
        if(transform.position.x > 16){
            transform.position = new Vector3(-16, transform.position.y, 0);
 
        }
        else if(transform.position.x < -16){
            transform.position = new Vector3(16, transform.position.y, 0);
        }
 
        else if(transform.position.y > 9){
            transform.position = new Vector3(transform.position.x, -9, 0);
        }
 
        else if(transform.position.y < -9){
            transform.position = new Vector3(transform.position.x, 9, 0);
        }
    }
}
