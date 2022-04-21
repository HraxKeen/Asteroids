using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : MonoBehaviour
{
    public AudioClip destroy;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject =
            GameObject.FindWithTag ("GameController");
 
        gameController =
            gameControllerObject.GetComponent <GameController>();

        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * Random.Range(-30.0f, 150.0f));
 
        GetComponent<Rigidbody2D>()
            .angularVelocity = Random.Range(-0.0f, 90.0f);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Bullet")) 
        {
            //Destroy bullet
            Destroy (collision.gameObject);

            //If bullet hits large asteroid
            if (tag.Equals ("Small Asteroid")) 
            {
                gameController.IncrementScore();

                AudioSource.PlayClipAtPoint(
                destroy, Camera.main.transform.position);
            }
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
