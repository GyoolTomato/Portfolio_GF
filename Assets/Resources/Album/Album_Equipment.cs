using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Album
{
    public class Album_Equipment : MonoBehaviour
    {
        public delegate void ClickEvent(int ownershipCode);

        private Common.GameManager m_gameManager;
        private ClickEvent m_clickEvent;

        private Button m_button;
        private Image m_character;
        private GameObject m_mountInformation;
        private Text m_mountInformationText;
        private Image m_typeImage;
        private Text m_star;
        private Text m_limitedPower;
        private Text m_level;
        private Text m_name;
        private Text m_subName;
        private Text m_firePower;
        private Text m_focus;
        private Text m_armor;
        private Text m_critical;

        private int m_ownershipCode;

        private void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();

            m_button = this.GetComponent<Button>();
            m_button.onClick.AddListener(Handle_ClickEvent);
            m_character = transform.Find("Character").GetComponent<Image>();
            m_mountInformation = transform.Find("MountInformation").gameObject;
            m_mountInformationText = m_mountInformation.transform.Find("Text").GetComponent<Text>();

            var informationTop = transform.Find("InformationTop");
            m_typeImage = informationTop.Find("Image").GetComponent<Image>();
            m_star = informationTop.Find("Star").GetComponent<Text>();

            var informationMid = transform.Find("InformationMid");
            m_limitedPower = informationMid.Find("LimitedPower").GetComponent<Text>();
            m_level = informationMid.Find("Level").GetComponent<Text>();

            var informationBottom = transform.Find("InformationBottom");
            var name = informationBottom.Find("Name");
            m_name = name.Find("Title").GetComponent<Text>();
            m_subName = name.Find("Sub").GetComponent<Text>();
            var spec = informationBottom.Find("Spec");
            m_firePower = spec.Find("FirePower").Find("Value").GetComponent<Text>();
            m_focus = spec.Find("Focus").Find("Value").GetComponent<Text>();
            m_armor = spec.Find("Armor").Find("Value").GetComponent<Text>();
            m_critical = spec.Find("Critical").Find("Value").GetComponent<Text>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(Assets.Common.DB.User.UserDataBase_Equipment userData, ClickEvent clickEvent = null)
        {
            m_ownershipCode = userData.OwnershipCode;
            ApplyDataCode(m_gameManager.GetIndexDBController().Equipment(userData.DataCode));
            ApplyMountInformation();            
            ApplyLimitedPower(userData.LimitedPower);
            ApplyLevel(userData.Level);
            m_clickEvent = clickEvent;
        }

        public int OwnershipCode()
        {
            return m_ownershipCode;
        }

        private void ApplyDataCode(Assets.Common.DB.Index.IndexDataBase_Equipment dBData)
        {
            var tempStar = string.Empty;
            for (int i = 0; i < dBData.Star; i++)
                tempStar += "★";

            m_typeImage.sprite = m_gameManager.GetSpriteController().GetTypeImage(dBData.Type);
            m_star.text = tempStar;
            m_character.sprite = m_gameManager.GetSpriteController().GetEquipmentImage(dBData.DataCode);
            m_name.text = dBData.Name;
            m_subName.text = dBData.Type;

            m_firePower.text = dBData.FirePower.ToString();
            m_focus.text = dBData.Focus.ToString();
            m_armor.text = dBData.Armor.ToString();
            m_critical.text = dBData.Critical.ToString();
        }

        private void ApplyMountInformation()
        {
            m_mountInformation.SetActive(false);

            var tempList = m_gameManager.GetUserDBController().UserTDoll();
            foreach (var item in tempList)
            {
                if (item.EquipmentOwnershipNumber0 == m_ownershipCode ||
                    item.EquipmentOwnershipNumber1 == m_ownershipCode ||
                    item.EquipmentOwnershipNumber2 == m_ownershipCode)
                {
                    var temp = m_gameManager.GetIndexDBController().TDoll(item.DataCode);
                    m_mountInformationText.text = temp.Name;
                    m_mountInformation.SetActive(true);
                    break;
                }
            }
        }

        private void ApplyLimitedPower(int limitedPower)
        {
            m_limitedPower.text = limitedPower.ToString() + "%";
        }

        private void ApplyLevel(int level)
        {
            m_level.text = "LV." + level.ToString();
        }

        private void Handle_ClickEvent()
        {
            if (m_clickEvent != null)
                m_clickEvent(m_ownershipCode);
        }
    }
}