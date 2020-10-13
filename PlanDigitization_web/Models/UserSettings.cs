using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanDigitization_web.Models
{
    public class Department
    {
        public string QueryType { get; set; }
        public string Dept_id { get; set; }
        public string Status { get; set; }
        public string Dept_name { get; set; }
        public string CompanyCode { get; set; }
        public string Unique_id { get; set; }
    }

    public class Roles
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string Unique_id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string RoleID { get; set; }
    }

    public class Permission
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string Unique_id { get; set; }
        public string RoleID { get; set; }
        public string Module_name { get; set; }
        public string View_form { get; set; }
        public string Edit_form { get; set; }
        public string Add_form { get; set; }
        public string Delete_form { get; set; }
    }

    public class Customer
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string DomainName { get; set; }
        public string ContactPerson_FirstName { get; set; }
        public string ContactPerson_LastName { get; set; }
        public string ContactPerson_Mobile_NO { get; set; }
        public string ContactPerson_Email { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Logo { get; set; }
        public string PreLogo { get; set; }
        public string Manager { get; set; }
        public bool IsActive { get; set; }
    }

    public class plant
    {
        public string QueryType { get; set; }
        public string PlantID { get; set; }
        public string PlantName { get; set; }
        public string PlantDescription { get; set; }
        public string PlantLocation { get; set; }
        public string TimeZone { get; set; }
        public string ParentOrganization { get; set; }
        public string Unique_id { get; set; }
        public string IsActive { get; set; }
    }

    public class Function
    {
        public string QueryType { get; set; }
        public string Unique_id { get; set; }
        public string FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
        public string ParentPlant { get; set; }
        public string PlantName { get; set; }
        public string IsActive { get; set; }
        public string CompanyCode { get; set; }
        public string Dept_id { get; set; }
    }

    public class Skill
    {
        public string QueryType { get; set; }
        public string Unique_id { get; set; }
        public string Skill_ID { get; set; }
        public string SkillName { get; set; }
        public string CompanyCode { get; set; }
    }

    public class users
    {
        public string QueryType { get; set; }
        public string Unique_id { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string RoleID { get; set; }
        public string SkillSet { get; set; }
        public string SkillName { get; set; }
        public string RoleName { get; set; }
        public string IsActive { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }
    public class usersettings
    {
        public string QueryType { get; set; }
        public string Parameter { get; set; }
        public string Parameter1 { get; set; }
    }
    public class assets
    {
        public string QueryType { get; set; }
        public string Unique_id { get; set; }
        public string AssetID { get; set; }
        public string FunctionName { get; set; }
        public string funname { get; set; }
        public string AssetName { get; set; }
        public string AssetDescription { get; set; }
        public string ShiftID { get; set; }
        public string sname { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Operations
    {
        public string QueryType { get; set; }
        public string Unique_id { get; set; }
        public string OperationID { get; set; }
        public string OperationName { get; set; }
        public string OperationDescription { get; set; }
        public string CompanyCode { get; set; }
    }

    public class Products
    {
        public string QueryType { get; set; }
        public string M_ID { get; set; }
        public string Variant_Code { get; set; }
        public string VariantName { get; set; }
        public string VariantDescription { get; set; }
        public string OperationName { get; set; }
        public string OpName { get; set; }
        public string AsName { get; set; }
        public string Machine_Code { get; set; }
        public string RecipeName { get; set; }
        public string CycleTime { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Holiday
    {
        public string QueryType { get; set; }
        public string Unique_id { get; set; }
        public string HolidayID { get; set; }
        public string HolidayReason { get; set; }
        public string PlantName { get; set; }

        public string PlantID { get; set; }
        public string Dates { get; set; }
        public DateTime Date { get; set; }
        public string CompanyCode { get; set; }
    }

    public class Operatorskill
    {
        public string QueryType { get; set; }
        public string O_ID { get; set; }
        public string OperatorID { get; set; }
        public string SkillName { get; set; }
        public string OperatorName { get; set; }
        public string SName { get; set; }
        public string ScoreValue { get; set; }
        public string CompanyCode { get; set; }
    }

    public class Alarm
    {
        public string QueryType { get; set; }
        public string ID { get; set; }
        public string A_ID { get; set; }
        public string Line_Code { get; set; }
        public string FunctionName { get; set; }
        public string Machine_Code { get; set; }
        public string AssetName { get; set; }
        public string Alarm_ID { get; set; }
        public string Alarm_Description { get; set; }
        public string CompanyCode { get; set; }
    }

    public class Rejectiondata
    {
        public string QueryType { get; set; }
        public string R_ID { get; set; }
        public string RejectionCode { get; set; }
        public string RejectionName { get; set; }
        public string RejectionDescription { get; set; }
        public string PName { get; set; }
        public string OName { get; set; }
        public string AName { get; set; }
        public string ProductName { get; set; }
        public string OperationName { get; set; }
        public string AssetName { get; set; }
        public string CompanyCode { get; set; }
    }

    public class Losses
    {
        public string QueryType { get; set; }
        public string ID { get; set; }
        public string Line_Code { get; set; }
        public string FunctionName { get; set; }
        public string Machine_Code { get; set; }
        public string AssetName { get; set; }
        public string Loss_ID { get; set; }
        public string Loss_Description { get; set; }
        public string CompanyCode { get; set; }
    }

    public class Toollist
    {
        public string QueryType { get; set; }
        public string ID { get; set; }
        public string Line_Code { get; set; }
        public string FunctionName { get; set; }
        public string AssetName { get; set; }
        public string ToolName { get; set; }
        public string ToolID { get; set; }
        public string UOM { get; set; }
        public string Make { get; set; }
        public string Classification { get; set; }
        public string Part_number { get; set; }
        public string RatedLifeCycle { get; set; }
        public string Machine_Code { get; set; }
        public string Conversion_parameter { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Operator
    {
        public string QueryType { get; set; }
        public string OP_ID { get; set; }
        public string OperatorName { get; set; }
        public string OperatorID { get; set; }
        public string AssetName { get; set; }
        public string AName { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Shift
    {
        public string QueryType { get; set; }
        public string ID { get; set; }
        public string ShiftName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public decimal BreakTime { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Changepassword
    {
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Input3 { get; set; }
    }

}