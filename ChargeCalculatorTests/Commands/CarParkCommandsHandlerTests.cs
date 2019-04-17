using AutoMapper;
using ChargeCalculator.Commands;
using ChargeCalculator.Handlers;
using ChargeCalculator.Repository;
using ChargeCalculator.Repository.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChargeCalculatorTests.Commands
{
    public class CarParkCommandsHandlerTests
    {
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<ICarParkDAL> mockDb;

        private readonly CarParkCommandsHandler target;

        public CarParkCommandsHandlerTests()
        {
            this.mockMapper = new Mock<IMapper>();
            this.mockDb = new Mock<ICarParkDAL>();

            this.target = new CarParkCommandsHandler(this.mockMapper.Object, this.mockDb.Object);
        }

        [Fact]
        public async void HandleRegisterParkingCommand_Calls_Mapper()
        {
            // Setup
            var input = new RegisterParkingCommand();

            this.mockMapper.Setup(x => x.Map<ParkingRegistrationDAO>(It.IsAny<RegisterParkingCommand>()))
                .Returns(new ParkingRegistrationDAO());

            // Act
            await this.target.Handle(input);

            // Assert
            this.mockMapper.Verify(x => x.Map<ParkingRegistrationDAO>(It.IsAny<RegisterParkingCommand>()));
        }

        [Fact]
        public async void HandleRegisterParkingCommand_Calls_Database()
        {
            // Setup
            var input = new RegisterParkingCommand();

            this.mockDb.Setup(x => x.RegisterCarParkingEntry(It.IsAny<ParkingRegistrationDAO>()));

            // Act
            await this.target.Handle(input);

            // Assert
            this.mockDb.Verify(x => x.RegisterCarParkingEntry(It.IsAny<ParkingRegistrationDAO>()));
        }
    }
}
