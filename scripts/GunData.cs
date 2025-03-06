using UnityEngine;  // Espacio de nombres para utilizar las funciones de Unity.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Este import está duplicado, ya que ya se incluye previamente.

// Clase que define los datos del arma, utilizada como un ScriptableObject para la creación de objetos en Unity.
[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    // Sección para la información básica del arma.
    [Header("Info")] // Sección organizada en el Inspector de Unity.
    public new string name; // Nombre del arma.

    // Sección para las estadísticas relacionadas con el disparo.
    [Header("Shooting")]
    public float damage; // Daño que realiza el arma por disparo.
    public float maxDistance; // Distancia máxima que puede alcanzar el proyectil o el rayo.

    // Sección para las estadísticas de recarga.
    [Header("Reloading")]
    public int currentAmmo; // Cantidad actual de munición en el arma.
    public int magSize; // Capacidad total del cargador (número de disparos posibles antes de recargar).
    [Tooltip("In RPM")] public float fireRate; // Tasa de fuego del arma en disparos por minuto (RPM).
    public float reloadTime; // Tiempo necesario para recargar el arma.

    // Indicador de si el arma está recargando o no.
    [HideInInspector] public bool reloading; // Se oculta en el Inspector, pero es accesible para el código.
}
