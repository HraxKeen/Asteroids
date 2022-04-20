using UnityEngine;
using System.Collections;
 
public class ShipController : MonoBehaviour {
 
    [SerializeField] float thrust = 2f;
    [SerializeField] float momentum = 2f;
    [SerializeField] float maxVelocity = 1.0f;
    [SerializeField] float maxAngularVelocity = 20.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float thrustInput = Input.GetAxis("Vertical");
        if (thrustInput > 0)
            rb.AddForce(transform.up * thrust * thrustInput);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);

        float rotateInput = -Input.GetAxis("Horizontal");
        if (Mathf.Abs(rb.angularVelocity) < maxAngularVelocity)
        {
            rb.AddTorque(rotateInput * momentum);
        } else {
            rb.angularVelocity = Mathf.Clamp(
                rb.angularVelocity,
                -maxAngularVelocity,
                maxAngularVelocity);
        }
    }

}