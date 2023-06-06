using DataLaag.DTOs;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaag.DataToegang
{
    public class DetailerDataToegang
    {
        private IConfiguration _configuration;
        private string _connectionString;
        public DetailerDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
            _connectionString = connectionString;
        }

        public List<DetailerDTO> GetAllDetailers()
        {
            List<DetailerDTO> listOfDetailers = new List<DetailerDTO>();
            string query = "SELECT * FROM detailer";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var detailer = new DetailerDTO()
                        {
                            DetailerID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                        };
                        listOfDetailers.Add(detailer);
                    }
                }
                connection.Close();
            }
            return listOfDetailers;
        }

        public DetailerDTO GetDetailerByID(int id)
        {
            DetailerDTO detailer = new DetailerDTO();
            string query = "SELECT * FROM detailer WHERE DetailerID = @DetailerID";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int64, 255).Value = id;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        detailer.DetailerID = reader.GetInt32(0);
                        detailer.Name = reader.GetString(1);
                        detailer.Email = reader.GetString(2);
                    }
                }
                connection.Close();
            }
            return detailer;
        }

        public void AddDetailer(DetailerDTO detailer)
        {
            string query = "INSERT INTO detailer (Name, Email) VALUES (@Name, @Email)";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Name", MySqlDbType.Enum, 255).Value = detailer.Name;
                    cmd.Parameters.Add("@Email", MySqlDbType.Enum, 255).Value = detailer.Email;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteDetailerByID(int id)
        {
            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new("DELETE FROM detailer WHERE DetailerID = @DetailerID", connection))
                {
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int64, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
