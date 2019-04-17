// <copyright file="Program.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator
{
    using System;
    using ChargeCalculator.Calculator;
    using ChargeCalculator.Commands;
    using ChargeCalculator.Enums;
    using ChargeCalculator.Handlers;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Main class to run parking charge calcuations
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">any arguements from console</param>
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            Console.WriteLine("Hello Car Park World!");

            // Get Command Handler and calculator
            var commandHandler = serviceProvider.GetService<IHandleCarParkCommands>();
            var calculator = serviceProvider.GetService<ICalculateCharges>();

            // First Example
            var firstReg = "ABC123";
            Console.WriteLine("A stay entirely outside of a chargeable period will return £0.00");
            commandHandler.Handle(new RegisterParkingCommand { ChargeType = ChargeType.ShortStay, EntryDateTime = new DateTime(2019, 3, 4, 19, 50, 0), RegistrationNumber = firstReg });
            decimal firstCharge = calculator.CalculateCharge(firstReg, new DateTime(2019, 3, 5, 4, 15, 0));
            Console.WriteLine($"Calculated Charge is £{firstCharge.ToString("0.00")}");
            Console.WriteLine();

            // Second Example
            var secondReg = "ABC124";
            Console.WriteLine("A short stay from 07/09/2017 16:50:00 to 09/09/2017 19:15:00 should cost £12.28");
            commandHandler.Handle(new RegisterParkingCommand { ChargeType = ChargeType.ShortStay, EntryDateTime = new DateTime(2017, 9, 7, 16, 50, 0), RegistrationNumber = secondReg });
            decimal secondCharge = calculator.CalculateCharge(secondReg, new DateTime(2017, 9, 9, 19, 15, 0));
            Console.WriteLine($"Calculated Charge is £{secondCharge.ToString("0.00")}");
            Console.WriteLine();

            // Third Example
            var thirdReg = "ABC125";
            Console.WriteLine("A long stay from 07/09/2017 07:50:00 to 09/09/2017 05:20:00 would cost £22.50");
            commandHandler.Handle(new RegisterParkingCommand { ChargeType = ChargeType.LongStay, EntryDateTime = new DateTime(2017, 9, 7, 7, 50, 0), RegistrationNumber = thirdReg });
            decimal thirdCharge = calculator.CalculateCharge(thirdReg, new DateTime(2017, 9, 9, 5, 20, 0));
            Console.WriteLine($"Calculated Charge is £{thirdCharge.ToString("0.00")}");

            Console.ReadKey();
        }
    }
}
