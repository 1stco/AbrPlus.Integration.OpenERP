using AbrPlus.Integration.OpenERP.Enums;
using System;
using System.Data;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    public static class TrackingHelper
    {
        public static ActionType GetChangeTableActionType(this DataRow changeTableRowItem)
        {
            string type = changeTableRowItem.Field<string>("SYS_CHANGE_OPERATION");

            if (type == "I")
                return ActionType.Insert;
            if (type == "U")
                return ActionType.Update;
            if (type == "D")
                return ActionType.Delete;

            throw new Exception(string.Format("Unknow CHANGE_OPERATION type. [{0}]", type));
        }
    }
}
