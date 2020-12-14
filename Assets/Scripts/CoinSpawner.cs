using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToPool;
    public int amountToPool;

    private float lastSpawnedZ = 0;
    private List<GameObject> pooledObjects;
    private int iteratingAmount = 13;

    void Start()
    {
        // initialize pooledObjects list
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }

        // position inital obstacles
        int initialOffset = 15;
        for (int i = 1; i < amountToPool; i++) {
            GameObject obstacle = GetPooledObject(); 
            if (obstacle != null) {
                int obstaclePositionZ = initialOffset + i * iteratingAmount;
                obstacle.transform.position = new Vector3(UnityEngine.Random.Range(-2, 2), 1, obstaclePositionZ);
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
                pooledObjects[i].transform.position = new Vector3(UnityEngine.Random.Range(-2, 2), 1, lastSpawnedZ + iteratingAmount);
                lastSpawnedZ += iteratingAmount;
            }
            // setActive(true) to hidden objects that player collected
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].transform.position.z < player.transform.position.z - 10) {
                 pooledObjects[i].SetActive(true);
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
