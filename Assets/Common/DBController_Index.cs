using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.DB;

namespace Assets.Common
{
    public class DBController_Index
    {
        public enum E_TDoll
        {
            All,
            Magician,
            Archer,
            Knight,
            End,
        }

        public enum E_Equipment
        {
            End,
        }

        private DBController m_dBController;

        public DBController_Index()
        {
        }

        public void Initialize(DBController dBController)
        {
            m_dBController = dBController;
        }

        public List<IndexDataBase_TDoll> TDoll(E_TDoll tDoll)
        {
            var result = new List<IndexDataBase_TDoll>();

            switch (tDoll)
            {
                case E_TDoll.All:
                    result = m_dBController.ReadIndexDataBase_TDoll(QuerySupport.SelectTDoll_All);
                    break;
                case E_TDoll.Magician:
                    result = m_dBController.ReadIndexDataBase_TDoll(QuerySupport.SelectTDoll_Magician);
                    break;
                case E_TDoll.Archer:
                    result = m_dBController.ReadIndexDataBase_TDoll(QuerySupport.SelectTDoll_Archer);
                    break;
                case E_TDoll.Knight:
                    result = m_dBController.ReadIndexDataBase_TDoll(QuerySupport.SelectTDoll_Knight);
                    break;
                default:
                    break;
            }

            return result;
        }

        public IndexDataBase_TDoll TDoll(int dataCode)
        {
            var result = new IndexDataBase_TDoll();

            result = m_dBController.ReadIndexDataBase_TDoll(QuerySupport.SelectTDoll_DataCode(dataCode))[0];

            return result;
        }

        public List<IndexDataBase_Equipment> Equipment()
        {
            var result = new List<IndexDataBase_Equipment>();

            return result;
        }

        public IndexDataBase_Equipment Equipment(int dataCode)
        {
            var result = new IndexDataBase_Equipment();

            result = m_dBController.ReadIndexDataBase_Equipment(QuerySupport.SelectEquipment_DataCode(dataCode))[0];

            return result;
        }
    }
}