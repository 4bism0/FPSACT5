FPS Minigame - README
**Objetivo del Proyecto**
El objetivo de este proyecto es desarrollar un minijuego de disparos en primera persona (FPS) donde se puedan implementar enemigos con diferentes comportamientos. Se debe agregar la capacidad de disparar hacia donde el jugador esté apuntando, junto con tres tipos de enemigos que interactúan con el jugador de diferentes maneras. Además, se requiere que se resuelva un error en el código relacionado con un script faltante que estaba interfiriendo con el funcionamiento del juego.

Lo que se ha logrado hasta ahora
**Disparo funcional:** Se implementó la capacidad de disparar hacia donde el jugador esté apuntando. Esto se logró utilizando un Raycast que dispara un rayo en la dirección en la que el jugador está mirando y detecta si hay un objeto (por ejemplo, un enemigo) en esa dirección.
La línea de código Debug.Log(hitInfo.collider.gameObject.name); se utilizó para imprimir en la consola el nombre del objeto al que el rayo impactó, lo que permitió verificar que el disparo estaba funcionando correctamente.

**Enemigo estático (con cambio de color según vida):**
Se comenzó a implementar un enemigo estático que cambia de color según la cantidad de vidas que le quedan. El cambio de color se realiza en función de su vida restante (verde para 3 vidas, amarillo para 2, y rojo para 1).
Este enemigo debería destruirse cuando sus vidas lleguen a 0.

**Error por el cual me rendí:**
Se presentó un error en el que el juego dejó de disparar y marcaba el siguiente mensaje en la consola: [11:17:54] The referenced script (Unknown) on this Behaviour is missing!.
Este error se debía a que uno de los scripts en el proyecto estaba vacío o faltaba, lo que causó que se dejara de ejecutar correctamente el código. Después de investigar, se eliminó el script vacío, lo que resolvió el problema del error, pero el disparo seguía sin funcionar.

Lo que falta por hacer
Enemigo estático con vida que se destruye
Enemigo que se acerca al jugador
Enemigo volador con ruta en el cielo:

Estuve muuuchos días intentando hacer el proyecto pero no lo pude completar, hice o mejor que pude
