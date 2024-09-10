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
    public void PunchAnim()
    {
        _animator.SetTrigger("Punch");
        StartCoroutine(WaitFor2Seconds());

    }
    public void KickAnim()
    {
        _animator.SetTrigger("Kick");
        StartCoroutine(WaitFor2SecondsKick());
    }
    public void HitAnim()
    {
        _animator.SetTrigger("Hit");
    }
    public void DeathAnim()
    {
        _animator.SetTrigger("Death");
    }

    IEnumerator WaitFor2Seconds()
    {
        yield return new WaitForSeconds(0.3f);
        Attack.Intance.PunchAttackp1 = false;
        Attack.Intance.PunchAttackp2 = false;
    }
    IEnumerator WaitFor2SecondsKick()
    {
        yield return new WaitForSeconds(0.3f);
        Attack.Intance.KickAttackp1 = false;
        Attack.Intance.KickAttackp2 = false;
    }
}
