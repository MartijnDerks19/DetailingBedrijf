﻿using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataLaag.DataToegang
{
    public class AutoEigenaarDataToegang : IAutoEigenaar
    {
        private string _connectionString;
        private IConfiguration _configuration;
        public AutoEigenaarDataToegang(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
        }

        public List<AutoEigenaarDTO> AllesOphalen()
        {
            List<AutoEigenaarDTO> lijstVanAutoEigenaren = new List<AutoEigenaarDTO>();
            string query = "SELECT * FROM dbi495061.eigenaar ORDER BY Naam";
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

        public List<AutoDTO> AutosOphalenOpID(int eigenaarID)
        {
            throw new NotImplementedException();
        }

        public AutoEigenaarDTO OphalenOpID(int id)
        {
            AutoEigenaarDTO autoEigenaar = new AutoEigenaarDTO();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM dbi495061.eigenaar WHERE dbi495061.eigenaar.EigenaarID = @EigenaarID", connection))
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
            string query = "INSERT INTO dbi495061.eigenaar (Naam, Email) VALUES (@Naam, @Email)";

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

        public void AanpassenOpID(int id, AutoEigenaarDTO eigenaar)
        {
            string query = "UPDATE dbi495061.eigenaar (Email, Naam) VALUES (@Email, @Naam) WHERE EigenaarID = @EigenaarID";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Merk", MySqlDbType.String, 255).Value = eigenaar.Email;
                    cmd.Parameters.Add("@Type", MySqlDbType.String, 255).Value = eigenaar.Naam;
                    cmd.Parameters.Add("@EigenaarID", MySqlDbType.Int32, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
