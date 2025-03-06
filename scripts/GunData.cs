using UnityEngine;  // Espacio de nombres para utilizar las funciones de Unity.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Este import est� duplicado, ya que ya se incluye previamente.

// Clase que define los datos del arma, utilizada como un ScriptableObject para la creaci�n de objetos en Unity.
[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    // Secci�n para la informaci�n b�sica del arma.
    [Header("Info")] // Secci�n organizada en el Inspector de Unity.
    public new string name; // Nombre del arma.

    // Secci�n para las estad�sticas relacionadas con el disparo.
    [Header("Shooting")]
    public float damage; // Da�o que realiza el arma por disparo.
    public float maxDistance; // Distancia m�xima que puede alcanzar el proyectil o el rayo.

    // Secci�n para las estad�sticas de recarga.
    [Header("Reloading")]
    public int currentAmmo; // Cantidad actual de munici�n en el arma.
    public int magSize; // Capacidad total del cargador (n�mero de disparos posibles antes de recargar).
    [Tooltip("In RPM")] public float fireRate; // Tasa de fuego del arma en disparos por minuto (RPM).
    public float reloadTime; // Tiempo necesario para recargar el arma.

    // Indicador de si el arma est� recargando o no.
    [HideInInspector] public bool reloading; // Se oculta en el Inspector, pero es accesible para el c�digo.
}
