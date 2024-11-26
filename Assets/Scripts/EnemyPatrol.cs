using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private Transform[] _waypoints;
    private int _waypointIndex = 0;

    void Update()
    {
        if (_waypoints.Length == 0) return;

        Transform targetWaypoint = _waypoints[_waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, _moveSpeed * Time.deltaTime);

        // Проверка дистанции до цели и изменение индекса при достижении точки
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            _waypointIndex = (_waypointIndex + 1) % _waypoints.Length;
        }

        // Определение направления и изменение масштаба
        if (transform.position.x < targetWaypoint.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Смотрит вправо
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // Смотрит влево
        }
    }
}
