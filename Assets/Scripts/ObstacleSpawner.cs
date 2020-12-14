using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToPool;
    public List<GameObject> objectsToPool = new List<GameObject>();
    public int amountToPool;

    private float lastSpawnedZ = 0;
    private List<GameObject> pooledObjects;

    void Start()
    {
        // initialize pooledObjects list
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            for (int j = 0; j < objectsToPool.Count; j++) {
                GameObject obj = (GameObject)Instantiate(objectsToPool[j]);
                obj.SetActive(false); 
                pooledObjects.Add(obj);
            }
        }

        // position inital obstacles
        int initialOffset = 30;
        for (int i = 1; i < amountToPool; i++) {
            GameObject obstacle = GetPooledObject(); 
            if (obstacle != null) {
                int obstaclePositionZ = initialOffset + i * 30;
                obstacle.transform.position = new Vector3(UnityEngine.Random.Range(-1, 5), 0, obstaclePositionZ);
                lastSpawnedZ = obstaclePositionZ;
                obstacle.SetActive(true);
            }
        }
    }

    void Update()
    {
        // reuse hidden obstacles
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (pooledObjects[i].activeInHierarchy && pooledObjects[i].transform.position.z < player.transform.position.z - 10) {
                pooledObjects[i].transform.position = new Vector3(UnityEngine.Random.Range(-1, 5), 0, lastSpawnedZ + 30);
                lastSpawnedZ += 30;
            }
        }
    }

    private GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
