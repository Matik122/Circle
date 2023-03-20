using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnerTimeInstantiationRate { get; set; } = Constants.SpawnerTimeInstantiationRate;
    public GameObject[] asteroids;
    [SerializeField] private protected Collider _spawnArea;

    private void Spawn()
    {
        StartCoroutine(SpawnObject());
    }

    private void OnEnable()
    {
        Spawn();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public virtual IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(Constants.SpawnRate);

        while (enabled)
        {
            GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];
            Vector3 position = new Vector3();
            position.x = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
            position.y = Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y);
            position.z = Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z);
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(Constants.MinAngle, Constants.MaxAngle));
            yield return new WaitForSeconds(SpawnerTimeInstantiationRate);
            GameObject prefab = Instantiate(asteroid, position, rotation);
            Destroy(prefab, Constants.MaxLifeTime);
            float force = Random.Range(Constants.MinForce, Constants.MaxForce);
            prefab.GetComponent<Rigidbody>().AddForce(prefab.transform.right * force, ForceMode.Impulse);
            yield return new WaitForSeconds(Random.Range(Constants.MinSpawnDelay, Constants.MaxSpawnDelay));
        }
    }
}
