using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    public Transform playerBody;  // La cápsula o cuerpo del jugador

    private float xRotation = 0f;

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtener los valores del movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical (limitada)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limitar la rotación vertical entre -90 y 90 grados

        // Aplicar la rotación a la cámara (vertical)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar el cuerpo del jugador (horizontal)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

