using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorreteController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Atacar());
    }

   

    IEnumerator Atacar(){
        //espera a animação terminar
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        //destruir o objeto
        Destroy(gameObject);
    }
}
