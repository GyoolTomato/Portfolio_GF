using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Object
{
    public class Album_Equipment : MonoBehaviour
    {
        public delegate void ClickEvent();

        private ClickEvent m_clickEvent;

        private Button m_button;
        private Image m_character;
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

        private Assets.Common.ImageController m_imageController;
        private int m_ownershipCode;

        private void Awake()
        {
            m_button = this.GetComponent<Button>();
            m_button.onClick.AddListener(Handle_ClickEvent);
            m_character = transform.Find("Character").GetComponent<Image>();

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

        public void Initialize(Assets.Common.DB.Index.IndexDataBase_Equipment dBData, int ownershipCode, int level, int limitedPower, ClickEvent clickEvent = null)
        {
            ApplyDataCode(dBData);
            m_ownershipCode = ownershipCode;
            ApplyLimitedPower(limitedPower);
            ApplyLevel(level);
            m_clickEvent = clickEvent;
        }

        public int OwnershipCode()
        {
            return m_ownershipCode;
        }

        private void ApplyDataCode(Assets.Common.DB.Index.IndexDataBase_Equipment dBData)
        {
            //m_typeImage.sprite = m_imageController.LoadSprite(dBData.Type);

            var tempStar = string.Empty;
            for (int i = 0; i < dBData.Star; i++)
                tempStar += "★";

            m_star.text = tempStar;
            //m_character.sprite = m_imageController.LoadSprite(dBData.DataCode);
            m_name.text = dBData.Name;
            m_subName.text = dBData.Type;

            m_firePower.text = dBData.FirePower.ToString();
            m_focus.text = dBData.Focus.ToString();
            m_armor.text = dBData.Armor.ToString();
            m_critical.text = dBData.Critical.ToString();
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
                m_clickEvent();
        }
    }
}