// <copyright file="RegisterParkingCommand.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Commands
{
    using System;
    using ChargeCalculator.Enums;

    /// <summary>
    /// Command used to request a parking charge calculation
    /// </summary>
    public class RegisterParkingCommand
    {
        /// <summary>
        /// Gets or sets the time the parking started
        /// </summary>
        public DateTime EntryDateTime { get; set; }

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
