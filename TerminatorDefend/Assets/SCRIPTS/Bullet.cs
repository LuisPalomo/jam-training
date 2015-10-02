using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float bullet_vel;
    bool bullet_stop = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right* Time.deltaTime * bullet_vel);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            //Destruye nuestra bala si colisiona con cualquier collider2d que no que no lleve el tag "Player".
            Destroy(gameObject);
        }

    }
}
