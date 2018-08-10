using UnityEngine;

public class ScaleBasedOnY : MonoBehaviour {

    public float scaleMinLimit = 2.7f;
    public float scaleMaxLimit = 5f;
    public float offset = -12f;

    private Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        HandleDistance();
    }

    private void HandleDistance()
    {
        float offsetSpan = scaleMaxLimit - scaleMinLimit;
        float positionOnScreen = Mathf.Abs(Camera.main.WorldToScreenPoint(transform.position).y - Screen.height);
        float positionOnScreenNormalized = (positionOnScreen - scaleMinLimit) / offsetSpan;

        Debug.Log(positionOnScreenNormalized);

        float scaleX = Mathf.Clamp(positionOnScreenNormalized + offset, scaleMinLimit, scaleMaxLimit);
        float scaleY = Mathf.Clamp(positionOnScreenNormalized + offset, scaleMinLimit, scaleMaxLimit);
        transform.localScale = new Vector3(scaleX, scaleY, 0f);
    }
}
