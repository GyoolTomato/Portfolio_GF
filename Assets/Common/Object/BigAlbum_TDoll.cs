using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.DB.Index;

namespace Assets.Common.Object
{
    public class BigAlbum_TDoll : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private Image m_character;
        private Image m_typeImage;
        private Text m_star;
        private Text m_name;
        private Text m_dummyLink;
        private Text m_level;
        private SmallAlbum_Equipment m_equipment1;
        private SmallAlbum_Equipment m_equipment2;
        private SmallAlbum_Equipment m_equipment3;
        private GameObject m_curtain;

        private void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
            m_character = transform.Find("Character").GetComponent<Image>();

            var informationTop = transform.Find("InformationTop");
            m_typeImage = informationTop.Find("Image").GetComponent<Image>();
            m_star = informationTop.Find("Star").GetComponent<Text>();

            var informationMid = transform.Find("InformationMid");
            m_name = informationMid.Find("Name").GetComponent<Text>();

            var informationBottom = transform.Find("InformationBottom");
            m_dummyLink = informationBottom.Find("DummyLink").GetComponent<Text>();
            m_level = informationBottom.Find("Level").GetComponent<Text>();

            m_equipment1 = transform.Find("Equipment1").GetComponent<SmallAlbum_Equipment>();
            m_equipment2 = transform.Find("Equipment2").GetComponent<SmallAlbum_Equipment>();
            m_equipment3 = transform.Find("Equipment3").GetComponent<SmallAlbum_Equipment>();

            m_curtain = transform.Find("Curtain").gameObject;
            SetCurtain(true);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }        

        public void ApplyData(int ownershipNumber)
        {
            try
            {
                var userDB = m_gameManager.UserDBController().UserTDoll(ownershipNumber);
                if (userDB != null)
                {
                    var indexDB = m_gameManager.IndexDBController().TDoll(userDB.DataCode);

                    var tempStar = string.Empty;
                    for (int i = 0; i < indexDB.Star; i++)
                        tempStar += "★";

                    m_name.text = indexDB.Name;

                    ApplyDummyLink(userDB.DummyLink);
                    ApplyLevel(userDB.Level);
                    m_equipment1.ApplyValue(userDB.EquipmentOwnershipNumber0);
                    m_equipment2.ApplyValue(userDB.EquipmentOwnershipNumber1);
                    m_equipment3.ApplyValue(userDB.EquipmentOwnershipNumber2);
                    SetCurtain(false);
                }
                else
                    SetCurtain(true);
            }
            catch
            {
                SetCurtain(true);
            }
        }

        private void ApplyLevel(int level)
        {
            m_level.text = "LV." + level.ToString();
        }

        private void ApplyDummyLink(int dummyLink)
        {
            m_dummyLink.text = "x" + dummyLink.ToString();
        }

        private void SetCurtain(bool set)
        {
            m_curtain.SetActive(set);
        }
    }
}