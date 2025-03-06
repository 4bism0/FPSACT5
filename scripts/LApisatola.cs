using System;  // Espacio de nombres necesario para utilizar eventos y acciones.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada del manejo de disparos de la pistola.
public class LApisatola : MonoBehaviour
{
    [Header("References")] // Sección en el Inspector de Unity para organizar variables.
    [SerializeField] private GunData gunData; // Referencia a los datos del arma, configurables en el Inspector.

    private float timeSinceLastShot; // Tiempo transcurrido desde el último disparo.

    // Método que se ejecuta al iniciar el script.
    private void Start()
    {
        // Suscribe el método Shoot al evento shootInput de la clase disparo.
        disparo.shootInput += Shoot;
    }

    // Método que determina si se puede disparar.
    private bool CanShoot() =>
        !gunData.reloading && // Verifica que el arma no esté recargando.
        timeSinceLastShot > 1f / (gunData.fireRate / 60f); // Verifica que haya pasado suficiente tiempo desde el último disparo.

    // Método que maneja el disparo del arma.
    private void Shoot()
    {
        // Verifica si hay munición disponible.
        if (gunData.currentAmmo > 0)
        {
            // Verifica si es posible disparar según la tasa de fuego.
            if (CanShoot())
            {
                // Realiza un disparo mediante un Raycast en la dirección en la que apunta el arma.
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.collider.gameObject.name); // Muestra en consola el objeto impactado. Aquí es donde lo estaba probando y de la nada dejó de disparar y me rendí.
                }

                gunData.currentAmmo--; // Reduce la munición actual.
                timeSinceLastShot = 0; // Reinicia el tiempo desde el último disparo.
                OnGunShot(); // Llama a la función que maneja efectos visuales o de sonido (vacía por ahora).
            }
        }
    }

    // Método que actualiza el tiempo transcurrido desde el último disparo.
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime; // Suma el tiempo transcurrido en cada frame.
    }

    // Método que se ejecuta cuando el arma dispara (puede ser usado para efectos de sonido, animaciones, etc.).
    private void OnGunShot() { }
}
