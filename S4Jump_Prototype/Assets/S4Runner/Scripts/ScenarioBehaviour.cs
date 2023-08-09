using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
