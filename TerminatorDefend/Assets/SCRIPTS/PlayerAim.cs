using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour {
    
    //Cadencia de disparo.
    public float fireRate = 0;
    //Desfase en el apuntado.
    public float offSetDegree = 90;

    //Bala que se instancia.
    public Transform bullet;
    //GameObject donde se instanciara la bala.
    public Transform firePoint;
    public LayerMask notToHit;

   //Municion.
    public int ammunition = 0;

    //Valor que se usa para comparar con Time.time.
    float timeToFire = 0;

    // Use this for initialization
    void Awake()
    {
        if (firePoint == null)
        {
            Debug.LogError("No firePoint");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (fireRate == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

        Ray rayShoot = new Ray(firePoint.position, firePoint.forward);
        Physics.Raycast(rayShoot,50);
        Debug.DrawLine(rayShoot.origin, rayShoot.direction*100, Color.cyan);
        Vector3 dirAim = Input.mousePosition;
        dirAim.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        
        dirAim = Camera.main.ScreenToWorldPoint(dirAim);
        transform.LookAt(dirAim);
       
    }

    void Shoot()
    {
        
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

}
