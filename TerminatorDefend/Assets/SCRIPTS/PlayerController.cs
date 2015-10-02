using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;

    void FixedUpdate()
    {
        //Obtengo valores numericos comprendidos entre 0 y 1 ó -1 y 0.
        float moveY = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity =new Vector2 (maxSpeed*moveX, maxSpeed * moveY);
    }

}
