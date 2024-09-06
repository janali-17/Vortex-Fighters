using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
     transform.Translate (Input.GetAxis("Horizontal")*Time.deltaTime,0.0f,0.0f * _speed);
     transform.Translate (0.0f,0.0f, Input.GetAxis("Vertical") * _speed * Time.deltaTime);
    }
}
