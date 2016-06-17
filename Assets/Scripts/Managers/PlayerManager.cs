using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Mortais")
        {
            Destroy(this.gameObject);
        }
    }
}
