using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SpriteRenderer>().sortingOrder == renderer.sortingOrder)
        {
            SatelliteController satellite = collision.GetComponent<SatelliteController>();
            Debug.Log(satellite);
        }
    }
}
