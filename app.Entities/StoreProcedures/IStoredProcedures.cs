using app.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace app.Entities.Models
{
    public interface IStoredProcedures
    {

         List<VmUserInfo> GetUserInfo(int InstituteId, string SearchItem);
         List<VmMealManagement> GetMealManagementList(int InstituteId, string Date);
         List<VmBazarReport> GetBazarReport(int InstituteId, int MonthId, int Year, int ReportTypeId);
        string BazarProcess(int InstituteId, int MonthId, int Year);

    }
}
