using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public AudioClip shoot;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        // Has a bullet been fired
        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            ShootBullet();   
        }
    }
    void ShootBullet()
    {
 
        // Spawn a bullet
        Instantiate(bullet,new Vector3(transform.position.x,transform.position.y, 0),transform.rotation);
 
        // Play a shoot sound
        AudioSource.PlayClipAtPoint (shoot, Camera.main.transform.position);
    }
}
