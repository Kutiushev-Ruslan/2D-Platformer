using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _initialCoinCount = 5;

    private List<Transform> _availableSpawnPoints;
    private List<GameObject> _activeCoins;

    void Start()
    {
        _availableSpawnPoints = new List<Transform>(_spawnPoints);
        _activeCoins = new List<GameObject>();

        for (int i = 0; i < _initialCoinCount; i++)
        {
            SpawnCoin();
        }
    }

    public void CoinCollected(GameObject coin)
    {
        _activeCoins.Remove(coin);

        SpawnCoin();

        Transform spawnPoint = coin.transform.parent;
        _availableSpawnPoints.Add(spawnPoint);

        Destroy(coin);
    }

    private void SpawnCoin()
    {
        if (_availableSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, _availableSpawnPoints.Count);
            Transform spawnPoint = _availableSpawnPoints[randomIndex];

            GameObject newCoin = Instantiate(_coinPrefab, spawnPoint.position, Quaternion.identity);
            newCoin.transform.parent = spawnPoint;
            _activeCoins.Add(newCoin);

            _availableSpawnPoints.RemoveAt(randomIndex);
        }
    }
}
