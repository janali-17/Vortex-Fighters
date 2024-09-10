using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health_Bar_Controller : MonoBehaviour
{
    [SerializeField]
    private Image[] _P1;
    [SerializeField]
    private Image[] _P2;

    private static Health_Bar_Controller _instance;
    public static Health_Bar_Controller Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UI instance is Null");
            }
            return _instance;
        }
        set { }
    }
    private void Awake()
    {
        _instance = this;
    }

    public void UpdateLives_P1(int LivesRemaining)
    {
        for (int i = 0; i <= LivesRemaining; i++)
        {
            if (i == LivesRemaining)
            {
                _P1[i].enabled = false;
            }
        }
    }
    public void UpdateLives_P2(int LivesRemaining)
    {
        for (int i = 0; i <= LivesRemaining; i++)
        {
            if (i == LivesRemaining)
            {
                _P2[i].enabled = false;
            }
        }
    }
}
