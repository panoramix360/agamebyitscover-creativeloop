using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public Wave[] waves;

    [SerializeField]
    private Camera viewport;
    private Vector2 nextPosition;

    private int waveIndex = 0;
    private float spawnRate = 2f;

    private void Awake()
    {
        StartCoroutine(SpawnSatellites());
    }

    private IEnumerator SpawnSatellites()
    {
        while(true)
        {
            Wave currentWave = waves[waveIndex];

            GenerateNextPosition();
            SpawnSatellite(currentWave.satellite);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }

    private void SpawnSatellite(GameObject satellite)
    {
        GameObject newSatellite = Instantiate(satellite, nextPosition, Quaternion.identity);
        Rigidbody2D rigidbody = newSatellite.GetComponent<Rigidbody2D>();
        rigidbody.AddTorque(Random.Range(-40f, 40f));
    }

    private void GenerateNextPosition()
    {
        float topScreen = 4f;
        Debug.DrawLine(Vector3.zero, new Vector3(10f, topScreen), Color.red, 10f);
        float randomY = Random.Range(topScreen, 0);

        float leftScreen = -4.5f;
        Debug.DrawLine(Vector3.zero, new Vector3(leftScreen, 1f), Color.red, 10f);
        float rightScreen = 4.5f;
        Debug.DrawLine(Vector3.zero, new Vector3(rightScreen, 0f), Color.blue, 10f);
        float randomX = Random.Range(leftScreen, rightScreen);

        nextPosition = new Vector2(randomX, randomY);
    }
}
