using UnityEngine;

public class ScaleBasedOnY : MonoBehaviour {

    public GameObject positionToScale;

    public float scaleMin = 2.5f;
    public float scaleMax = 5f;

    private new SpriteRenderer renderer;
    private new Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        HandleDistance();
    }

    private void HandleDistance()
    {
        float scale = Mathf.Abs(positionToScale.transform.position.y - transform.position.y) / 2;
        scale = Mathf.Clamp(scale, scaleMin, scaleMax);
        transform.localScale = new Vector3(scale, scale, 0f);

        renderer.sortingOrder = (int) scale;
    }
}
