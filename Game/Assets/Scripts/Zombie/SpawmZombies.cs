using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmZombies : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] spawnPositions;

    void Start() {
        StartCoroutine("spawmZombie");
    }

    IEnumerator spawmZombie(){

        yield return new WaitForSeconds(1);

        // Choose a random transform from the array
        Transform randomSpawnPoint = spawnPositions[Random.Range(0, spawnPositions.Length)];

        // Spawn the prefab at the random transform's position
        Instantiate(prefab, randomSpawnPoint.position, Quaternion.identity);

        StartCoroutine("spawmZombie");
    }
}
