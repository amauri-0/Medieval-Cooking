using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalGerenciamento : MonoBehaviour
{

[SerializeField] private string nomeDoLevel = "GameScene";
[SerializeField] private string nomeDoMenu = "MainMenuScene";

    public void Jogar()
{
    SceneManager.LoadScene(nomeDoLevel);
}

public void Menu()
{
    SceneManager.LoadScene(nomeDoMenu);
}

    public void SairDoJogo()
{
    Debug.Log("Sair do jogo");
    Application.Quit();        
}

}
