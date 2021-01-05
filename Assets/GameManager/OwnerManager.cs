using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameManager.DB;

namespace Assets.GameManager
{
    public class OwnerManager : MonoBehaviour
    {
        private DBManager m_dbManager;
        private List<DataBase_UserTDoll> m_userTDoll;
        private List<DataBase_UserEquipment> m_userEquipment;

        // Use this for initialization
        void Start()
        {
            m_dbManager = GameObject.Find("GameManager").gameObject.GetComponent<DBManager>();
            m_userTDoll = new List<DataBase_UserTDoll>();
            m_userEquipment = new List<DataBase_UserEquipment>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SupplyStartPack()
        {
            var startPack = new List<DataBase_TDoll>();

            m_dbManager.InsertUserDataBase(startPack);
        }
    }
}