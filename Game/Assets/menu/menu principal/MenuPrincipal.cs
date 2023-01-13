using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuPrincipal : MonoBehaviour
{
   
     [SerializeField] private string nomeCena = "Gameplay";

     [SerializeField] private GameObject painelMenuInicial;
     [SerializeField] private GameObject painelMenuOpcoes;

     [SerializeField] private GameObject prefab;
     private GameObject loading;
    public void Jogar(){
        StartCoroutine(Loading());
    }

     IEnumerator Loading(){
     
        
        Destroy(GameObject.Find("Loading"));
        
        loading =  Instantiate(prefab);
        loading.name = "Loading";
        
        //nao destruir o prefab
        DontDestroyOnLoad(loading);
        //recuperar o animator do filhdo do filho
        Animator anim = loading.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
       
        //cena so carrega quando a animação terminar
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nomeCena, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        //espera a animação terminar
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length/2);
        //ativa a cena
        asyncLoad.allowSceneActivation = true;
    }

    public void AbrirMenuOpcoes(){
        painelMenuInicial.SetActive(false);
        painelMenuOpcoes.SetActive(true);
    }

    public void FecharMenuOpcoes(){
        painelMenuInicial.SetActive(true);
        painelMenuOpcoes.SetActive(false);
    }

    public void Sair(){
        Debug.Log("Saindo do jogo");
        Application.Quit();
    }
}
