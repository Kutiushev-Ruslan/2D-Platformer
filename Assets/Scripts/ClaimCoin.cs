using UnityEngine;

public class ClaimCoin : MonoBehaviour
{
    private CoinSpawner _spawner;

    void Start()
    {
        _spawner = FindObjectOfType<CoinSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Проверяем, столкнулся ли игрок
        {
            _spawner.CoinCollected(gameObject);
        }
    }
}
