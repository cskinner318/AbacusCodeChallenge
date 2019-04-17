// <copyright file="CarParkCommandsHandler.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Handlers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using ChargeCalculator.Commands;
    using ChargeCalculator.Repository;
    using ChargeCalculator.Repository.Models;

    /// <summary>
    /// A command handler for <see cref="IHandleCarParkCommands"/>
    /// </summary>
    public class CarParkCommandsHandler : IHandleCarParkCommands
    {
        private readonly IMapper mapper;
        private readonly ICarParkDAL db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarParkCommandsHandler"/> class.
        /// </summary>
        /// <param name="mapper">Automapper</param>
        /// <param name="db">Daatabase access layer</param>
        public CarParkCommandsHandler(IMapper mapper, ICarParkDAL db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        /// <inheritdoc/>
        public async Task Handle(RegisterParkingCommand command)
        {
            this.db.RegisterCarParkingEntry(this.mapper.Map<ParkingRegistrationDAO>(command));
        }
    }
}
