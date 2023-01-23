using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracoDireitoController : MonoBehaviour


 
{
     private Animator _animation;
    [SerializeField] private bool _atacar = true;
    public bool Atacar{
        get { return _atacar; }
        set { _atacar = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<Animator>();
        gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(_atacar){
            StartCoroutine(_Atacar());
        }
        //gameObject.GetComponent<Rigidbody2D>().rotation += 20;
    }

    

    IEnumerator _Atacar(){
        gameObject.SetActive(true);
        //espera a animação terminar
        yield return new WaitForSeconds(_animation.GetCurrentAnimatorStateInfo(0).length);
        //yield return new WaitForSeconds(1);
        //desativar gameobject
        gameObject.SetActive(false);
    }

    
}
