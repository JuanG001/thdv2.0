using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    public int health = 100;  // Vida del enemigo

    // Método que se llama cuando algo entra en el collider del enemigo
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si lo que colisionó es una bala (asegúrate de que la bala tenga la etiqueta "Bullet")
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Reduce la vida del enemigo
            TakeDamage(20);  // Asumimos que cada bala quita 20 de vida

            // Destruye la bala al impactar
            Destroy(collision.gameObject);
        }
    }

    // Método para manejar el daño
    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Método para destruir al enemigo cuando su vida llega a 0
    void Die()
    {
        Destroy(gameObject);  // Destruye al enemigo
    }
}

