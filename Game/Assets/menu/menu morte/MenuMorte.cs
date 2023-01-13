using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMorte : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string cena_jogo;
    [SerializeField] private string cena_menu;

    [SerializeField] private GameObject prefab;
    public void JogarNovamente(){
        StartCoroutine(Loading());
    }
    

    public void MenuPrincipal(){
        SceneManager.LoadScene(cena_menu);
    }

    public void Sair(){
        Debug.Log("Saindo do jogo");
        //rlx so funciona quando o jogo estiver compilado
        Application.Quit();
    }

    IEnumerator Loading(){
        GameObject loading;
        
        Destroy(GameObject.Find("Loading"));
        
        loading =  Instantiate(prefab);
        loading.name = "Loading";
        
        //nao destruir o prefab
        DontDestroyOnLoad(loading);
        //recuperar o animator do filhdo do filho
        Animator anim = loading.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
       
        //cena so carrega quando a animação terminar
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(cena_jogo, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        //espera a animação terminar
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length/2);
        //ativa a cena
        asyncLoad.allowSceneActivation = true;
    }
}
