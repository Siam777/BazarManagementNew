using app.Entities.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
namespace app.Entities.Models
{
    public partial class AppContext : IStoredProcedures
    {                                 
        //public string SprGetPIN(int userId)
        //{
        //    var userId_ = new SqlParameter("@UserInfoId", SqlDbType.Int);
        //    userId_.Value = userId;

        //    var pin = new SqlParameter("@PIN", SqlDbType.NVarChar, 32);
        //    pin.Direction = ParameterDirection.InputOutput;
        //    pin.Value = "";

        //    Database.ExecuteSqlCommand("SprGetPIN @UserInfoId @PIN out", userId_, pin);

        //    return (string)pin.Value;


        //}
        //public DataSet GetStudentReports(int instituteId, int? StudentId, string ClassId, string SectionId)
        //{
        //    AppContext _contex = new AppContext();
        //    SqlConnection con = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    con.ConnectionString = _contex.Database.Connection.ConnectionString;
        //    cmd.Connection = con;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "[PNSMS].[dbo].[SprStudentsReports] " + instituteId + "," + "'" + StudentId + "'" + "," + "'" + ClassId + "'" + "," + "'" + SectionId + "'";
        //    DataSet ds = new DataSet();
        //    System.Data.SqlClient.SqlDataAdapter ad = new SqlDataAdapter();
        //    ad.SelectCommand = cmd;
        //    ad.Fill(ds);
        //    con.Close();
        //    con.Dispose();
        //    cmd.Dispose();
        //    return ds;
        //}       
        public List<VmUserInfo> GetUserInfo(int InstituteId, string SearchItem)
        {
            var Institute = new SqlParameter("@InstituteId", SqlDbType.Int);
            Institute.Value = InstituteId;
            var Text = new SqlParameter("@SearchItem", SqlDbType.NVarChar, 50);
            Text.Value = SearchItem;
            return Database.SqlQuery<VmUserInfo>("spUserInfoSearch  @InstituteId,@SearchItem", Institute,Text).ToList();
            //List<VmUserInfo> lstVmUserInfo = new List<VmUserInfo>(); 
                       
            //using (var multi = Database.Connection.QueryMultiple("[dbo].[spUserInfoSearch] " + InstituteId + "," + "'" + SearchItem + "'"))
            //{
            //    lstVmUserInfo = multi.Read<VmUserInfo>().ToList();
            //}

            //return lstVmUserInfo;
        } 
        public List<VmMealManagement> GetMealManagementList(int InstituteId,string date)
        {
            var Institute = new SqlParameter("@InstituteId", SqlDbType.Int);
            Institute.Value = InstituteId;
            var Date = new SqlParameter("@Date", SqlDbType.NVarChar,50);
            Date.Value = date;
            var List= Database.SqlQuery<VmMealManagement>("MealManagementProcess @InstituteId, @Date",Institute,Date).ToList();
            return List;
        }
        public List<VmBazarReport> GetBazarReport(int InstituteId, int MonthId,int Year,int ReportTypeId)
        {
            var Institute = new SqlParameter("@InstituteId", SqlDbType.Int);
            Institute.Value = InstituteId;
            var Month  = new SqlParameter("@MonthId", SqlDbType.Int);
            Month.Value = MonthId;
            var year = new SqlParameter("@Year", SqlDbType.Int);
            year.Value = Year;
            var ReportType = new SqlParameter("@ReportTypeId", SqlDbType.Int);
            ReportType.Value = ReportTypeId;
            var List = Database.SqlQuery<VmBazarReport>("MonthlyBazarReport @InstituteId, @MonthId,@Year,@ReportTypeId", Institute, Month,year,ReportType).ToList();
            return List;
        }
        public string BazarProcess(int InstituteId, int MonthId, int Year)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AppContext"].ConnectionString;
            SqlConnectionStringBuilder SConn = new SqlConnectionStringBuilder(connectionString);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "MonthlyBazarProcess";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par = new SqlParameter("@InstituteId", SqlDbType.Int);
            cmd.Parameters.Add(par).Value = InstituteId;

            SqlParameter par1 = new SqlParameter("@MonthId", SqlDbType.Int);
            cmd.Parameters.Add(par1).Value = MonthId;

            SqlParameter par2 = new SqlParameter("@Year", SqlDbType.Int);
            cmd.Parameters.Add(par2).Value = Year;            
            SqlParameter parOut = new SqlParameter("@Msg", SqlDbType.VarChar, 2000);
            parOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parOut);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            string Msg = "";
            Msg = parOut.Value.ToString();
            con.Close();
            con.Dispose();
            cmd.Dispose();
            return Msg;
        }
    }
}
