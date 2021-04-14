using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Common.Controller;

namespace Assets.Common
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_instance;

        private DB.User.UserDataBase_Stage m_userDataBaseStage;

        private DB.Game.GameDBManager m_gameDBManager;
        private DB.Index.Manager.IndexDBManager m_indexDBManager;
        private DB.User.Manager.UserDBManager m_userDBManager;

        private SpriteController m_spriteController;
        private ResourceContorller m_resourceContorller;
        private IndexDBController m_indexDBController;
        private UserDBController m_userDBController;
        private StageBackupController m_stageBackupController;        

        private void Awake()
        {
            if (m_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
            DontDestroyOnLoad(gameObject);
            
            m_gameDBManager = new DB.Game.GameDBManager();
            m_gameDBManager.Initailize(this);
            m_indexDBManager = new DB.Index.Manager.IndexDBManager();
            m_indexDBManager.Initailize(this);
            m_userDBManager = new DB.User.Manager.UserDBManager();
            m_userDBManager.Initailize(this);

            m_spriteController = new SpriteController();
            m_resourceContorller = new ResourceContorller();
            m_resourceContorller.Initialize(this, m_userDBManager);
            m_indexDBController = new IndexDBController();
            m_indexDBController.Initialize(m_indexDBManager);
            m_userDBController = new UserDBController();
            m_userDBController.Initialize(m_userDBManager);
            m_stageBackupController = new StageBackupController();
            m_stageBackupController.Initialize(this);                       
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public ResourceContorller GetResourceContorller()
        {
            return m_resourceContorller;
        }

        public IndexDBController GetIndexDBController()
        {
            return m_indexDBController;
        }

        public UserDBController GetUserDBController()
        {
            return m_userDBController;
        }

        public StageBackupController GetStageBackupController()
        {
            return m_stageBackupController;
        }

        public SpriteController GetSpriteController()
        {
            return m_spriteController;
        }

        public DB.User.UserDataBase_Stage SelectedStage
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

        public void SetSelectedStage(DB.User.UserDataBase_Stage data)
        {
            m_userDataBaseStage = data;
        }
    }
}
