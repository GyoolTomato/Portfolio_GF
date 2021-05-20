using System;

namespace Assets.DB.Index.Manager
{
    public static class QuerySupport_Index
    {
        public static readonly string SelectTDoll_All = "SELECT * FROM TDoll";
        public static readonly string SelectTDoll_Magician = "SELECT * FROM TDoll where Type = \'Magician\'";
        public static readonly string SelectTDoll_Archer = "SELECT * FROM TDoll where Type = \'Archer\'";
        public static readonly string SelectTDoll_Knight = "SELECT * FROM TDoll where Type = \'Knight\'";
        public static string SelectTDoll_DataCode(int dataCode)
        {
            var result = string.Empty;
            result = "SELECT * FROM TDoll where DataCode = " + dataCode.ToString();

            return result;
        }
        public static readonly string SelectEquipment_All = "SELECT * FROM Equipment";
        public static readonly string SelectEquipment_Weapon = "SELECT * FROM Equipment where Type = \'Weapon\'";
        public static readonly string SelectEquipment_Armor = "SELECT * FROM Equipment where Type = \'Armor\'";
        public static readonly string SelectEquipment_Tool = "SELECT * FROM Equipment where Type = \'Tool\'";
        public static string SelectEquipment_DataCode(int dataCode)
        {
            var result = string.Empty;
            result = "SELECT * FROM Equipment where DataCode = " + dataCode.ToString();

            return result;
        }        
    }
}
