using Assets.Scripts.Observer;
using UnityEngine;

public class SatelliteController : MonoBehaviour {

    public GameObject meteoroidPartPrefab;
    public int meteoroidPartsMax = 4;
    public int meteoroidPartSpeedMin = 3;
    public int meteoroidPartSpeedMax = 5;

    private new SpriteRenderer renderer;

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
        int meteoroidParts = Random.Range(2, meteoroidPartsMax);

        for (int i = 0; i < meteoroidParts; i++)
        {
            GameObject part = Instantiate(meteoroidPartPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = part.GetComponent<Rigidbody2D>();
            rb.AddTorque(Random.Range(50, 100));
            rb.velocity = Random.onUnitSphere * Random.Range(meteoroidPartSpeedMin, meteoroidPartSpeedMax);
            Destroy(part, 6f);
        }

        Destroy(gameObject);
    }
}
