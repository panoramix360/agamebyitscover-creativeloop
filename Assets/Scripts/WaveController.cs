using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public Wave[] waves;

    private float spawnRate;

    private void Awake()
    {
        spawnRate = 2f;
        StartCoroutine(SpawnSatellites());
    }

    IEnumerator SpawnSatellites()
    {
        Wave currentWave = waves[0];

        for (int i = 0; i < currentWave.count; i++)
        {
            SpawnSatellite(currentWave.satellite);
            yield return new WaitForSeconds(1f / spawnRate);
        }
    }

    private void SpawnSatellite(GameObject satellite)
    {
        GameObject newSatellite = Instantiate(satellite, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody = newSatellite.GetComponent<Rigidbody2D>();
        rigidbody.AddTorque(Random.Range(-20f, 20f));
        rigidbody.AddForce(new Vector2(-30f, 0f));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, 0f), 5);
    }
}
