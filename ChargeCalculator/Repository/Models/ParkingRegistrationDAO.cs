// <copyright file="ParkingRegistrationDAO.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Repository.Models
{
    using System;
    using ChargeCalculator.Enums;

    /// <summary>
    /// Data Access Object for Parkin
    /// </summary>
    public class ParkingRegistrationDAO
    {
        /// <summary>
        /// Gets or sets the id for lite db
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the entry time of a registration
        /// </summary>
        public DateTime EntryDateTime { get; set; }

        /// <summary>
        /// Gets or sets the registration number
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the ChargeType
        /// </summary>
        public ChargeType ChargeType { get; set; }
    }
}
