using System;
using System.Data.SqlClient;
using System.Numerics;
using Models;


namespace RepoLayer;
public class ReimbursementRepoLayer
{


    public async Task<List<Request>> RequestsAsync(int type)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=MathiasRiveraSample2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT * FROM Request WHERE Status = @type", conn))
        {
            command.Parameters.AddWithValue("@type", type); //SQL inj prevention
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            List<Request> rlist = new List<Request>();
            while (ret.Read())
            {
                Request r = new Request((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));
                rlist.Add(r);
            }
            conn.Close();
            return rlist;
        }

    }
    public async Task<bool> IsManagerAsync(Guid employeeID)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=MathiasRiveraSample2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT IsManager FROM Employees WHERE EmployeeID = @id", conn))
        {
            command.Parameters.AddWithValue("@id", employeeID); //SQL inj prevention
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            if (ret.Read()&& ret.GetBoolean(0))
            {
                conn.Close();
                return true;
                }
            }
            conn.Close();
            return false;
        }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="RequestID"></param>
    /// <param name="Status"></param>
    /// <returns></returns>
    public async Task<UpdatedRequestDto> UpdateRequestsAsync(Guid RequestID, int Status)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=MathiasRiveraSample2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"UPDATE Request SET Status = @status WHERE RequestID = @id", conn))
        {
            command.Parameters.AddWithValue("@id", RequestID); //SQL inj prevention
            command.Parameters.AddWithValue("Status", Status); //SQL inj prevention
            conn.Open();
            int ret = await command.ExecuteNonQueryAsync();
            if (ret == 1)
            {
                conn.Close();
                UpdatedRequestDto urbi = await this.UpdateRequestByIDAsync(RequestID);
                return urbi;
            }
        }
        conn.Close();
        return null;
    }

    public async Task<UpdatedRequestDto> UpdateRequestByIDAsync(Guid requestID)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=MathiasRiveraSample2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT RequestID, FirstName, LastName, Status FROM Employees" +
            $" LEFT JOIN Request ON EmployeeID = FK_EmployeeID WHERE RequestID = @requestID", conn))
        {
            command.Parameters.AddWithValue("@requestid", requestID); //SQL inj prevention
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            if (ret.Read())
            {
                UpdatedRequestDto r = new UpdatedRequestDto(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3));
                conn.Close();
                return r;
            }
        }
        conn.Close();
        return null;
    }

    public async Task<bool> CheckForPending(Guid requestID)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=MathiasRiveraSample2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password=JohnDaniel(9);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT * FROM Request WHERE requestID = @id", conn))
        {
            command.Parameters.AddWithValue("@id", requestID); //SQL inj prevention
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            List<Request> rlist = new List<Request>();
            while (ret.Read())
            {
                Request r = new Request((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));
                if (r.Status == 0)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
    }
}


                      