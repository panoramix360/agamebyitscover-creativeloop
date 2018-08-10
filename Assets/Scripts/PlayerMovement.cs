using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 8f;

    private Rigidbody2D rigidbody;
    private float initialSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.AddTorque(Random.Range(-20f, 20f));

        initialSpeed = speed;
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");

        HandleMovement(vertical);   
    }

    private void HandleMovement(float verticalInput)
    {
        if(verticalInput == 0)
        {
            speed = 0;
        }
        else
        {
            speed = initialSpeed;
        }

        rigidbody.AddForce(new Vector2(0f, speed * verticalInput));
    }
}
