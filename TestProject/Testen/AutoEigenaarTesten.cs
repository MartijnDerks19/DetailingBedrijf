using DomeinLaag.DTOs;
using DomeinLaag.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.MockDataToegang;

namespace TestProject.Testen
{
    public class AutoEigenaarTesten
    {
        private AutoEigenaarCollectie _eigenaarCollectie;
        private AutoEigenaarMockData _eigenaarMock;


        public AutoEigenaarTesten()
        {
            AutoEigenaarMockData eigenaarMock = new();
            AutoMockData autoMock = new();
            AutoCollectie autoCollectie = new(autoMock);
            AutoEigenaarCollectie eigenaarCollectie = new(eigenaarMock, autoMock);

            _eigenaarCollectie = eigenaarCollectie;
            _eigenaarMock = eigenaarMock;
        }

        [Theory]
        [InlineData(30)]
        [InlineData(40)]
        public void CheckOfVerwijderMethodeWordtAangeroepenEnParametersHetzelfdeZijn(int id)
        {
            //Arrange
            int expectedID = id;
            //Act
            _eigenaarCollectie.VerwijderenOpID(id);

            //Assert
            Assert.Equal(expectedID, _eigenaarMock.VerwijderID);
        }

        [Fact]
        public void CheckOfAanmaakMethodeWordtAangeroepenEnParametersHetzelfdeZijn()
        {
            //Arrange
            AutoEigenaarDTO dto = new AutoEigenaarDTO()
            {
                EigenaarID = 2, 
                Email = "Test@test.nl"
            };

            //Act
            _eigenaarCollectie.Aanmaken(dto);

            //Assert
            Assert.Equal(dto.Naam, _eigenaarMock.DTO.Naam);
            Assert.Equal(dto.Naam, _eigenaarMock.DTO.Email);
        }
    }
}
