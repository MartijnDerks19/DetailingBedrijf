using DataLaag.DTOs;
using InterfaceLaag.DTOs;
using InterfaceLaag.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaag.DataToegang 
{
    public class AfspraakDataToegang : ICRUDCollectie<AfspraakDTO>
    {
        private IConfiguration _configuration;
        private string _connectionString;
        public AfspraakDataToegang(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
            _connectionString = connectionString;
        }

        public void Aanmaken(AfspraakDTO entiteit)
        {
            throw new NotImplementedException();
        }

        public void AanpassenOpID(int id, AfspraakDTO entiteit)
        {
            throw new NotImplementedException();
        }

        public List<AfspraakDTO> AllesOphalen()
        {
            throw new NotImplementedException();
        }

        public AfspraakDTO OphalenOpID(int id)
        {
            throw new NotImplementedException();
        }

        public void VerwijderenOpID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
