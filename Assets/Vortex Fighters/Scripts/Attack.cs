using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool PunchAttackp1;
    public bool PunchAttackp2;
    public bool KickAttackp1;
    public bool KickAttackp2;

  private static  Attack _intance;
    public static Attack Intance
    {
        get
        {
            if (_intance == null)
            {
                Debug.Log("Attack instance is null");
            }
            return _intance;
        }
        set { }
    }

    private void Awake()
    {
        _intance = this;
    }
}
