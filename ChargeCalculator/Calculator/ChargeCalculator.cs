// <copyright file="ChargeCalculator.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Calculator
{
    using System;
    using System.Linq;
    using global::ChargeCalculator.Enums;
    using global::ChargeCalculator.Queries;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Implementation of the charge calculation
    /// </summary>
    public class ChargeCalculator : ICalculateCharges
    {
        private readonly IQueryParkingData parkingDataQueries;
        private readonly decimal shortStayRate;
        private readonly decimal longStayRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeCalculator"/> class.
        /// </summary>
        /// <param name="parkingDataQueries">Parking data queries</param>
        /// <param name="config">Configuration from appsettings</param>
        public ChargeCalculator(IQueryParkingData parkingDataQueries, IConfigurationRoot config)
        {
            this.parkingDataQueries = parkingDataQueries;

            this.shortStayRate = decimal.Parse(config["Charges:ShortStay"]);
            this.longStayRate = decimal.Parse(config["Charges:LongStay"]);
        }

        /// <inheritdoc/>
        public decimal CalculateCharge(string registrationNumber, DateTime exitDateTime)
        {
            var parkingData = this.parkingDataQueries.GetParkingDetails(registrationNumber);
            parkingData.ExitDateTime = exitDateTime;

            if (parkingData.ChargeType == ChargeType.ShortStay)
            {
                int days = Enumerable.Range(1, (exitDateTime - parkingData.EntryDateTime).Days)
                 .Where(d =>
                 {
                     var dt = parkingData.EntryDateTime.AddDays(d);
                     return dt.DayOfWeek != DayOfWeek.Saturday
                            && dt.DayOfWeek != DayOfWeek.Sunday;
                 }).Count();

                int hours = Enumerable.Range(0, (exitDateTime - parkingData.EntryDateTime).Hours)
                 .Where(h =>
                 {
                     var dt = parkingData.EntryDateTime.AddHours(h);
                     return dt.DayOfWeek != DayOfWeek.Saturday
                            && dt.DayOfWeek != DayOfWeek.Sunday
                            && dt.Hour >= 8 && dt.Hour <= 18;
                 }).Count();

                int minutes = Enumerable.Range(0, (exitDateTime - parkingData.EntryDateTime).Minutes)
                 .Where(m =>
                 {
                     var dt = parkingData.EntryDateTime.AddMinutes(m);
                     return dt.DayOfWeek != DayOfWeek.Saturday
                            && dt.DayOfWeek != DayOfWeek.Sunday
                            && dt.Hour >= 8 && dt.Hour <= 18;
                 }).Count();

                decimal chargePerMinute = this.shortStayRate / 60m;

                return ((days * 600) + (hours * 60) + minutes) * chargePerMinute;
            }
            else if (parkingData.ChargeType == ChargeType.LongStay)
            {
                int days = 1 + (exitDateTime.Date - parkingData.EntryDateTime.Date).Days;
                return days * this.longStayRate;
            }

            throw new InvalidOperationException();
        }
    }
}
