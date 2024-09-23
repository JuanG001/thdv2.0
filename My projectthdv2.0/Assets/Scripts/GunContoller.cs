using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;  // Aquí arrastrarás el prefab de BulletLite_02 en el Inspector
    public Transform bulletSpawn;    // El punto desde donde se disparan las balas (la punta del arma)
    public float bulletSpeed = 20f;  // Velocidad de la bala
    public float fireRate = 0.5f;    // Tasa de disparo (tiempo entre disparos)

    private float nextFireTime = 0f;

    void Update()
    {
        // Detectar si el jugador presiona el botón de disparo (por defecto "Fire1" es el clic izquierdo del ratón)
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        // Instanciar la bala en el punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Aplicar velocidad a la bala
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = bulletSpawn.forward * bulletSpeed;
        }

        // Destruir la bala después de 2 segundos para evitar que se acumule en la escena
        Destroy(bullet, 2.0f);
    }
}

