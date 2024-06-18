using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
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
        SpawnPoint spawnPoint = GetRandomSpawnPoint();

        Enemy enemy = Instantiate(
            spawnPoint.Enemy,
            spawnPoint.gameObject.transform.position,
            Quaternion.identity);

        enemy.Move(spawnPoint.Target);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
}