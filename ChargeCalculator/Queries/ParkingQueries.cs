// <copyright file="ParkingQueries.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Queries
{
    using AutoMapper;
    using ChargeCalculator.Queries.Models;
    using ChargeCalculator.Repository;

    /// <summary>
    /// Implements the parking data queries
    /// </summary>
    public class ParkingQueries : IQueryParkingData
    {
        private readonly IMapper mapper;
        private readonly ICarParkDAL db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingQueries"/> class.
        /// </summary>
        /// <param name="mapper">Automapper</param>
        /// <param name="db">Daatabase access layer</param>
        public ParkingQueries(IMapper mapper, ICarParkDAL db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        /// <inheritdoc/>
        public ParkingData GetParkingDetails(string registrationNumber)
        {
            return this.mapper.Map<ParkingData>(this.db.GetParkingDetails(registrationNumber));
        }
    }
}
