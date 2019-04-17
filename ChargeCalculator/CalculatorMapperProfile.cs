// <copyright file="CalculatorMapperProfile.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator
{
    using AutoMapper;
    using ChargeCalculator.Commands;
    using ChargeCalculator.Queries.Models;
    using ChargeCalculator.Repository.Models;

    /// <summary>
    /// A class responsible for mapping classes in this project
    /// </summary>
    public class CalculatorMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorMapperProfile"/> class.
        /// </summary>
        public CalculatorMapperProfile()
        {
            this.CreateMap<RegisterParkingCommand, ParkingRegistrationDAO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            this.CreateMap<ParkingRegistrationDAO, ParkingData>()
                .ForMember(dest => dest.ExitDateTime, opt => opt.Ignore());
        }
    }
}
