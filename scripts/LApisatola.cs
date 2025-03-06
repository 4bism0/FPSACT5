using System;  // Espacio de nombres necesario para utilizar eventos y acciones.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase encargada del manejo de disparos de la pistola.
public class LApisatola : MonoBehaviour
{
    [Header("References")] // Secci�n en el Inspector de Unity para organizar variables.
    [SerializeField] private GunData gunData; // Referencia a los datos del arma, configurables en el Inspector.

    private float timeSinceLastShot; // Tiempo transcurrido desde el �ltimo disparo.

    // M�todo que se ejecuta al iniciar el script.
    private void Start()
    {
        // Suscribe el m�todo Shoot al evento shootInput de la clase disparo.
        disparo.shootInput += Shoot;
    }

    // M�todo que determina si se puede disparar.
    private bool CanShoot() =>
        !gunData.reloading && // Verifica que el arma no est� recargando.
        timeSinceLastShot > 1f / (gunData.fireRate / 60f); // Verifica que haya pasado suficiente tiempo desde el �ltimo disparo.

    // M�todo que maneja el disparo del arma.
    private void Shoot()
    {
        // Verifica si hay munici�n disponible.
        if (gunData.currentAmmo > 0)
        {
            // Verifica si es posible disparar seg�n la tasa de fuego.
            if (CanShoot())
            {
                // Realiza un disparo mediante un Raycast en la direcci�n en la que apunta el arma.
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.collider.gameObject.name); // Muestra en consola el objeto impactado. Aqu� es donde lo estaba probando y de la nada dej� de disparar y me rend�.
                }

                gunData.currentAmmo--; // Reduce la munici�n actual.
                timeSinceLastShot = 0; // Reinicia el tiempo desde el �ltimo disparo.
                OnGunShot(); // Llama a la funci�n que maneja efectos visuales o de sonido (vac�a por ahora).
            }
        }
    }

    // M�todo que actualiza el tiempo transcurrido desde el �ltimo disparo.
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime; // Suma el tiempo transcurrido en cada frame.
    }

    // M�todo que se ejecuta cuando el arma dispara (puede ser usado para efectos de sonido, animaciones, etc.).
    private void OnGunShot() { }
}
