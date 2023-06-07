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
            List<DetailerDTO> detailers = new List<DetailerDTO>()
            {
                new DetailerDTO(){Naam = "John", DetailerID = 1},
                new DetailerDTO(){Naam = "Greet", DetailerID = 2},
                new DetailerDTO(){Naam = "Bob", DetailerID = 3},
                new DetailerDTO(){Naam = "Carolien", DetailerID = 4},
                new DetailerDTO(){Naam = "Bas", DetailerID = 5},
            };

            DetailerMockData data = new DetailerMockData(detailers);
            DetailerLogica logica = new DetailerLogica(data);
            int expectedCount = data.AlleDetailers.Count - 1;
            DetailerDTO deletedDTO = detailers[0];

            //Act 
            logica.VerwijderDetailer(detailers[0].DetailerID);

            //Assert
            Assert.Equal(expectedCount, data.AlleDetailers.Count);
            Assert.DoesNotContain(deletedDTO ,data.AlleDetailers);
        }

        [Fact]
        public void CheckOfDetailerWordtToegevoegdAanLijst()
        {
            //Arrange
            List<DetailerDTO> detailers = new List<DetailerDTO>()
            {
                new DetailerDTO(){Naam = "John", DetailerID = 1},
                new DetailerDTO(){Naam = "Greet", DetailerID = 2},
                new DetailerDTO(){Naam = "Bob", DetailerID = 3},
                new DetailerDTO(){Naam = "Carolien", DetailerID = 4},
            };

            DetailerDTO dto = new DetailerDTO()
            {
                Naam = "Bas",
                DetailerID = 5
            };

            DetailerMockData data = new DetailerMockData(detailers);
            DetailerLogica logica = new DetailerLogica(data);
            int expectedCount = data.AlleDetailers.Count + 1;

            //Act 
            logica.DetailerAanmaken(dto);

            //Assert
            Assert.Equal(expectedCount, data.AlleDetailers.Count);
            Assert.Contains(dto , data.AlleDetailers);
        }

        [Fact]
        public void AlsDetailerWordtToegevoegdMetInvalideDataDanThrowException()
        {
            //Arrange
            List<DetailerDTO> detailers = new List<DetailerDTO>();
            string expectedExceptionMessage = "De naam van een detailer moet ingevuld zijn!";
            DetailerMockData data = new DetailerMockData(detailers);
            DetailerLogica logica = new DetailerLogica(data);
            DetailerDTO dtoZonderNaam = new DetailerDTO()
            {
                DetailerID = 99
            };

            //Act 
            var actualErrorMessage = Assert.Throws<InvalidDataException>(() => logica.DetailerAanmaken(dtoZonderNaam));

            //Assert
            Assert.Equal(expectedExceptionMessage, actualErrorMessage.Message);
        }
    }
}
