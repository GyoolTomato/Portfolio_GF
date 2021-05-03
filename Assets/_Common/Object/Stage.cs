using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Resources.Object
{
    public class Stage : MonoBehaviour
    {
        private Common.GameManager m_gameManager;
        private DB.User.UserDataBase_Stage m_userDataBase_Stage;

        private Button m_button;
        private Text m_stageNumber;
        private Text m_name;
        private Image m_image;
        private Text m_challenge;

        public Stage()
        {
        }

        private void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();

            m_button = GetComponent<Button>();
            m_button.onClick.AddListener(Handle_Click);
            m_stageNumber = transform.Find("StageNumber").GetComponent<Text>();
            m_name = transform.Find("Name").GetComponent<Text>();
            m_image = transform.Find("Image").GetComponent<Image>();
            m_challenge = transform.Find("Challenge").GetComponent<Text>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {

        }

        public void ApplyValue(DB.User.UserDataBase_Stage data)
        {
            m_userDataBase_Stage = data;

            m_stageNumber.text = m_userDataBase_Stage.StageNumber + "-" + m_userDataBase_Stage.InnerNumber;
            m_name.text = m_userDataBase_Stage.Name;

            m_challenge.text = "도전 횟수 : " + m_userDataBase_Stage.Challenge;
        }

        private void Handle_Click()
        {
            m_gameManager.SetSelectedStage(m_userDataBase_Stage);
            SceneManager.LoadScene("Stage" + m_userDataBase_Stage.StageNumber + "-" + m_userDataBase_Stage.InnerNumber);
        }
    }
}
