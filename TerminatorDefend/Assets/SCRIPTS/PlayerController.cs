using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;

    void FixedUpdate()
    {
        //Obtengo valores numericos comprendidos entre 0 y 1 ó -1 y 0.
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody>().velocity =new Vector3 (maxSpeed*moveX,0, maxSpeed * moveZ);
    }

}
