using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private float _rotationSpeed = 2.0f;
    [SerializeField]
    private bool Grounded;

    //Handles
    private Rigidbody _rigidbody;
    private PlayerAnimations _anims;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _anims = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        Movement();
        AttackPlayer();


    }

    private void Movement()
    {
        float Horizontal = Input.GetAxis("Horizontal-2");
        float Vertical = Input.GetAxis("Vertical-2");

        Vector3 MovementDirection = new Vector3(Horizontal, 0.0f, Vertical).normalized;
        transform.Translate(MovementDirection * Time.deltaTime * _speed, Space.World);

        if (MovementDirection.magnitude > 0.5f)
        {
            Quaternion toRotate = Quaternion.LookRotation(MovementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, _rotationSpeed * Time.deltaTime);
        }

        //_anims.MoveAnim(Horizontal, Vertical);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
        }
    }
    private void AttackPlayer()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _anims.PunchAnim();
            Attack.Intance.PunchAttack = true;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            _anims.KickAnim();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
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
            _anims.JumpAnim();

        }
    }

}
