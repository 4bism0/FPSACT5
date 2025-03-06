using System;  // Se utiliza para las acciones (delegados).
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada de gestionar la detección de entrada del jugador para disparar y recargar.
public class disparo : MonoBehaviour
{
    // Acciones estáticas que permiten suscribirse a eventos de disparo y recarga.
    public static Action shootInput;  // Se ejecuta cuando el jugador dispara.
    public static Action reloadInput; // Se ejecuta cuando el jugador recarga.

    // Tecla configurada para la recarga, por defecto es 'R'.
    [SerializeField] private KeyCode reloadKey = KeyCode.R;

    // Método que se ejecuta en cada frame.
    private void Update()
    {
        // Verifica si el jugador ha presionado el botón izquierdo del ratón.
        if (Input.GetMouseButton(0))
            shootInput?.Invoke(); // Llama al evento de disparo si hay suscriptores.

        // Verifica si el jugador ha presionado la tecla de recarga.
        if (Input.GetKeyDown(reloadKey))
            reloadInput?.Invoke(); // Llama al evento de recarga si hay suscriptores.
    }
}
