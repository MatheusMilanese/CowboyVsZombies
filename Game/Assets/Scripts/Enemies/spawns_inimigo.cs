using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawns_inimigo : MonoBehaviour
{

    [SerializeField] private Transform[] spawn = new Transform[4]; 

    [SerializeField] private GameObject inimigo;
     // Start is called before the first frame update
    void Start()
    {


        //inimigo = GameObject.FindWithTag("inimigo_base").gameObject;

        InvokeRepeating("spawnInimigo",4,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnInimigo(){
        int index = Random.Range(0,4);
        
        if(spawn[index].gameObject != null){
            GameObject inimigo_buff  = (GameObject) Instantiate(inimigo,spawn[index].position,Quaternion.identity);
        } else {
            Debug.Log("Spwan is null");
        }
    }
}
