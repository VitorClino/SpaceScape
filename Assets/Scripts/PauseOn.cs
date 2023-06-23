using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOn : MonoBehaviour
{
    [Header("Configuracao de Pause")]
    public bool isPause = false;
    public GameObject panel;
    public int stop = 0;

    void Update()
    {
        Pause();
    }


    void Pause()
    {

        if((Input.GetKeyDown(KeyCode.P))||(isPause==true)){

            stop++;

            if(stop%2 == 1){
                
                Time.timeScale = 0;
                panel.SetActive(true);
            
            }
            else{
                Time.timeScale = 1.0f;
                panel.SetActive(false);
                isPause = false;
                stop = 0;
            }
        }
    }
    public void ToggleisPauseValue()
    {
        isPause = true;
    }
 
}