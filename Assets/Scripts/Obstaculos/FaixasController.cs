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
 

}
