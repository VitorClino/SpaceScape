using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{

  public Transform target; // Referência para o transform do jogador
    public Vector3 offset = new Vector3(0, 2.0f, -5.0f); // Deslocamento da câmera em relação ao jogador

    void LateUpdate()
    {
        // Calcula a posição desejada da câmera
        Vector3 desiredPosition = target.position + offset;

        // Faz a câmera olhar para o jogador
        transform.LookAt(target.position);

        // Define a posição da câmera
        transform.position = desiredPosition;

    }
}

