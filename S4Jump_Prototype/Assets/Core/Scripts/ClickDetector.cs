using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ClickDetector
    {
        public float _clickDuration = 0.15f; // Tiempo m�ximo para considerar un clic v�lido
        private bool _clickDetected = false;
        private float _clickStartTime = 0f;

        public bool KeyClick(KeyCode key)
        {
            // Detectar clic cuando se presiona el bot�n del rat�n
            if (Input.GetKeyDown(key))
            {
                _clickDetected = true;
                _clickStartTime = Time.time;
            }

            // Verificar si se ha soltado el bot�n del rat�n dentro del tiempo determinado
            if (_clickDetected && Input.GetKeyUp(key))
            {
                float clickDuration = Time.time - _clickStartTime;

                if (clickDuration <= this._clickDuration)
                {
                    Debug.Log("Clic v�lido!");
                    return true;
                }
                else
                {
                    Debug.Log("Clic no v�lido (tiempo excedido).");
                }

                _clickDetected = false; // Reiniciar la detecci�n de clic
            }

            return false;
        }
    }
}