using System;

namespace Assets.Common.DB
{
    public static class QuerySupport
    {
        public static string SelectTDoll_All = "SELECT * FROM TDoll";
        public static string SelectTDoll_Magician = "SELECT * FROM TDoll where Type = \'Magician\'";
        public static string SelectTDoll_Archer = "SELECT * FROM TDoll where Type = \'Archer\'";
        public static string SelectTDoll_Knight = "SELECT * FROM TDoll where Type = \'Knight\'";
        public static string SelectTDoll_DataCode(int dataCode)
        {
            var result = string.Empty;
            result = "SELECT * FROM TDoll where DataCode = " + dataCode.ToString();

            return result;
        }

        public static string SelectEquipment_All = "SELECT * FROM Equipment";
        public static string SelectEquipment_Weapon = "SELECT * FROM Equipment where Type = \'Weapon\'";
        public static string SelectEquipment_Armor = "SELECT * FROM Equipment where Type = \'Armor\'";
        public static string SelectEquipment_Tool = "SELECT * FROM Equipment where Type = \'Tool\'";
        public static string SelectEquipment_DataCode(int dataCode)
        {
            var result = string.Empty;
            result = "SELECT * FROM Equipment where DataCode = " + dataCode.ToString();

            return result;
        }

        public static string SelectMountedCheck(User.UserDataBase_Equipment data)
        {
            var result = string.Empty;

            result = "SELECT * FROM TDoll WHERE"
                + " EquipmentOwnershipNumber0=" + data.OwnershipCode
                + " EquipmentOwnershipNumber1=" + data.OwnershipCode
                + " EquipmentOwnershipNumber2=" + data.OwnershipCode;                

            return result;
        }
    }
}
