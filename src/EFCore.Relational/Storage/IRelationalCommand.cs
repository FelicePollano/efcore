// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Microsoft.EntityFrameworkCore.Storage
{
    /// <summary>
    ///     <para>
    ///         A command to be executed against a relational database.
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    public interface IRelationalCommand
    {
        /// <summary>
        ///     Gets the command text to be executed.
        /// </summary>
        string CommandText { get; }

        /// <summary>
        ///     Gets the parameters for the command.
        /// </summary>
        IReadOnlyList<IRelationalParameter> Parameters { get; }

        /// <summary>
        ///     Executes the command with no results.
        /// </summary>
        /// <param name="parameterObject"> Parameters for this method. </param>
        /// <returns> The number of rows affected. </returns>
        int ExecuteNonQuery(RelationalCommandParameterObject parameterObject);

        /// <summary>
        ///     Asynchronously executes the command with no results.
        /// </summary>
        /// <param name="parameterObject"> Parameters for this method. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        ///     A task that represents the asynchronous operation. The task result contains the number of rows affected.
        /// </returns>
        /// <exception cref="OperationCanceledException"> If the <see cref="CancellationToken"/> is canceled. </exception>
        Task<int> ExecuteNonQueryAsync(
            RelationalCommandParameterObject parameterObject,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Executes the command with a single scalar result.
        /// </summary>
        /// <param name="parameterObject"> Parameters for this method. </param>
        /// <returns> The result of the command. </returns>
        object ExecuteScalar(RelationalCommandParameterObject parameterObject);

        /// <summary>
        ///     Asynchronously executes the command with a single scalar result.
        /// </summary>
        /// <param name="parameterObject"> Parameters for this method. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        ///     A task that represents the asynchronous operation. The task result contains the result of the command.
        /// </returns>
        /// <exception cref="OperationCanceledException"> If the <see cref="CancellationToken"/> is canceled. </exception>
        Task<object> ExecuteScalarAsync(
            RelationalCommandParameterObject parameterObject,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Executes the command with a <see cref="RelationalDataReader" /> result.
        /// </summary>
        /// <param name="parameterObject"> Parameters for this method. </param>
        /// <returns> The result of the command. </returns>
        RelationalDataReader ExecuteReader(RelationalCommandParameterObject parameterObject);

        /// <summary>
        ///     Asynchronously executes the command with a <see cref="RelationalDataReader" /> result.
        /// </summary>
        /// <param name="parameterObject"> Parameters for this method. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        ///     A task that represents the asynchronous operation. The task result contains the result of the command.
        /// </returns>
        /// <exception cref="OperationCanceledException"> If the <see cref="CancellationToken"/> is canceled. </exception>
        Task<RelationalDataReader> ExecuteReaderAsync(
            RelationalCommandParameterObject parameterObject,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     <para>
        ///         Called by the execute methods to create a <see cref="DbCommand" /> for the given <see cref="DbConnection" />
        ///         and configure timeouts and transactions.
        ///     </para>
        ///     <para>
        ///         This method is typically used by database providers (and other extensions). It is generally
        ///         not used in application code.
        ///     </para>
        /// </summary>
        /// <param name="parameterObject"> Parameters for this method. </param>
        /// <param name="commandId"> The command correlation ID. </param>
        /// <param name="commandMethod"> The method that will be called on the created command. </param>
        /// <returns> The created command. </returns>
        DbCommand CreateDbCommand(
            RelationalCommandParameterObject parameterObject,
            Guid commandId,
            DbCommandMethod commandMethod);
    }
}
