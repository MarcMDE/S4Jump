using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator.SetFloat("Horizontal", 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _animator.SetFloat("Horizontal", horizontalInput); 
    }
}
    