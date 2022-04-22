using UnityEngine;
using System.Collections;
 
public class AsteroidController : MonoBehaviour 
{
    public ParticleSystem explosion;
    public AudioClip destroy;
    public GameObject smallAsteroid;
 
    private GameController gameController;
 
    // Use this for initialization
    void Start () 
    {
 
        // Get a reference to the game controller object and the script
        GameObject gameControllerObject =
            GameObject.FindWithTag ("GameController");
 
        gameController =
            gameControllerObject.GetComponent <GameController>();
 
        // Push the asteroid in the direction it is facing
        GetComponent<Rigidbody2D>()
            .AddForce(transform.up * Random.Range(-50.0f, 150.0f));
 
        // Give a random angular velocity/rotation
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
            if (tag.Equals ("Large Asteroid")) 
            {
                //Spawns small asteroids
                Explosion();
                CreateSplit();
                

                gameController.SplitAsteroid ();
            }
            else
            {
                gameController.DecrementAsteroids();
            }
            AudioSource.PlayClipAtPoint(
                destroy, Camera.main.transform.position);
 
            gameController.IncrementScore();

            Destroy (gameObject);
        }
        
 
    }
    private void CreateSplit()
    {
        //Spawn small asteroid
        Instantiate (smallAsteroid,
            new Vector3 (transform.position.x - .5f,
                transform.position.y - .5f, 0),
                Quaternion.Euler (0, 0, 90));
        
        Instantiate (smallAsteroid,
            new Vector3 (transform.position.x + .5f,
                transform.position.y + .0f, 0),
                Quaternion.Euler (0, 0, 0));
        
        Instantiate (smallAsteroid,
            new Vector3 (transform.position.x + .5f,
                transform.position.y - .5f, 0),
                Quaternion.Euler (0, 0, 270));
    }
    void Explosion()
    {
        explosion.Play();
    }
} 
