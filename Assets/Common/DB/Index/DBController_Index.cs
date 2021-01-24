using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.DB;
using Assets.Common.DB.Index;

namespace Assets.Common.DB.Index
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

        private IndexDBManager m_dBManager;

        public DBController_Index()
        {
        }

        public void Initialize(IndexDBManager dBManager)
        {
            m_dBManager = dBManager;
        }

        public List<IndexDataBase_TDoll> TDoll(E_TDoll tDoll)
        {
            var temp = new ArrayList();

            switch (tDoll)
            {
                case E_TDoll.All:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.TDoll, QuerySupport_Index.SelectTDoll_All);
                    break;
                case E_TDoll.Magician:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.TDoll, QuerySupport_Index.SelectTDoll_Magician);
                    break;
                case E_TDoll.Archer:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.TDoll, QuerySupport_Index.SelectTDoll_Archer);
                    break;
                case E_TDoll.Knight:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.TDoll, QuerySupport_Index.SelectTDoll_Knight);
                    break;
                default:
                    break;
            }

            var result = new List<IndexDataBase_TDoll>();

            foreach (var item in temp)
            {
                result.Add(item as IndexDataBase_TDoll);
            }

            return result;
        }

        public IndexDataBase_TDoll TDoll(int dataCode)
        {
            var result = new IndexDataBase_TDoll();

            result = m_dBManager.ReadDataBase(IndexDBManager.E_Table.TDoll, QuerySupport_Index.SelectTDoll_DataCode(dataCode))[0] as IndexDataBase_TDoll;

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

            result = m_dBManager.ReadDataBase(IndexDBManager.E_Table.Equipment, QuerySupport_Index.SelectTDoll_DataCode(dataCode))[0] as IndexDataBase_Equipment;

            return result;
        }
    }
}