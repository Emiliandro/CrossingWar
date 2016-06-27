using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;
    public float speed = 0f;
    public bool InGame = false, isPulando = false, isSubindo = false, isDescendo = false, inCentro = true, inEsquerda = false, inDireita = false;
    //public Text texto;
    public int total;
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    public AudioSource ouvido;
    public GameObject blood;
    public GameObject gameOver, gameOn;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (isPulando)
        {
           if (this.transform.position.y < 15 && isSubindo)
           {
                this.transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            }else if (this.transform.position.y > 15 || isDescendo)
            {
               if (this.transform.position.y > 0)
               {
                   isSubindo = false;
                   isDescendo = true;
               }
               else isDescendo = false;
               this.transform.position = new Vector3(transform.position.x, transform.position.y - ((speed +4) * Time.deltaTime), transform.position.z);
            }
            else
            {
                isPulando = false;
            }
        }
    
    }
    public void GameStated()
    {
        InGame = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Mortais")
        {
            InGame = false;
            BloodSpawn();

        }

        if (collision.gameObject.tag == "money")
        {
           
            CoinManager.instance.BoostMoney();
            Destroy(collision.gameObject);
            //texto.text = (Mathf.RoundToInt(total)).ToString();

        }
    }
    public void CharacterSelectionSoldier()
    {
        SetCharacterSelecionado(0);
        //BroadcastMessage("PlayIt");
    }

    public void CharacterSelectionNazie()
    {
        SetCharacterSelecionado(1);
       // BroadcastMessage("PlayIt");

    }

    public void CharacterSelectionZumbie()
    {
        SetCharacterSelecionado(2);
        //BroadcastMessage("PlayIt");

    }

    void SetCharacterSelecionado(int selected)
    {
            switch (selected)
            {
                case 0:
                    Debug.Log("Selecionou o Soldado");
                    char1.SetActive(true);
                    char2.SetActive(false);
                    char3.SetActive(false);
                    break;
                case 1:
                    Debug.Log("Selecionou o Nazista");
                    char1.SetActive(false);
                    char2.SetActive(true);
                    char3.SetActive(false);
                    break;
                case 2:
                    Debug.Log("Selecionou o Zumbie");
                    char1.SetActive(false);
                    char2.SetActive(false);
                    char3.SetActive(true);
                    break;
            }
    }

    void BloodSpawn()
    {
        gameOn.SetActive(false);
        gameOver.SetActive(true);
        Instantiate(blood, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
        Time.timeScale = 0.1f;
        ouvido.Stop();
    }

    void SwipeUp()
    {

        if (!InGame)
        {
            return;
        }


        if (!isPulando)
        {

            if (!isPulando)
            {
                isPulando = true;
                isSubindo = true;
            }
        }
        Debug.Log("Consumindo Swipe Cima");
    }

    void SwipeLeft()
    {

        if (!InGame)
        {
            return;
        }


        if (!inEsquerda)
        {
            if (!inCentro)
            {
                inCentro = true;
                inEsquerda = false;
                inDireita = false;
                JumpCentro();

            }
            else
            {
                inCentro = false;
                inEsquerda = true;
                inDireita = false;
                JumpEsquerda();
            }            
        }
        Debug.Log("Consumindo Swipe Esquerda");
    }

    void SwipeRight()
    {

        if (!InGame)
        {
            return;
        }


        if (!inDireita)
        {
            if (!inCentro)
            {
                inCentro = true;
                inEsquerda = false;
                inDireita = false;
                JumpCentro();

            }
            else
            {
                inCentro = false;
                inEsquerda = false;
                inDireita = true;
                JumpDireita();
            }
        }
        Debug.Log("Consumindo Swipe Direita");
    }
    void JumpCentro()
    {
        transform.position = new Vector3(14, transform.position.y, transform.position.z);
    }
    void JumpEsquerda()
    {
        transform.position = new Vector3(24, transform.position.y, transform.position.z);
    }
    void JumpDireita()
    {
        transform.position = new Vector3(04, transform.position.y, transform.position.z);
    }

    void SwipeDown()
    {
        transform.position = new Vector3(14, transform.position.y, transform.position.z);

    }
}
