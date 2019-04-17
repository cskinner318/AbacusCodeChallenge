// <copyright file="ParkingData.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Queries.Models
{
    using System;
    using ChargeCalculator.Enums;

    /// <summary>
    /// A model representing the parking data for charge calculation
    /// </summary>
    public class ParkingData
    {
        /// <summary>
        /// Gets or sets the time the parking started
        /// </summary>
        public DateTime EntryDateTime { get; set; }

        /// <summary>
        /// Gets or sets the time the parking ended
        /// </summary>
        public DateTime ExitDateTime { get; set; }

        /// <summary>
        /// Gets or sets the vehicle registration number
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of parking charge
        /// </summary>
        public ChargeType ChargeType { get; set; }
    }
}
