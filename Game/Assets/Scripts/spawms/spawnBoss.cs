using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBoss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpawmZombies spawmZombies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            spawmZombies.PermitirSpawn = false;
            Debug.Log("Player entrou na area de spawn");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            spawmZombies.PermitirSpawn = true;
            Debug.Log("Player saiu na area de spawn");

        }
    }
}
