using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    private Button m_EnterButton;

    private void Awake()
    {
        var vLogin = GameObject.Find("Login");
        var vEnter = vLogin.transform.Find("Enter").gameObject;
        m_EnterButton = vEnter.GetComponent<Button>();
        m_EnterButton.onClick.AddListener(AccountVerification);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AccountVerification()
    {
        SceneManager.LoadScene("Lobby");
    }
}
