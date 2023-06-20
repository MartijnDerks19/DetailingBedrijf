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
    public class AutoTesten
    {
        private AutoCollectie _collectie;
        private AutoMockData _mock;


        public AutoTesten()
        {
            AutoMockData mock = new();
            AutoCollectie collectie = new(mock);
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
            AutoDTO dto = new AutoDTO()
            {
                Merk = "Pagani",
                Type = "Zonda",
                Bouwjaar = 2017,
                AutoID = 2,
                EigenaarID = 2
            };

            //Act
            _collectie.Aanmaken(dto);

            //Assert
            Assert.Equal(dto.Merk, _mock.DTO.Merk);
            Assert.Equal(dto.Type, _mock.DTO.Type);
            Assert.Equal(dto.Bouwjaar, _mock.DTO.Bouwjaar);
            Assert.Equal(dto.AutoID, _mock.DTO.AutoID);
            Assert.Equal(dto.EigenaarID, _mock.DTO.EigenaarID);
        }
    }
}
