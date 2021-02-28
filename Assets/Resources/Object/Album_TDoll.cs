using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Object
{
    public class Album_TDoll : MonoBehaviour
    {
        public delegate void ClickEvent(int ownershipCode);

        private Common.GameManager m_gameManager;
        private ClickEvent m_clickEvent;

        private Button m_button;
        private Image m_character;
        private Image m_typeImage;
        private Text m_star;
        private Text m_level;
        private Text m_name;
        private Text m_dummyLink;
        private GameObject m_platoon;
        private Text m_platoonNumber;

        private int m_ownershipCode;

        private void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();

            m_button = this.GetComponent<Button>();
            m_button.onClick.AddListener(Handle_ClickEvent);
            m_character = transform.Find("Character").GetComponent<Image>();

            var informationTop = transform.Find("InformationTop");
            m_typeImage = informationTop.Find("Image").GetComponent<Image>();
            m_star = informationTop.Find("Star").GetComponent<Text>();

            var informationBottom = transform.Find("InformationBottom");
            m_level = informationBottom.Find("Level").GetComponent<Text>();
            m_name = informationBottom.Find("Name").GetComponent<Text>();
            m_dummyLink = informationBottom.Find("DummyLink").GetComponent<Text>();
            m_platoon = informationBottom.Find("Platoon").gameObject;

            m_platoonNumber = m_platoon.transform.Find("Platoon").GetComponent<Text>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(Assets.Common.DB.User.UserDataBase_TDoll userData, ClickEvent clickEvent = null)
        {
            m_ownershipCode = userData.OwnershipCode;
            m_character.sprite = m_gameManager.GetSpriteController().GetCharacterImage(userData.DataCode);
            ApplyDataCode(m_gameManager.IndexDBController().TDoll(userData.DataCode));            
            ApplyLevel(userData.Level);
            ApplyDummyLink(userData.DummyLink);
            ApplyPlatoonNumber();
            m_clickEvent = clickEvent;
        }

        public int OwnershipCode()
        {
            return m_ownershipCode;
        }

        private void ApplyDataCode(Assets.Common.DB.Index.IndexDataBase_TDoll dBData)
        {
            //m_typeImage.sprite = m_imageController.LoadSprite(dBData.Type);

            var tempStar = string.Empty;
            for (int i = 0; i < dBData.Star; i++)
                tempStar += "★";

            m_star.text = tempStar;
            //m_character.sprite = m_imageController.LoadSprite(dBData.DataCode);
            m_name.text = dBData.Name;
        }

        private void ApplyLevel(int level)
        {
            m_level.text = "LV." + level.ToString();
        }

        private void ApplyDummyLink(int dummyLink)
        {
            m_dummyLink.text = "x" + dummyLink.ToString();
        }

        private void ApplyPlatoonNumber()
        {
            var tempNumber = m_gameManager.UserDBController().FormationNumber(m_ownershipCode);

            if (tempNumber == 0)
            {
                m_platoon.SetActive(false);
            }
            else
            {
                m_platoon.SetActive(true);
                m_platoonNumber.text = tempNumber.ToString();
            }
        }

        private void Handle_ClickEvent()
        {
            if (m_clickEvent != null)
                m_clickEvent(m_ownershipCode);
        }
    }
}