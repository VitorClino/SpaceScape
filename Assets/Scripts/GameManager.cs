using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{

    public static GameManager instancia;

    [Header ("Configuracao de pontos")]

    public Text UIpontos;
    int auxPontuacao;

    public void Update()
    {
        AtualizarHUD();
    }

    void Awake() 
    {
        if(instancia == null) 
        {
            instancia = this;
        }
    }
    public void adicionarPontos(int pontos)
    {
        
        if( PlayerPrefs.HasKey("pontuacao"))
        {
            
            auxPontuacao = PlayerPrefs.GetInt("pontuacao") + pontos;
            PlayerPrefs.SetInt("pontuacao", auxPontuacao);
            Debug.Log(PlayerPrefs.GetInt("pontuacao"));
        }
        else
        {
            PlayerPrefs.SetInt("pontuacao", pontos);
        }
        UIpontos.text = PlayerPrefs.GetInt("pontuacao").ToString();
    }

    void AtualizarHUD()
    {
        if(PlayerPrefs.HasKey("pontuacao"))
        {
            UIpontos.text = PlayerPrefs.GetInt("pontuacao").ToString();
        }
        else
        {
          UIpontos.text = "0";
       }
    }

    
}
