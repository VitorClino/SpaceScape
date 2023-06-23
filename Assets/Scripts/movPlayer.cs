using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class movPlayer : MonoBehaviour
{
    [Header("Configuracao de movimento")]

    public float velocity = 10.0f;
    Vector3 direcao;

    public float limiteEsquerdo = -63.11991f;
    public float limiteDireito= 30.98911f;
    public float limiteInferior= -1.16595f;
    public float limiteSuperior= 39f;
    public float limiteAtras = 0f;
    public float limiteFrente = 10.0f;
    
    [Header("Configuracao de vida")]

    public int vida = 5;
    public bool imortal = false;

    [Header("Configuracao de tiro")]

    public GameObject TiroPlayer;
    public Transform spawnTiro;

    public float intervaloTiro = 1.0f;
    float tiroInicial, proximoTiro;
    public float TempoDeDestruiçãoDoTiro = 3.0f;

    [Header("Configuracao do material")]
    public Material materialdano;
    Material materialOriginal;
    MeshRenderer meshRenderer;
    public float TempoDePiscar;

    


    void Start()
    {
        Time.timeScale = 1.0f;
        meshRenderer = GetComponent<MeshRenderer>();
        materialOriginal = meshRenderer.material;
    }


    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale==1)
        {
        Movimento();
        LimitarPosicao();
        Tiro();
        Morre();
        }
    }
    
    void Movimento()
    {

        Vector3 direcao = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), -Input.GetAxis("Vertical"));
        

        transform.Translate(direcao * velocity * Time.deltaTime);
    }

    void LimitarPosicao()
    {
        Vector3 posicaoAtual = transform.position;

        posicaoAtual.x = Mathf.Clamp(posicaoAtual.x, limiteEsquerdo, limiteDireito);
        posicaoAtual.y = Mathf.Clamp(posicaoAtual.y, limiteInferior, limiteSuperior);
        posicaoAtual.z = Mathf.Clamp(posicaoAtual.z, limiteAtras, limiteFrente);
        
        if (!Input.GetButton("Jump"))
        {
            posicaoAtual.z = posicaoAtual.z - velocity * Time.deltaTime;
        }
        transform.position = posicaoAtual;
    }

    void Tiro()
    {
        tiroInicial = tiroInicial + Time.deltaTime;

        if((Input.GetButton("Fire1") && (tiroInicial > proximoTiro)))
        {
            proximoTiro = tiroInicial + intervaloTiro;
            GameObject Tiro = Instantiate(TiroPlayer, spawnTiro.transform.position, spawnTiro.transform.rotation);
            proximoTiro = proximoTiro - tiroInicial;
            tiroInicial = 0.0f;
            Destroy(Tiro, TempoDeDestruiçãoDoTiro);
        }
        
    }

   

    private IEnumerator OnCollisionEnter(Collision objetoColidido)
    {
        if (objetoColidido.transform.tag == "TiroEnemy")
        {
            
            vida--;
            Debug.Log("vida " + vida);
            Destroy(objetoColidido.gameObject);
            meshRenderer.material = materialdano;
            yield return new WaitForSeconds(TempoDePiscar);
            meshRenderer.material = materialOriginal;
            
        }
    }

    void Morre()
    {
        if ((vida<=0)&&(!imortal))
        {
            Destroy(this.gameObject);
        }
    }


}
