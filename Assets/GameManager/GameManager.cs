using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private WorkResourceManager m_workResourceManager;
        private DB.DBController m_dBController;
        private IndexDBController m_indexDBController;
        private UserDBController m_userDBController;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            m_workResourceManager = new WorkResourceManager();
            m_workResourceManager.Initialize();

            m_dBController = new DB.DBController();
            m_dBController.Initailize(this);

            m_indexDBController = new IndexDBController();
            m_indexDBController.Initialize(m_dBController);

            m_userDBController = new UserDBController();
            m_userDBController.Initialize(m_dBController);
        }

        // Start is called before the first frame update
        void Start()
        {
            m_workResourceManager.ApplySaveAmount();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public WorkResourceManager WorkResource
        {
            get
            {
                return m_workResourceManager;
            }
        }

        public IndexDBController IndexDBController
        {
            get
            {
                return m_indexDBController;
            }
        }

        public UserDBController UserDBController
        {
            get
            {
                return m_userDBController;
            }
        }
    }
}
