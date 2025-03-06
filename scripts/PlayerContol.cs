using UnityEngine;

[RequireComponent(typeof(CharacterController))] // Asegura que el GameObject tenga un CharacterController adjunto.
public class PlayerConrol : MonoBehaviour
{
    public Camera playerCamera; // Cámara del jugador para manejar la vista en primera persona.
    public float walkSpeed = 6f; // Velocidad de caminata.
    public float runSpeed = 12f; // Velocidad de carrera.
    public float jumpPower = 7f; // Fuerza del salto.
    public float gravity = 10f; // Intensidad de la gravedad.

    public float lookSpeed = 2f; // Sensibilidad de la cámara.
    public float lookXLimit = 45f; // Límite de rotación vertical de la cámara.

    Vector3 moveDirection = Vector3.zero; // Dirección del movimiento del personaje.
    float rotationX = 0; // Rotación en el eje X para el movimiento de la cámara.

    public bool canMove = true; // Variable para habilitar o deshabilitar el movimiento.

    CharacterController characterController; // Referencia al CharacterController.

    void Start()
    {
        characterController = GetComponent<CharacterController>(); // Obtiene el componente CharacterController.
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro de la pantalla.
        Cursor.visible = false; // Oculta el cursor.
    }

    void Update()
    {
        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward); // Obtiene la dirección hacia adelante.
        Vector3 right = transform.TransformDirection(Vector3.right); // Obtiene la dirección hacia la derecha.

        // Verifica si se está presionando Shift para correr.
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0; // Movimiento adelante/atrás.
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0; // Movimiento izquierda/derecha.
        float movementDirectionY = moveDirection.y; // Mantiene la componente Y del movimiento.
        moveDirection = (forward * curSpeedX) + (right * curSpeedY); // Calcula la nueva dirección del movimiento.

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower; // Aplica la fuerza de salto si el personaje está en el suelo.
        }
        else
        {
            moveDirection.y = movementDirectionY; // Mantiene la velocidad en Y si no está saltando.
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime; // Aplica gravedad cuando el personaje está en el aire.
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime); // Mueve el personaje.

        if (canMove)
        {
            // Controla la rotación vertical de la cámara.
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // Restringe la rotación vertical.
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // Controla la rotación horizontal del personaje.
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }
}
