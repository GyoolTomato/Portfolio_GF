using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Graphic.Controller;

namespace Assets.Graphic
{
    public class GraphicManager : MonoBehaviour
    {
        private static GraphicManager m_instance;

        private DB.User.Base.UserDataBase_Stage m_userDataBaseStage;

        private SpriteController m_spriteController;

        private void Awake()
        {
            if (m_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
            DontDestroyOnLoad(gameObject);           

            m_spriteController = new SpriteController();                 
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public SpriteController GetSpriteController()
        {
            return m_spriteController;
        }

        public DB.User.Base.UserDataBase_Stage SelectedStage
        {
            get
            {
                return m_userDataBaseStage;
            }
            set
            {
                m_userDataBaseStage = value;
            }
        }

        public void SetSelectedStage(DB.User.Base.UserDataBase_Stage data)
        {
            m_userDataBaseStage = data;
        }
    }
}
