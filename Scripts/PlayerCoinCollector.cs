using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    private void Awake()
    {
        _coinSpawner = FindObjectOfType<CoinSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            if (coin.IsCollected) return;

            _coinSpawner.CoinCollected(collision.gameObject);
            coin.IsCollected = true;
        }
    }
}
