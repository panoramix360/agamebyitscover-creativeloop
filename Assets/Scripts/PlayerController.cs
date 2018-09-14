using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float speed = 8f;

    private float initialSpeed;
    private float horizontalInput;
    private float verticalInput;

    [Header("Damage")]
    public Sprite[] damages;
    public GameObject[] lostPieces;
    public float speedPieces = 150f;

    public GameObject controller;

    private int damageCount = -1;
    public Collider2D lastCollision;
    private int piecesLost = 0;

    private new Rigidbody2D rigidbody;
    private new SpriteRenderer renderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

        rigidbody.AddTorque(Random.Range(-20f, 20f));
        initialSpeed = speed;
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        HandleMovement();
    }

    private void HandleMovement()
    {
        if(verticalInput == 0 && horizontalInput == 0)
        {
            speed = 0;
        }
        else
        {
            speed = initialSpeed;
        }

        rigidbody.AddForce(new Vector2(speed * horizontalInput, speed * verticalInput));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void CheckCollision(Collider2D other)
    {
        if (isColliding(other))
        {
            Damage();
            lastCollision = other;

            SatelliteController satellite = other.GetComponent<SatelliteController>();
            satellite.Damage();
        }
    }

    private bool isColliding(Collider2D other)
    {
        bool isColliding = other.transform.localScale.x >= 3;

        return isColliding && (lastCollision == null || lastCollision != null && lastCollision.gameObject != other.gameObject);
    }

    private void Damage()
    {
        damageCount++;

        if (damageCount < damages.Length)
        {
            renderer.sprite = damages[damageCount];
            if (piecesLost < lostPieces.Length)
            {
                GameObject lostPiece = lostPieces[piecesLost];
                lostPiece.SetActive(true);
                Rigidbody2D rigidbodyPiece = lostPiece.GetComponent<Rigidbody2D>();
                rigidbodyPiece.AddForce(new Vector2(speedPieces * horizontalInput, speedPieces * verticalInput));
                if(rigidbodyPiece.velocity == new Vector2(0, 0))
                {
                    float randomXForce = Random.value * RandomSign();
                    float randomYForce = Random.value * RandomSign();
                    rigidbodyPiece.AddForce(new Vector2(speedPieces * randomXForce, speedPieces * randomYForce));
                }
                Destroy(lostPiece, 10f);
                piecesLost++;
            }
        }
        else
        {
            Destroy(gameObject);
            controller.GetComponent<GameController>().GameOver();
        }
    }

    private int RandomSign()
    {
        return Random.value < .5 ? 1 : -1;
    }
}
