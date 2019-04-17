// <copyright file="Startup.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator
{
    using AutoMapper;
    using ChargeCalculator.Calculator;
    using ChargeCalculator.Handlers;
    using ChargeCalculator.Queries;
    using ChargeCalculator.Repository;
    using ChargeCalculator.Repository.Models;
    using LiteDB;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Startup class for DI
    /// </summary>
    public class Startup
    {
        private readonly IConfigurationRoot configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup()
        {
            // TODO: not ideal, but this cleans out the db for test usage
            var parkingRegDb = new LiteDatabase(@"ParkingRegData.db");
            parkingRegDb.DropCollection("parking_registrations");

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            this.configuration = builder.Build();
        }

        /// <summary>
        /// Configure DI Services
        /// </summary>
        /// <param name="services">DI collection services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddSingleton<IConfigurationRoot>(this.configuration);
            services.AddSingleton<ICarParkDAL, CarParkDAL>();
            services.AddSingleton<IHandleCarParkCommands, CarParkCommandsHandler>();
            services.AddSingleton<IQueryParkingData, ParkingQueries>();
            services.AddSingleton<ICalculateCharges, ChargeCalculator>();
        }
    }
}
