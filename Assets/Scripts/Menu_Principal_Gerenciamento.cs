using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal_Gerenciamento : MonoBehaviour
{

[SerializeField] private string nomeDoLevel = "Fase1";

public void Jogar()
{
    SceneManager.LoadScene(nomeDoLevel);
}

public void SairDoJogo()
{
    Debug.Log("Sair do jogo");
    Application.Quit();        
}

}