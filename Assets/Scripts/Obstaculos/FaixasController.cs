using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaixasController : MonoBehaviour {

    public GameObject[] obstaculos;
    public float velocidade;
    public Text valor;
    private float pontuacao;

    void Start()
    {
        valor = GameObject.Find("Points").GetComponent<Text>();
        pontuacao = float.Parse(valor.text);
        velocidade = - 60 - ((pontuacao + 2)/100);
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, velocidade);
        if (GetComponent<Rigidbody>().transform.position.z < -180)
        {
            if (pontuacao > 20)
            {
                Instantiate(obstaculos[Random.Range(0, obstaculos.Length)]);
            }
            else if (pontuacao > 40)
            {
                Instantiate(obstaculos[Random.Range(0, obstaculos.Length)]);
                Instantiate(obstaculos[Random.Range(0, obstaculos.Length)]);
            }
            Instantiate(obstaculos[Random.Range(0, obstaculos.Length)]);
            Destroy(transform.parent.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mortais")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "money")
        {
            Destroy(gameObject);
        }
    }
}
