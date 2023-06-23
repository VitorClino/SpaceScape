using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    

    [Header ("Status Inimigo Padrao")]
    public int vida = 2;
    public int recompensaPontos = 20;

    [Header("Configuracao do Tiro")]

    public GameObject TiroInimigo;
    public Transform spawnTiroInimigo;
    public bool ativarTiro;
    public float TempoDeRecarga = 4.0f;

    [Header("Configuracao do material")]

    public Material materialdano;
    Material materialOriginal;
    MeshRenderer meshRenderer;
    public float TempoDePiscar;

    [Header("Configuracao do movimento")]

    public Transform target;
    public Vector3 offset = new Vector3(0, 0, 5.0f);
    public float velocidade = 5.0f;

    public float limiteDistancia = 5.0f;

    void Start()
    {
        Time.timeScale = 1;

        meshRenderer = GetComponent<MeshRenderer>();
        materialOriginal = meshRenderer.material;

        if (ativarTiro) 
        {
            InvokeRepeating("Atirar", 0, TempoDeRecarga);
        }

    }

    void Update()
    {
        Morte();
        Movimento();
    }
    
   void Atirar()
    {
        GameObject projetil = Instantiate(TiroInimigo, spawnTiroInimigo.transform.position, spawnTiroInimigo.transform.rotation);
        Destroy(projetil, 2);
    }

    private IEnumerator OnCollisionEnter(Collision objetoColidido)
    {
        if (objetoColidido.transform.tag == "TiroPlayer")
        {

            Destroy (objetoColidido.gameObject);
            vida--;
            meshRenderer.material = materialdano;
            yield return new WaitForSeconds(TempoDePiscar);
            meshRenderer.material = materialOriginal;
        }
        
        if(objetoColidido.transform.tag == "TiroEnemy")

        {
            Destroy(objetoColidido.gameObject);
        }
    }


    void Morte()
    {
        if(vida <= 0)
        {
            GameManager.instancia.adicionarPontos(recompensaPontos);
            Destroy (this.gameObject);
        }
    }
    
    void Movimento()
    {
        Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, velocidade * Time.deltaTime);
        
        transform.LookAt(target.position);

       
        Quaternion targetRotation = Quaternion.Euler(90, 0, 0) * transform.rotation;
        transform.rotation = targetRotation;

        
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        foreach (GameObject inimigo in inimigos)
        {
        if (inimigo != gameObject)
            {
            float distancia = Vector3.Distance(transform.position, inimigo.transform.position);

            if (distancia < limiteDistancia)
                {
                
                Vector3 direcao = transform.position - inimigo.transform.position;
                direcao.Normalize();        
                Vector3 deslocamento = direcao * (limiteDistancia - distancia);
                transform.position += deslocamento;
                }
            }
        }
    }
}

