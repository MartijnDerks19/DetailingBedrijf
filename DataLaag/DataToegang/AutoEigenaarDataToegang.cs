using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataLaag.DataToegang
{
    public class AutoEigenaarDataToegang : ICRUDCollectie<AutoEigenaarDTO>
    {
        private IConfiguration _configuration;
        private string _connectionString;
        public AutoEigenaarDataToegang(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
            _connectionString = connectionString;
        }

        public List<AutoEigenaarDTO> AllesOphalen()
        {
            List<AutoEigenaarDTO> lijstVanAutoEigenaren = new List<AutoEigenaarDTO>();
            string query = "SELECT * FROM eigenaar ORDER BY Naam";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var autoEigenaar = new AutoEigenaarDTO()
                        {
                            EigenaarID = reader.GetInt32(0),
                            Naam = reader.GetString(1),
                            Email = reader.GetString(2),
                        };
                        lijstVanAutoEigenaren.Add(autoEigenaar);
                    }
                }
                connection.Close();
            }
            return lijstVanAutoEigenaren;
        }

        public AutoEigenaarDTO OphalenOpID(int id)
        {
            AutoEigenaarDTO autoEigenaar = new AutoEigenaarDTO();
            string query = "SELECT * FROM eigenaar WHERE EigenaarID = @EigenaarID";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@EigenaarID", MySqlDbType.Int64, 255).Value = id;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        autoEigenaar.EigenaarID = reader.GetInt32(0);
                        autoEigenaar.Naam = reader.GetString(1);
                        autoEigenaar.Email = reader.GetString(2);
                    }
                }
                connection.Close();
            }
            return autoEigenaar;
        }

        public void Aanmaken(AutoEigenaarDTO autoEigenaar)
        {
            string query = "INSERT INTO eigenaar (Naam, Email) VALUES (@Naam, @Email)";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Naam", MySqlDbType.Enum, 255).Value = autoEigenaar.Naam;
                    cmd.Parameters.Add("@Naam", MySqlDbType.Enum, 255).Value = autoEigenaar.Email;
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
                using (MySqlCommand cmd = new("DELETE FROM eigenaar WHERE EigenaarID = @EigenaarID", connectie))
                {
                    cmd.Parameters.Add("@EigenaarID", MySqlDbType.Int32, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connectie.Close();
            }
        }

        public void AanpassenOpID(int id, AutoEigenaarDTO entiteit)
        {
            throw new NotImplementedException();
        }
    }
}
