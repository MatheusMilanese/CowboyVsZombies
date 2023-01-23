using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GatilhoAtaque : MonoBehaviour
{
    
    private bool atacar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerable poderAtacar(){
        yield return new WaitForSeconds(2);
        atacar = true;
    }

    //em quanto o player estiver dentro do trigger
    private void OnTriggerStay2D(Collider2D other) {
        //se o player estiver atacando
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet") || atacar){
            //ativa o ataque do braço direito
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
   
    
}
