using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SearchFlightModelLibrary;


namespace Airline_Reg_DAL_Library
{
    public class RegDAL
    {
        SqlConnection conn;
        SqlCommand cmdInsertUser, cmdFetchPassword,cmdFetchFlightDetails, cmdAddPassager;
        public RegDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conRegister"].ConnectionString);
        }

        public bool Insert_user(string ufname, string ulname, DateTime dob, string nat, string pnum, string gender, string gmail, string password)
        {
            bool return_value = false;
            cmdInsertUser = new SqlCommand("Insert_User", conn);
            cmdInsertUser.Parameters.Add("@ufname", SqlDbType.VarChar, 20);
            cmdInsertUser.Parameters.Add("@ulname", SqlDbType.VarChar, 20);
            cmdInsertUser.Parameters.Add("@dob", SqlDbType.Date);
            cmdInsertUser.Parameters.Add("@nat", SqlDbType.VarChar, 20);
            cmdInsertUser.Parameters.Add("@pnumber", SqlDbType.VarChar, 20);
            cmdInsertUser.Parameters.Add("@gender", SqlDbType.VarChar, 20);
            cmdInsertUser.Parameters.Add("@gmail", SqlDbType.VarChar, 20);
            cmdInsertUser.Parameters.Add("@password", SqlDbType.VarChar, 20);
            cmdInsertUser.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmdInsertUser.Parameters[0].Value = ufname;
            cmdInsertUser.Parameters[1].Value = ulname;
            cmdInsertUser.Parameters[2].Value = dob;
            cmdInsertUser.Parameters[3].Value = nat;
            cmdInsertUser.Parameters[4].Value = pnum;
            cmdInsertUser.Parameters[5].Value = gender;
            cmdInsertUser.Parameters[6].Value = gmail;
            cmdInsertUser.Parameters[7].Value = password;
            if (cmdInsertUser.ExecuteNonQuery() > 0)
            {
                return_value = true;
            }
            conn.Close();
            return return_value;



        }
        public string FetchPassword(string gmail)
        {
            cmdFetchPassword = new SqlCommand("proc_login", conn);
            cmdFetchPassword.Parameters.Add("@p_n", SqlDbType.VarChar, 20);
            cmdFetchPassword.Parameters.Add("@pass", SqlDbType.VarChar, 20);
            cmdFetchPassword.CommandType = CommandType.StoredProcedure;
            string password = null;

            conn.Open();

            cmdFetchPassword.Parameters[0].Value = gmail;
            cmdFetchPassword.Parameters[1].Direction = ParameterDirection.Output;
            cmdFetchPassword.ExecuteNonQuery();
            password = cmdFetchPassword.Parameters[1].Value.ToString();
            conn.Close();
            return password;

        }
        public List<SearchFlight> GetFlightDetails(string fldate,string source,string destination)
        {
            List<SearchFlight> details = new List<SearchFlight>();
            conn.Open();
            cmdFetchFlightDetails = new SqlCommand("proc_SearchFlight", conn);
            cmdFetchFlightDetails.Parameters.Add("@date", SqlDbType.VarChar, 10);
            cmdFetchFlightDetails.Parameters.Add("@source", SqlDbType.VarChar, 20);
            cmdFetchFlightDetails.Parameters.Add("@destination", SqlDbType.VarChar, 20);
            cmdFetchFlightDetails.CommandType = CommandType.StoredProcedure;
            cmdFetchFlightDetails.Parameters[0].Value = fldate;
            cmdFetchFlightDetails.Parameters[1].Value = source;
            cmdFetchFlightDetails.Parameters[2].Value = destination;
            SqlDataReader drFlightDetails = cmdFetchFlightDetails.ExecuteReader();
            SearchFlight search = null;
            while (drFlightDetails.Read())
            {
                search = new SearchFlight();
                search.Flightid = drFlightDetails[0].ToString();
                search.Departuretime = drFlightDetails[1].ToString();
                search.Arrivaltime = drFlightDetails[2].ToString();
                search.Duration = drFlightDetails[3].ToString();
                search.Fare = drFlightDetails[4].ToString();
                details.Add(search);
            }
            return details;

        }
        public bool Add_Passanger(string ps_name, string ps_age, string ps_gender)
        {
            bool return_value = false;
            cmdAddPassager = new SqlCommand("Insert_Passenger", conn);
            cmdAddPassager.Parameters.Add("@Ps_Name", SqlDbType.VarChar, 20);
            cmdAddPassager.Parameters.Add("@Ps_Age", SqlDbType.VarChar, 2);
            cmdAddPassager.Parameters.Add("@Ps_gender", SqlDbType.VarChar, 20);
            cmdAddPassager.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmdAddPassager.Parameters[0].Value = ps_name;
            cmdAddPassager.Parameters[1].Value = ps_age;
            cmdAddPassager.Parameters[2].Value = ps_gender;
            if (cmdAddPassager.ExecuteNonQuery() > 0)
            {
                return_value = true;
            }
            conn.Close();
            return return_value;


        }

    }
}

