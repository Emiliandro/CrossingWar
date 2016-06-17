using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public float speed = 0f;
    public bool isPulando = false, isSubindo = false, isDescendo = false;
    public Text texto;
    public int total;
    public GameObject goto1, goto2;

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
            GetComponent<Rigidbody>().velocity = goto2.transform.position;

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
}
