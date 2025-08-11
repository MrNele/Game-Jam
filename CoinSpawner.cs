using UnityEngine;

public class CoinSpawner : MonoBehaviour // klasa  koja je potrebna za kasniji razvoj
{
    public GameObject coinPrefab;        // Prefab coina
    public Transform[] spawnPoints;      // Lista spawn pointova

    void Start()
    {
        SpawnAllCoins();
    }

    void SpawnAllCoins()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
