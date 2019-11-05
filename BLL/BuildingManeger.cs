using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamHallManagentSystemApp.DAL.Models;
using ExamHallManagentSystemApp.DAL.Gateway;


namespace ExamHallManagentSystemApp.BLL
{
    public class BuildingManeger
    {
        BuildingGateWay aBuildingGateWay = new BuildingGateWay();
         public string SaveBuilding(BuildingInfo aBuildingInfo)
        {

             if(aBuildingGateWay.IsBuildingExsists(aBuildingInfo.Name))
             {

                 int rowAffect = aBuildingGateWay.UpdateBuildingInfo(aBuildingInfo);
                 if(rowAffect>0)
                 {
                     return "Update Successfull";
                 }
                 else
                 {
                     return "Update Failed";
                 }
             }

             else
             {
                 int rowAffect = aBuildingGateWay.SaveBuilding(aBuildingInfo);
                 if (rowAffect > 0)
                 {
                     return "Save Successfull";
                 }
                 else
                 {
                     return "Save failed";
                 }
             }
        }

    }
}