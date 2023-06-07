using DataLaag.DTOs;
using InterfaceLaag.Interfaces;
using LogicaLaag.Logica;
using LogicaLaag.Mapping;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.MockDataToegang;

namespace TestProject.DetailerTesten
{
    public class DetailerTesten
    {
        [Theory]
        [InlineData(1)]
        public void CheckOfDetailerIsVerwijderdBestaandID(int id)
        {
            //Arrange
            DetailerMockData data = new DetailerMockData();
            DetailerLogica logica = new DetailerLogica(data);
            DetailerDTO dto = new DetailerDTO();

            //Act 
            int expectedCount = data.AlleDetailers.Count -1;
            logica.VerwijderDetailer(id);
            int actualCount = data.AlleDetailers.Count;

            //Assert
            Assert.Equal(expectedCount, actualCount); //does not contain
        }

        [Fact]
        public void CheckOfDetailerWordtToegevoegdAanLijst()
        {
            //Arrange
            DetailerMockData data = new DetailerMockData();
            DetailerLogica logica = new DetailerLogica(data);
            DetailerDTO dto = new DetailerDTO()
            {
                Naam = "Test",
                DetailerID = 99
            };

            //Act 
            int expectedCount = data.AlleDetailers.Count + 1;
            logica.DetailerAanmaken(dto);
            int actualCount = data.AlleDetailers.Count;

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void AlsDetailerWordtToegevoegdMetInvalideDataDanThrowException()
        {
            //Arrange
            string expectedExceptionMessage = "De naam van een detailer moet ingevuld zijn!";
            DetailerMockData data = new DetailerMockData();
            DetailerLogica logica = new DetailerLogica(data);
            DetailerDTO dto = new DetailerDTO()
            {
                DetailerID = 99
            };

            //Act 
            var actualErrorMessage = Assert.Throws<InvalidDataException>(() => logica.DetailerAanmaken(dto));

            //Assert
            Assert.Equal(expectedExceptionMessage, actualErrorMessage.Message);
        }
    }
}
