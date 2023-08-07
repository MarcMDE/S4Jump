using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ClickDetector
    {
        public float _clickDuration = 0.15f; // Tiempo máximo para considerar un clic válido
        private bool _clickDetected = false;
        private float _clickStartTime = 0f;

        public bool KeyClick(KeyCode key)
        {
            // Detectar clic cuando se presiona el botón del ratón
            if (Input.GetKeyDown(key))
            {
                _clickDetected = true;
                _clickStartTime = Time.time;
            }

            // Verificar si se ha soltado el botón del ratón dentro del tiempo determinado
            if (_clickDetected && Input.GetKeyUp(key))
            {
                float clickDuration = Time.time - _clickStartTime;

                if (clickDuration <= this._clickDuration)
                {
                    Debug.Log("Clic válido!");
                    return true;
                }
                else
                {
                    Debug.Log("Clic no válido (tiempo excedido).");
                }

                _clickDetected = false; // Reiniciar la detección de clic
            }

            return false;
        }
    }
}