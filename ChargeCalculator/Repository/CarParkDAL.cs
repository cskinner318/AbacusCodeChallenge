// <copyright file="CarParkDAL.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChargeCalculator.Enums;
    using ChargeCalculator.Repository.Models;
    using LiteDB;

    /// <summary>
    /// Car Park Data Access Layer
    /// </summary>
    public class CarParkDAL : ICarParkDAL
    {
        private readonly LiteDatabase parkingRegDb;
        private readonly LiteCollection<ParkingRegistrationDAO> parkingData;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarParkDAL"/> class.
        /// </summary>
        public CarParkDAL()
        {
            this.parkingRegDb = new LiteDatabase(@"ParkingRegData.db");
            this.parkingData = this.parkingRegDb.GetCollection<ParkingRegistrationDAO>("parking_registrations");
        }

        /// <inheritdoc/>
        public ParkingRegistrationDAO GetParkingDetails(string registrationNumber)
        {
            return this.parkingData.Find(x => x.RegistrationNumber.ToLower() == registrationNumber.ToLower()).Single();
        }

        /// <inheritdoc/>
        public void RegisterCarParkingEntry(ParkingRegistrationDAO parkingRegistration)
        {
            this.parkingData.Insert(parkingRegistration);
        }
    }
}
