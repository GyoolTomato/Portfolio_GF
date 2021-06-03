using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Objects.Album
{
    public class SmallAlbum_TDoll : MonoBehaviour
    {
        public delegate void ClickEvent(int ownershipCode);

        private Graphic.GraphicManager m_graphicManager;
        private DB.DbManager m_dbManager;

        private Image m_character;
        private Text m_level;
        private Text m_dummyLink;

        private void Awake()
        {
            m_graphicManager = GameObject.Find("GameManager").GetComponent<Graphic.GraphicManager>();
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();

            m_character = transform.Find("Character").GetComponent<Image>();

            var informationBottom = transform.Find("InformationBottom");
            m_level = informationBottom.Find("Level").GetComponent<Text>();
            m_dummyLink = informationBottom.Find("DummyLink").GetComponent<Text>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(DB.User.Base.UserDataBase_TDoll userData)
        {
            if (userData == null)
            {
                gameObject.SetActive(false);
                return;
            }
            else
                gameObject.SetActive(true);

            ApplyDataCode(m_dbManager.GetIndexDBController().TDoll(userData.DataCode));
            ApplyLevel(userData.Level);
            ApplyDummyLink(userData.DummyLink);
        }

        public void Initialize(Scenes.StageField.Controller.EnemyData.Base.EnemyMember enemyMember)
        {
            if (enemyMember == null)
            {
                gameObject.SetActive(false);
                return;
            }
            else
                gameObject.SetActive(true);

            ApplyDataCode(m_dbManager.GetIndexDBController().TDoll(enemyMember.IndexNumber));
            ApplyLevel(enemyMember.Level);
            ApplyDummyLink(enemyMember.DummyLink);
        }

        private void ApplyDataCode(DB.Index.IndexDataBase_TDoll dBData)
        {
            m_character.sprite = m_graphicManager.GetSpriteController().GetCharacterImage(dBData.DataCode);
        }

        private void ApplyLevel(int level)
        {
            m_level.text = "LV." + level.ToString();
        }

        private void ApplyDummyLink(int dummyLink)
        {
            m_dummyLink.text = "x" + dummyLink.ToString();
        }
    }
}