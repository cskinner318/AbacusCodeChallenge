// <copyright file="ICommandHandler.cs" company="Parking Co">
// Copyright (c) Parking Co. All rights reserved.
// </copyright>

namespace ChargeCalculator.Handlers
{
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing classes provide the logic that enacts a <typeparamref name="TCommand"/>.
    /// </summary>
    /// <typeparam name="TCommand">The command to be handled.</typeparam>
    public interface ICommandHandler<in TCommand>
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The details required to handle the command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Handle(TCommand command);
    }
}