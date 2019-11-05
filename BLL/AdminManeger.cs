using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;

namespace ExamHallManagentSystemApp.BLL
{
    public class AdminManeger
    {
        AdminGateWay aAdminGateWay= new AdminGateWay();

          public string SaveAdmin(AdminInfo aAdminInfo)
        {

              if(aAdminGateWay.IsAdminExsists(aAdminInfo.Code))
              {
                  return "Already registered";
              }

              else
              {
                  int rowAffect = Convert.ToInt32(aAdminGateWay.SaveAdmin(aAdminInfo));
                  if (rowAffect > 0)
                  {
                      return "Save successfully";
                  }
                  else
                  {
                      return "Save failed";
                  }
              }
          
        }

          public bool IsAdminExsists(string Code)
        {
            return aAdminGateWay.IsAdminExsists(Code);
        }

          public AdminInfo GetAdmin(string Code)
        {
            return aAdminGateWay.GetAdmin(Code);
        }
    }
    
}