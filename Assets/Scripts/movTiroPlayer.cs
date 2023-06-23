using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movTiroPlayer : MonoBehaviour
{
  public int velocidade = 50;

  void FixedUpdate()
  {

    this.gameObject.GetComponent<Rigidbody>().velocity = transform.up * velocidade;
  
  }

}
