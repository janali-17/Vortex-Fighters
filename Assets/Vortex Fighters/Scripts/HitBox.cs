using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if((other.tag == "Hand") && Attack.Intance.PunchAttack == true)
        {
            Debug.Log("Hit Box");
        }
    }
}
