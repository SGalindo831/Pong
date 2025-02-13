using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Array of power up prefabs
    public GameObject[] powerUpPrefabs;
    public float spawnInterval = 10f;

    //Area where the power ups spawn
    public Vector2 spawnArea = new Vector2(8f, 4f);

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", spawnInterval, spawnInterval);
    }

    void SpawnPowerUp()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            0.5f,
            Random.Range(-spawnArea.y, spawnArea.y)
        );

        GameObject powerUp = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];
        Instantiate(powerUp, spawnPosition, Quaternion.identity);
    }
}