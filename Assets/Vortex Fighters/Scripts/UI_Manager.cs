using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _Pause_Panel;
    [SerializeField]
    private Button Resume;
    [SerializeField]
    private Button Main;
    [SerializeField]
    private Button Quit;
    [SerializeField]
    private Button Restart;
    [SerializeField]
    private Animator _animator;

    


    private static UI_Manager _instance;
    public static UI_Manager Instance
    {
        set { }
        get
        {
            if (_instance == null)
            {
                Debug.Log("UI instance is Null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    private void OnEnable()
    {
        Resume.onClick.AddListener(() => buttonCallBack(Resume));
        Main.onClick.AddListener(() => buttonCallBack(Main));
        Restart.onClick.AddListener(() => buttonCallBack(Restart));
        Quit.onClick.AddListener(() => buttonCallBack(Quit));
    }
    private void buttonCallBack(Button ButtonPressed)
    {
        if (ButtonPressed == Resume)
        {
            _animator.SetTrigger("Resume");
            _animator.SetBool("_Pause_Panel", false);
            Time.timeScale = 1.0f;
        }
        else if (ButtonPressed == Main)
        {
            SceneManager.LoadScene(0);
        }
        else if (ButtonPressed == Restart)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (ButtonPressed == Quit)
        {
            Application.Quit();
        }
    }
    public void PauseGame()
    {
        _animator.SetBool("_Pause_Panel", true);
        Time.timeScale = 0.0f;
    }

   
}
