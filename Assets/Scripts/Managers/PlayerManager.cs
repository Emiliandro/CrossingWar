using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public GameObject goto1, goto2;

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
    }
}
