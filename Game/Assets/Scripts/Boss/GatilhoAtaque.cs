using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoAtaque : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //em quanto o player estiver dentro do trigger
    private void OnTriggerStay2D(Collider2D other) {
        //se o player estiver atacando
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet")){
            //ativa o ataque do braço direito
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
   
    
}
