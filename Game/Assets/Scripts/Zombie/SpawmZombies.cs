using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmZombies : MonoBehaviour
{
    [SerializeField] private GameObject prefabZombie;
    [SerializeField] private GameObject prefabBossZombie;
    [SerializeField] private Transform[] spawnPositions;

    [SerializeField] private Transform[] spawnPositionsBoss;

    private bool permitirSpawn = true;
    public bool PermitirSpawn {
        get { return permitirSpawn; }
        set { permitirSpawn = value; }
    }

    public bool existeBoss = false;

    private GameObject boss;


    [SerializeField] GameController gameController;
    void Start() {
        StartCoroutine("spawmZombie");
    }

    void Update() {
        if((gameController.amountZombieKills % 10 == 0) && (gameController.amountZombieKills != 0) && !existeBoss) {
            // Choose a random transform from the array
            Transform randomSpawnPoint = spawnPositionsBoss[permitirSpawn ? 0 : 1];

            // Spawn the prefab at the random transform's position
           boss = Instantiate(prefabBossZombie, randomSpawnPoint.position, Quaternion.identity);
           existeBoss = true;
        }

        //se o boss morrer
        if(boss == null){
            existeBoss = false;
        }
    }



    IEnumerator spawmZombie(){

        yield return new WaitForSeconds(1);

        // Choose a random transform from the array
        Transform randomSpawnPoint = spawnPositions[  Random.Range(0, spawnPositions.Length)];

        // Spawn the prefab at the random transform's position
        Instantiate(prefabZombie, randomSpawnPoint.position, Quaternion.identity);

        StartCoroutine("spawmZombie");
    }

    //vereficar se o player esta na area de spawn
    
   
}
