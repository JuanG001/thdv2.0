using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;  // Velocidad de movimiento
    public float jumpForce = 5f;  // Fuerza de salto
    public Transform cameraTransform;  // Cámara para el movimiento relativo

    private Rigidbody rb;
    private bool isGrounded;  // Verificar si el personaje está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Obtener el componente Rigidbody
        rb.freezeRotation = true;  // Evitar que el personaje gire por las físicas

        // Asignar la cámara principal si no ha sido asignada manualmente
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // Obtener entrada del teclado para WSAD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento en base a la cámara
        Vector3 direction = cameraTransform.forward * moveVertical + cameraTransform.right * moveHorizontal;
        direction.y = 0;  // Ignorar la dirección Y para que no mueva hacia arriba o abajo

        // Aplicar el movimiento
        rb.MovePosition(transform.position + direction.normalized * moveSpeed * Time.deltaTime);

        // Detectar el salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    // Método para aplicar el salto
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Detectar cuándo el personaje está en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Asegúrate de que el piso tenga el tag "Ground"
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
