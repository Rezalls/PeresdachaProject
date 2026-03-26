using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector2 _areaSpawnSize = new Vector2(1920, 1080);
    [SerializeField] private float _spawnInterval = 0.4f;
    [SerializeField] private float _checkRadius = 1f;
    [SerializeField] private LayerMask _checkLayer;

    //старт корутины спавна
    void Start()
    {
       StartCoroutine(SpawnRoutine());
    }

    //вызывает метод спавна с интервалом _spawnInterval
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            EnemySpawn();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    //метод который спавнит врагов, перед спавном он ищет место для создание префаба, он создаёт коллайдер, который чекает нет ли рядом других коллайдеров
    private void EnemySpawn()
    {
        int maxAttempts = 10;

        for (int i = 0; i < maxAttempts; i++)
        {
            float randomX = Random.Range(-_areaSpawnSize.x / 2, _areaSpawnSize.x / 2);
            float randomY = Random.Range(-_areaSpawnSize.y / 2, _areaSpawnSize.y / 2);

            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(randomX,randomY);

            Collider2D check = Physics2D.OverlapCircle(spawnPosition, _checkRadius, _checkLayer);

            if(check == null)
            {
                Instantiate(_prefab, spawnPosition, Quaternion.identity);
                return;
            }
        }
        Debug.Log("Нет места для спавна(((");
    }
    // метод который визаулизирует зону спавна и проверку коллайдеров в радиусе
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, _areaSpawnSize);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, _checkRadius);
    }
}
