using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataLaag.DataToegang
{
    public class AutoDataToegang : IAuto
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        
        public AutoDataToegang(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
        }


        public List<AutoDTO> AllesOphalen()
        {
            List<AutoDTO> lijstVanAutos = new List<AutoDTO>();
            string query = "SELECT * FROM dbi495061.auto ORDER BY Merk";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var auto = new AutoDTO()
                        {
                            AutoID = reader.GetInt32(0),
                            Merk = reader.GetString(1),
                            Type = reader.GetString(2),
                            Bouwjaar = reader.GetInt32(3),
                            EigenaarID = reader.GetInt32(4),
                        };
                        lijstVanAutos.Add(auto);
                    }
                }
                connection.Close();
            }
            return lijstVanAutos;
        }
        
        public List<AutoDTO> AllesOphalenVoorEigenaar(int id)
        {
            List<AutoDTO> lijstVanAutos = new List<AutoDTO>();
            string query = "SELECT dbi495061.auto.AutoID, dbi495061.auto.Merk, dbi495061.auto.Type, dbi495061.auto.Bouwjaar, dbi495061.auto.EigenaarID FROM " +
                           "dbi495061.auto INNER JOIN dbi495061.eigenaar ON auto.EigenaarID = eigenaar.EigenaarID WHERE eigenaar.EigenaarID = @id";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@id", MySqlDbType.Int64, 255).Value = id;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var auto = new AutoDTO()
                        {
                            AutoID = reader.GetInt32(0),
                            Merk = reader.GetString(1),
                            Type = reader.GetString(2),
                            Bouwjaar = reader.GetInt32(3),
                            EigenaarID = reader.GetInt32(4),
                        };
                        lijstVanAutos.Add(auto);
                    }
                }
                connection.Close();
            }
            return lijstVanAutos;
        }

        public AutoDTO OphalenOpID(int id)
        {
            AutoDTO auto = new AutoDTO();
            string query = "SELECT * FROM dbi495061.auto WHERE AutoID = @AutoID";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@AutoID", MySqlDbType.Int64, 255).Value = id;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        auto.AutoID = reader.GetInt32(0);
                        auto.Merk = reader.GetString(1);
                        auto.Type = reader.GetString(1);
                        auto.Bouwjaar = reader.GetInt32(1);
                        auto.EigenaarID = reader.GetInt32(1);
                    }
                }
                connection.Close();
            }
            return auto;
        }

        public void Aanmaken(AutoDTO auto)
        {
            string query = "INSERT INTO dbi495061.auto (Merk, Type, Bouwjaar, EigenaarID) VALUES (@Merk, @Type, @Bouwjaar, @EigenaarID)";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Merk", MySqlDbType.String, 255).Value = auto.Merk;
                    cmd.Parameters.Add("@Type", MySqlDbType.String, 255).Value = auto.Type;
                    cmd.Parameters.Add("@Bouwjaar", MySqlDbType.Int32, 255).Value = auto.Bouwjaar;
                    cmd.Parameters.Add("@EigenaarID", MySqlDbType.Int32, 255).Value = auto.EigenaarID;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void VerwijderenOpID(int id)
        {
            using (MySqlConnection connectie = new(_connectionString))
            {
                connectie.Open();
                using (MySqlCommand cmd = new("DELETE FROM dbi495061.auto WHERE AutoID = @AutoID", connectie))
                {
                    cmd.Parameters.Add("@AutoID", MySqlDbType.Int32, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connectie.Close();
            }
        }

        public void AanpassenOpID(int id, AutoDTO auto)
        {
            string query = "UPDATE dbi495061.auto (Merk, Type, Bouwjaar) VALUES (@Merk, @Type, @Bouwjaar) WHERE EigenaarID = @EigenaarID";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Merk", MySqlDbType.String, 255).Value = auto.Merk;
                    cmd.Parameters.Add("@Type", MySqlDbType.String, 255).Value = auto.Type;
                    cmd.Parameters.Add("@Bouwjaar", MySqlDbType.Int32, 255).Value = auto.Bouwjaar;
                    cmd.Parameters.Add("@EigenaarID", MySqlDbType.Int32, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
