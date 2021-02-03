using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.DB;
using Assets.Common.DB.Index;
using Assets.Common.DB.Index.Manager;

namespace Assets.Common.Controller
{
    public class IndexDBController
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
            All,
            Weapon,
            Armor,
            Tool,
            End,
        }

        private IndexDBManager m_dBManager;

        public IndexDBController()
        {
        }

        public void Initialize(IndexDBManager dBManager)
        {
            m_dBManager = dBManager;
        }

        public List<IndexDataBase_TDoll> TDoll(E_TDoll tDoll)
        {
            var temp = new ArrayList();
            var result = new List<IndexDataBase_TDoll>();

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

        public List<IndexDataBase_Equipment> Equipment(E_Equipment equipment)
        {
            var temp = new ArrayList();
            var result = new List<IndexDataBase_Equipment>();

            switch (equipment)
            {
                case E_Equipment.All:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.Equipment, QuerySupport_Index.SelectEquipment_All);
                    break;
                case E_Equipment.Weapon:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.Equipment, QuerySupport_Index.SelectEquipment_Weapon);
                    break;
                case E_Equipment.Armor:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.Equipment, QuerySupport_Index.SelectEquipment_Armor);
                    break;
                case E_Equipment.Tool:
                    temp = m_dBManager.ReadDataBase(IndexDBManager.E_Table.Equipment, QuerySupport_Index.SelectEquipment_Tool);
                    break;
                default:
                    break;
            }

            foreach (var item in temp)
            {
                result.Add(item as IndexDataBase_Equipment);
            }

            return result;
        }
        public IndexDataBase_Equipment Equipment(int dataCode)
        {
            var result = new IndexDataBase_Equipment();

            result = m_dBManager.ReadDataBase(IndexDBManager.E_Table.Equipment, QuerySupport_Index.SelectEquipment_DataCode(dataCode))[0] as IndexDataBase_Equipment;

            return result;
        }
    }
}