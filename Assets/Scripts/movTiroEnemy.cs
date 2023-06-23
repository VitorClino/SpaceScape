using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movTiroEnemy : MonoBehaviour
{
 public int velocidade = 30;

  void FixedUpdate()
  {

    this.gameObject.GetComponent<Rigidbody>().velocity = transform.up * velocidade;
  
  }
}

