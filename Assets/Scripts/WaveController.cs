using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public Wave[] waves;

    private Vector2 nextPosition;

    private int waveIndex = 0;
    private float spawnRate = 2f;

    private void Awake()
    {
        StartCoroutine(SpawnSatellites());
    }

    IEnumerator SpawnSatellites()
    {
        while(true)
        {
            Wave currentWave = waves[waveIndex];

            GenerateNextPosition();
            SpawnSatellite(currentWave.satellite);
            yield return new WaitForSeconds(2f / spawnRate);
        }
    }

    private void SpawnSatellite(GameObject satellite)
    {
        GameObject newSatellite = Instantiate(satellite, nextPosition, Quaternion.identity);
        Rigidbody2D rigidbody = newSatellite.GetComponent<Rigidbody2D>();
        rigidbody.AddTorque(Random.Range(-40f, 40f));
        rigidbody.AddForce(new Vector2(-250f, 0f));
    }

    private void GenerateNextPosition()
    {
        Vector3 topScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f));
        Vector3 bottomScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        float randomY = Random.Range(topScreen.y, bottomScreen.y);
        nextPosition = new Vector2(transform.position.x, randomY);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, 0f), 5);
    }
}
