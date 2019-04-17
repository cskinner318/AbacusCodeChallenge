using AutoMapper;
using ChargeCalculator;
using ChargeCalculator.Commands;
using ChargeCalculator.Enums;
using ChargeCalculator.Queries.Models;
using ChargeCalculator.Repository.Models;
using Shouldly;
using System;
using Xunit;

namespace ChargeCalculatorTests
{
    public class CalculatorMapperProfileTests
    {
        private readonly IMapper target;

        public CalculatorMapperProfileTests()
        {
            this.target = this.GetMapperConfiguration().CreateMapper();
        }

        [Fact]
        public void CalculatorMapperProfile_IsValidProfile()
        {
            this.GetMapperConfiguration().AssertConfigurationIsValid();
        }

        [Fact]
        public void RegisterParkingCommand_MapsTo_ParkingRegistrationDAO()
        {
            // Arrange
            var input = new RegisterParkingCommand
            {
                ChargeType = ChargeType.ShortStay,
                EntryDateTime = new DateTime(2019, 3, 5, 4, 15, 0),
                RegistrationNumber = "ABC 123"
            };

            // Act
            var actual = this.target.Map<ParkingRegistrationDAO>(input);

            // Assert
            actual.Id.ShouldBe(0);
            actual.RegistrationNumber.ShouldBe(input.RegistrationNumber);
            actual.EntryDateTime.ShouldBe(input.EntryDateTime);
            actual.ChargeType.ShouldBe(input.ChargeType);
        }

        [Fact]
        public void ParkingRegistrationDAO_MapsTo_ParkingData()
        {
            // Arrange
            var input = new ParkingRegistrationDAO
            {
                Id = 123,
                ChargeType = ChargeType.ShortStay,
                EntryDateTime = new DateTime(2019, 3, 5, 4, 15, 0),
                RegistrationNumber = "ABC 123"
            };

            // Act
            var actual = this.target.Map<ParkingData>(input);

            // Assert
            actual.RegistrationNumber.ShouldBe(input.RegistrationNumber);
            actual.EntryDateTime.ShouldBe(input.EntryDateTime);
            actual.ChargeType.ShouldBe(input.ChargeType);
        }

        private DateTime DateTime(int v1, int v2, int v3, int v4, int v5, int v6)
        {
            throw new NotImplementedException();
        }

        private MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CalculatorMapperProfile>();
            });
        }
    }
}
