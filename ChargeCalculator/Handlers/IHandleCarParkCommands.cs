// <copyright file="IHandleCarParkCommands.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Handlers
{
    using ChargeCalculator.Commands;

    /// <summary>
    /// Implementing classes define methods for handling the commands related to the car park
    /// </summary>
    public interface IHandleCarParkCommands : ICommandHandler<RegisterParkingCommand>
    {
    }
}
