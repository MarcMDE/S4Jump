using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = new Vector3(0, 0.5f, other.transform.position.z);
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
