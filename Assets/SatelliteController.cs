using UnityEngine;

public class SatelliteController : MonoBehaviour {

    public GameObject explosionPrefab;

    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Damage()
    {
        Vector2 newPosition = new Vector2(transform.position.x - .5f, transform.position.y);
        GameObject explosion = Instantiate(explosionPrefab, newPosition, Quaternion.identity);
        Destroy(explosion, 2f);

        Destroy(gameObject);
    }
}
