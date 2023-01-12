using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMorte : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string cena_jogo;
    [SerializeField] private string cena_menu;
    public void JogarNovamente(){
        SceneManager.LoadScene(cena_jogo);
    }

    public void MenuPrincipal(){
        SceneManager.LoadScene(cena_menu);
    }

    public void Sair(){
        Debug.Log("Saindo do jogo");
        //rlx so funciona quando o jogo estiver compilado
        Application.Quit();
    }
}
