using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int health = 100;
	
	// Update is called once per frame
	void Update () {
        if (health<=0)
        {
            Dead();
        }
	}

    public void ApplyDamage(int dmg)
    {
        health -= dmg;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }


}
