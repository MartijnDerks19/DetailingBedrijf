﻿using DomeinLaag.DTOs;
using DomeinLaag.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.MockDataToegang;

namespace TestProject.Testen
{
    public class AfspraakTesten
    {
        private AfspraakCollectie _afspraakCollectie;
        private AfspraakMockData _afspraakMock;


        public AfspraakTesten()
        {
            DetailerMockData detailerMock = new();
            DetailerCollectie detailerCollectie = new(detailerMock);

            AfspraakMockData afspraakMock = new();
            AfspraakCollectie afspraakCollectie = new(afspraakMock, detailerMock);

            _afspraakCollectie = afspraakCollectie;
            _afspraakMock = afspraakMock;
        }

        [Theory]
        [InlineData(30)]
        [InlineData(40)]
        public void CheckOfVerwijderMethodeWordtAangeroepenEnParametersHetzelfdeZijn(int id)
        {
            //Arrange
            int expectedID = id;
            //Act
            _afspraakCollectie.Verwijderen(id);

            //Assert
            Assert.Equal(expectedID, _afspraakMock.VerwijderID);
        }

        [Fact]
        public void CheckOfAanmaakMethodeWordtAangeroepenEnParametersHetzelfdeZijn()
        {
            //Arrange
            AfspraakDTO dto = new AfspraakDTO()
            {
                AfspraakID = 1,
                DetailerID = 120,
                AutoID = 2,
                DatumEnTijd = DateTime.Now
            };

            //Act
            _afspraakCollectie.ProbeerAanmaken(dto);

            //Assert
            Assert.Equal(dto.AfspraakID, _afspraakMock.DTO.AfspraakID);
            Assert.Equal(dto.DetailerID, _afspraakMock.DTO.DetailerID);
            Assert.Equal(dto.AutoID, _afspraakMock.DTO.AutoID);
            Assert.Equal(dto.DatumEnTijd, _afspraakMock.DTO.DatumEnTijd);

        }
    }
}
