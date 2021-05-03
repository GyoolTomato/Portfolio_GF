using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Album
{
    public class BigAlbum_TDoll : MonoBehaviour
    {
        public delegate void Handle_SelectPlatoon(int platoonNumber, int sequence);

        private Assets.Common.GameManager m_gameManager;
        private DB.DbManager m_dbManager;

        private Handle_SelectPlatoon m_selectTDoll;
        private int m_platoonNumber;
        private int m_sequence;
        private int m_ownershipCode;

        private Image m_character;
        private Button m_selectButton;
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
            
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(int platoonNumber, int sequence, Handle_SelectPlatoon selectTDoll, SmallAlbum_Equipment.SelectEquipment selectEquipment)
        {            
            m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();

            m_selectTDoll = selectTDoll;
            m_platoonNumber = platoonNumber;
            m_sequence = sequence;

            m_character = transform.Find("Character").GetComponent<Image>();
            m_selectButton = transform.Find("Character").GetComponent<Button>();
            m_selectButton.onClick.AddListener(Handle_SelectTDoll);

            var informationTop = transform.Find("InformationTop");
            m_typeImage = informationTop.Find("Type").GetComponent<Image>();
            m_star = informationTop.Find("Star").GetComponent<Text>();

            var informationMid = transform.Find("InformationMid");
            m_name = informationMid.Find("Name").GetComponent<Text>();

            var informationBottom = transform.Find("InformationBottom");
            m_dummyLink = informationBottom.Find("DummyLink").GetComponent<Text>();
            m_level = informationBottom.Find("Level").GetComponent<Text>();

            m_equipment1 = transform.Find("Equipment1").GetComponent<SmallAlbum_Equipment>();
            m_equipment1.Initialize(selectEquipment);
            m_equipment2 = transform.Find("Equipment2").GetComponent<SmallAlbum_Equipment>();
            m_equipment2.Initialize(selectEquipment);
            m_equipment3 = transform.Find("Equipment3").GetComponent<SmallAlbum_Equipment>();
            m_equipment3.Initialize(selectEquipment);

            m_curtain = transform.Find("Curtain").gameObject;
            m_curtain.GetComponent<Button>().onClick.AddListener(Handle_SelectTDoll);
            SetCurtain(true);
        }

        public void ApplyData(int ownershipCode)
        {
            try
            {
                m_ownershipCode = ownershipCode;
                var userDB = m_dbManager.GetUserDBController().UserTDoll(m_ownershipCode);
                if (userDB != null)
                {
                    var indexDB = m_dbManager.GetIndexDBController().TDoll(userDB.DataCode);

                    var tempStar = string.Empty;
                    for (int i = 0; i < indexDB.Star; i++)
                        tempStar += "★";

                    m_name.text = indexDB.Name;

                    m_typeImage.sprite = m_gameManager.GetSpriteController().GetTypeImage(indexDB.Type);
                    m_character.sprite = m_gameManager.GetSpriteController().GetCharacterImage(userDB.DataCode);
                    ApplyDummyLink(userDB.DummyLink);
                    ApplyLevel(userDB.Level);
                    
                    m_equipment1.ApplyValue(m_ownershipCode, 1, userDB.EquipmentOwnershipNumber0);
                    m_equipment2.ApplyValue(m_ownershipCode, 2, userDB.EquipmentOwnershipNumber1);
                    m_equipment3.ApplyValue(m_ownershipCode, 3, userDB.EquipmentOwnershipNumber2);
                    
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

        private void Handle_SelectTDoll()
        {
            m_selectTDoll(m_platoonNumber, m_sequence);
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