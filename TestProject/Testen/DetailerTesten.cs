﻿using DomeinLaag.DTOs;
using DomeinLaag.Logica;
using TestProject.MockDataToegang;

namespace TestProject.Testen
{
    public class DetailerTesten
    {
        private DetailerCollectie _collectie;
        private DetailerMockData _mock;


        public DetailerTesten()
        {
            DetailerMockData mock = new DetailerMockData();
            DetailerCollectie collectie = new DetailerCollectie(mock);
            _collectie = collectie;
            _mock = mock;
        }

        [Theory]
        [InlineData(30)]
        [InlineData(40)]
        public void CheckOfVerwijderMethodeWordtAangeroepenEnParametersHetzelfdeZijn(int id)
        {
            //Arrange
            int expectedID = id;
            //Act
            _collectie.Verwijderen(id);

            //Assert
            Assert.Equal(expectedID, _mock.VerwijderID);
        }

        [Fact]
        public void CheckOfAanmaakMethodeWordtAangeroepenEnParametersHetzelfdeZijn()
        {
            //Arrange
            DetailerDTO dto = new DetailerDTO()
            {
                Naam = "Test",
                DetailerID = 120
            };

            //Act
            _collectie.Aanmaken(dto);

            //Assert
            Assert.Equal(dto.Naam, _mock.DTO.Naam);
            Assert.Equal(dto.DetailerID, _mock.DTO.DetailerID);
        }

        [Fact]
        public void AlsDetailerWordtToegevoegdMetInvalideDataDanThrowException()
        {
            //Arrange

            string expectedExceptionMessage = "De naam van een detailer moet ingevuld zijn!";
            DetailerDTO dtoZonderNaam = new DetailerDTO()
            {
                DetailerID = 99
            };

            //Act 
            var actualErrorMessage = Assert.Throws<InvalidDataException>(() => _collectie.Aanmaken(dtoZonderNaam));

            //Assert
            Assert.Equal(expectedExceptionMessage, actualErrorMessage.Message);
        }
    }
}
