// <copyright file="ICarParkDAL.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Repository
{
    using System;
    using ChargeCalculator.Repository.Models;

    /// <summary>
    /// Data access layer for the car park data
    /// </summary>
    public interface ICarParkDAL
    {
        /// <summary>
        /// Register when a vehicle has entered the car park
        /// </summary>
        /// <param name="parkingRegistration">The parking registration</param>
        void RegisterCarParkingEntry(ParkingRegistrationDAO parkingRegistration);

        /// <summary>
        /// Get the details for a registered vehicle
        /// </summary>
        /// <param name="registrationNumber">The registration number to lookup</param>
        /// <returns>A DAO for the registered entry</returns>
        ParkingRegistrationDAO GetParkingDetails(string registrationNumber);
    }
}
