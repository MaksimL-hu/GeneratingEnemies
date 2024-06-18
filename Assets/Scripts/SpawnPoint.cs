using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;

    public Enemy Enemy => _enemy;
    public Transform Target => _target;
}