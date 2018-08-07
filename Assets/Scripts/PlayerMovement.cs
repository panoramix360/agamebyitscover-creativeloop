using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float scaleMinLimit = 6f;
    public float scaleMaxLimit = 12f;
    public float offset = 3f;

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
        float offsetSpan = scaleMaxLimit - scaleMinLimit;
        float positionOnScreen = Mathf.Abs(Camera.main.WorldToScreenPoint(transform.position).y - Screen.height);
        float positionOnScreenNormalized = (positionOnScreen - scaleMinLimit) / offsetSpan;

        float scaleX = Mathf.Clamp(positionOnScreenNormalized + offset, scaleMinLimit, scaleMaxLimit);
        float scaleY = Mathf.Clamp(positionOnScreenNormalized + offset, scaleMinLimit, scaleMaxLimit);
        transform.localScale = new Vector3(scaleX, scaleY, 0f);

        Debug.Log(positionOnScreenNormalized + offset);
    }

    private void HandleMovement(float verticalInput)
    {
        rigidbody.AddForce(new Vector2(0f, speed * verticalInput));
    }
}
