using UnityEngine;

public class ScaleBasedOnY : MonoBehaviour {

    public Transform positionToScale;

    public float scaleMin = 2.5f;
    public float scaleMax = 5f;

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
        float scale = Mathf.Abs(positionToScale.position.y - transform.position.y) / 2;
        float scaleX = Mathf.Clamp(scale, scaleMin, scaleMax);
        float scaleY = Mathf.Clamp(scale, scaleMin, scaleMax);
        transform.localScale = new Vector3(scaleX, scaleY, 0f);
    }
}
