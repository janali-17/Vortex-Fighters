using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
    }
    public void MoveAnim(float Horizontal,float Vertical)
    {
        float Move = new Vector2 (Horizontal, Vertical).magnitude;
        _animator.SetFloat("Move",Move);      
        //_animator.SetFloat("Vertical", Mathf.Abs(Vertical));      
    }
    public void JumpAnim()
    {
        _animator.SetTrigger("Jumped");
    }
}
