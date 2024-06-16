using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        bool _isSpawn = true;

        while (_isSpawn)
        {
            Spawn();
            yield return delay;
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(
            GetRandomEnemyPrefab(),
            GetRandomSpawnPoint(),
            Quaternion.identity).GetComponent<Enemy>();

        enemy.Move(GetRandomDirection());
    }

    private GameObject GetRandomEnemyPrefab()
    {
        return _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}