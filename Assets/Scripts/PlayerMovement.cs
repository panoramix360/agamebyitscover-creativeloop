using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float scaleMinLimit = 6f;
    public float scaleMaxLimit = 12f;

    public float speed = 5f;

    private Transform transform;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");

        HandleMovement(vertical);
        HandleDistance();
    }

    private void HandleDistance()
    {
        
        float positionOnScreen = Vector3.Normalize(Camera.main.WorldToScreenPoint(transform.position)).y;
        float scale = positionOnScreen * 8f;
        float scaleX = Mathf.Clamp(transform.localScale.x + scale, scaleMinLimit, scaleMaxLimit);
        float scaleY = Mathf.Clamp(transform.localScale.y + scale, scaleMinLimit, scaleMaxLimit);
        transform.localScale = new Vector3(scaleX, scaleY, 0f);

        Debug.Log(positionOnScreen);
    }

    private void HandleMovement(float verticalInput)
    {
        rigidbody.AddForce(new Vector2(0f, speed * verticalInput));
    }
}
