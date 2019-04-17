// <copyright file="ICalculateCharges.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Calculator
{
    using System;

    /// <summary>
    /// Implementing classes calculate parking charges
    /// </summary>
    public interface ICalculateCharges
    {
        /// <summary>
        /// Calculate the parking charge
        /// </summary>
        /// <param name="registrationNumber">The registration number to lookup</param>
        /// <param name="exitDateTime">The exit time</param>
        /// <returns>The actual charge for the parking period</returns>
        decimal CalculateCharge(string registrationNumber, DateTime exitDateTime);
    }
}
