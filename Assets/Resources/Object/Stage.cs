using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Object
{
    public class Stage : MonoBehaviour
    {
        private Text m_stageNumber;
        private Text m_name;
        private Image m_image;
        private Text m_challenge;

        public Stage()
        {
        }

        private void Awake()
        {
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

        public void ApplyValue(Assets.Common.DB.User.UserDataBase_Stage data)
        {
            m_stageNumber.text = data.StageNumber + "-" + data.InnerNumber;
            m_name.text = data.Name;

            m_challenge.text = "도전 횟수 : " + data.Challenge;
        }
    }
}
