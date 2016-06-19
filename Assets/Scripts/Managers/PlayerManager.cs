using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    public float speed = 0f;
    public bool isPulando = false, isSubindo = false, isDescendo = false;
    public Text texto;
    public int total;
    public GameObject goto1, goto2;
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isPulando)
            {
                isPulando = true;
                isSubindo = true;
            }
        }
        if (isPulando)
        {
            if (this.transform.position.y < 10 && isSubindo)
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            }else if (this.transform.position.y > 10 || isDescendo)
            {
                if (this.transform.position.y > 0)
                {
                    isSubindo = false;
                    isDescendo = true;
                }
                else isDescendo = false;
                this.transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
            }
            else
            {
                isPulando = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Mortais")
        {
            //GetComponent<Rigidbody>().velocity = goto2.transform.position;

        }

        if (collision.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "money")
        {
            total++;
            Destroy(collision.gameObject);
            texto.text = (Mathf.RoundToInt(total)).ToString();

        }
    }
    public void CharacterSelectionSoldier()
    {

        
        SetCharacterSelecionado(0);
        //PlayerPrefs.SetInt ("Reload",1);
        //Application.LoadLevel("Main");

    }

    public void CharacterSelectionNazie()
    {


        //PlayerPrefs.SetInt ("Reload",1);
        SetCharacterSelecionado(1);
        //Application.LoadLevel("Main");
    }

    public void CharacterSelectionZumbie()
    {

        //PlayerPrefs.SetInt ("Reload",1);
        SetCharacterSelecionado(2);
        //Application.LoadLevel("Main");
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
}
