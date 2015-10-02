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

        /*Calculamos la diferencia entre el vector3 de posicion del raton y la posicion de nuestro personaje.
        Lo normalizamos para hallar su vector unitario no nos interesa su modulo solo su direccion*/
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        /*Obtenemos en radiales el angulo que forma el* vector introducido en el metodo respecto al eje X.
         Convertimos en grados el resultado. Cambiamos la rotacion de nuestro GameObject  usando el valor obtenido y el valor offSetDegree*/
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offSetDegree);
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100);
        Debug.DrawLine(firePointPosition, mousePosition, Color.yellow);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

}
