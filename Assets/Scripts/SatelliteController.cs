using Assets.Scripts.Observer;
using UnityEngine;

public class SatelliteController : MonoBehaviour {

    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        
    }
}
