using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int health = 100;


    // Use this for initialization
    void Start()
    {
        // Navigate to objective
        GameObject objective = GameObject.Find("JohnConnor");
        if (objective)
            GetComponent<NavMeshAgent>().destination = objective.transform.position;
    }

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

    void OnTriggerEnter(Collider co)
    {
        // If objective then deal Damage
        if (co.name == "JohnConnor")
        {
            co.GetComponentInChildren<Health>().decrease();
            Destroy(gameObject);
        }
    }
}
