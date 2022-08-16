using System;
using System.Data.SqlClient;
using Models;

namespace RepoLayer;
public class adonetaccess
{
    private static readonly SqlConnection conn = new SqlConnection("Server=tcp:mathiasriverasqlserver1.database.windows.net,1433;Initial Catalog=MathiasRiveraSample2;Persist Security Info=False;User ID=MathiasRiveraRevature1;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


}
                      