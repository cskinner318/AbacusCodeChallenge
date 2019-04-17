using AutoMapper;
using ChargeCalculator.Queries;
using ChargeCalculator.Queries.Models;
using ChargeCalculator.Repository;
using ChargeCalculator.Repository.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChargeCalculatorTests.Queries
{
    public class ParkingQueriesTests
    {
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<ICarParkDAL> mockDb;

        private readonly ParkingQueries target;

        public ParkingQueriesTests()
        {
            this.mockMapper = new Mock<IMapper>();
            this.mockDb = new Mock<ICarParkDAL>();

            this.target = new ParkingQueries(this.mockMapper.Object, this.mockDb.Object);
        }

        [Fact]
        public void GetParkingDetails_Calls_DatabaseWithString()
        {
            // Setup
            var input = "test string";

            this.mockDb.Setup(x => x.GetParkingDetails(It.IsAny<string>()))
                .Returns(new ParkingRegistrationDAO());

            // Act
            var result = this.target.GetParkingDetails(input);

            // Assert
            this.mockDb.Verify(x => x.GetParkingDetails(It.Is<string>(y => y == input)));
        }

        [Fact]
        public void GetParkingDetails_Calls_Mapper()
        {
            // Setup
            var input = "test string";

            this.mockMapper.Setup(x => x.Map<ParkingData>(It.IsAny<ParkingRegistrationDAO>()))
                .Returns(new ParkingData());

            // Act
            var result = this.target.GetParkingDetails(input);

            // Assert
            this.mockMapper.Verify(x => x.Map<ParkingData>(It.IsAny<ParkingRegistrationDAO>()));
        }

    }
}
