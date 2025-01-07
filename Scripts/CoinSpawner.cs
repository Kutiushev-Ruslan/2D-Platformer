using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _coinPrefab; // Префаб монеты с Rigidbody2D
    [SerializeField] private Transform[] _spawnPoints; // Все точки спавна
    [SerializeField] private int _initialCoinCount = 5; // Количество монет на старте

    private List<Transform> _availableSpawnPoints = new List<Transform>(); // Свободные точки
    private List<Rigidbody2D> _activeCoins = new List<Rigidbody2D>(); // Активные монеты

    public int Counter = 0; // Счетчик собранных монет

    private void Awake()
    {
        // Инициализируем список доступных точек
        _availableSpawnPoints = new List<Transform>(_spawnPoints);

        // Спавним начальное количество монет
        for (int i = 0; i < _initialCoinCount; i++)
        {
            SpawnCoin();
        }
    }

    public void CoinCollected(GameObject coinObject)
    {
        Rigidbody2D coinRigidbody = coinObject.GetComponent<Rigidbody2D>();

        Destroy(coinObject);

        Counter++;

        _activeCoins.Remove(coinRigidbody);

        Debug.Log($"Монета {Counter} уничтожена");

        SpawnCoin();

        Transform spawnPoint = coinRigidbody.transform.parent;
        _availableSpawnPoints.Add(spawnPoint);
    }

    private void SpawnCoin()
    {
        if (_availableSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, _availableSpawnPoints.Count);
            Transform spawnPoint = _availableSpawnPoints[randomIndex];

            Rigidbody2D newCoin = Instantiate(_coinPrefab, spawnPoint.position, Quaternion.identity);
            newCoin.transform.parent = spawnPoint;
            _activeCoins.Add(newCoin);

            _availableSpawnPoints.RemoveAt(randomIndex);

            Debug.Log($"Монета создана в точке {spawnPoint.name}");
        }
    }
}
