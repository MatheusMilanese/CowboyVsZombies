using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuPrincipal : MonoBehaviour
{
   
     [SerializeField] private string nomeCena = "Cena1";

     [SerializeField] private GameObject painelMenuInicial;
     [SerializeField] private GameObject painelMenuOpcoes;
    public void Jogar(){
        SceneManager.LoadScene(nomeCena);
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
