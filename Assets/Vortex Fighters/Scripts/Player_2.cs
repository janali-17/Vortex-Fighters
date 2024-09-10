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
    private bool Grounded;
    [SerializeField]
    private Transform opponentPos;
    public int _Player2Lives = 6;
    private bool _IsDead = false;

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
        if (_IsDead == true)
        {
            return;
        }
        Movement();
        AttackPlayer();
        transform.LookAt(opponentPos);
        if (Input.GetKey(KeyCode.Escape))
        {
            UI_Manager.Instance.PauseGame();
        }
        if (_Player2Lives == 0)
        {
            _anims.DeathAnim();
            _IsDead = true;
        }
    }

    private void Movement()
    {
        float Horizontal = Input.GetAxis("Horizontal-2");
        float Vertical = Input.GetAxis("Vertical-2");

        Vector3 MovementDirection = new Vector3(Horizontal, 0.0f, Vertical).normalized;
        transform.Translate(MovementDirection * Time.deltaTime * _speed, Space.World);
        _anims.MoveAnim(Horizontal, Vertical);

        if (Input.GetKeyDown(KeyCode.B) && Grounded == true)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
        }
    }
    private void AttackPlayer()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _anims.PunchAnim();
            Attack.Intance.PunchAttackp2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            _anims.KickAnim();
            Attack.Intance.KickAttackp2 = true;
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
    private void Damage()
    {
        StartCoroutine(WaitforActive());
        _Player2Lives--;
        _anims.HitAnim();
        Health_Bar_Controller.Instance.UpdateLives_P2(_Player2Lives);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_IsDead == true)
        {
            return;
        }
        if ((other.tag == "Hand"|| other.tag == "Foot") && (Attack.Intance.PunchAttackp1 == true || Attack.Intance.KickAttackp1 == true))
        {
            Damage();
        }
    }
    IEnumerator WaitforActive()
    {
        yield return new WaitForSeconds(1.5f);
    }

}
