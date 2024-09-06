using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private bool Grounded;

    //Handles
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
     transform.Translate (Input.GetAxis("Horizontal")*Time.deltaTime * _speed, 0.0f,Input.GetAxis("Vertical") * Time.deltaTime * _speed);

        if(Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x,_jumpForce,_rigidbody.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("On ground");
            Grounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("jumping");
            Grounded = false;
        }   
    }

}
