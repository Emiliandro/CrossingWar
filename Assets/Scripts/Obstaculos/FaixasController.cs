using UnityEngine;
using System.Collections;

public class FaixasController : MonoBehaviour {

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -40);
        if (GetComponent<Rigidbody>().transform.position.z < -180)
        {
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
