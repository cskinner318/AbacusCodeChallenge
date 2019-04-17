// <copyright file="IQueryParkingData.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Queries
{
    using ChargeCalculator.Queries.Models;

    /// <summary>
    /// Queries used regardingn parking data
    /// </summary>
    public interface IQueryParkingData
    {
        /// <summary>
        /// Gets the parking data for charge calculation
        /// </summary>
        /// <param name="registrationNumber">The registration number to lookup</param>
        /// <returns>The ParkingData for a </returns>
        ParkingData GetParkingDetails(string registrationNumber);
    }
}
