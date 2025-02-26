using Microsoft.EntityFrameworkCore.Storage;

using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;

using System.ComponentModel;

namespace BaseDbMigrations
{
    public class RetryingNpgsqlRetryingExecutionStrategy(ExecutionStrategyDependencies dependencies) : NpgsqlRetryingExecutionStrategy(dependencies)
    {
        protected override bool ShouldRetryOn(Exception? exception)
        {
            if (exception is NpgsqlException sqlException)
            {
                // EF Core issue logged to consider making this a default https://github.com/dotnet/efcore/issues/33191
                if (sqlException.ErrorCode is 4060)
                {
                    // Don't retry on login failures associated with default database not existing due to EF migrations not running yet
                    return false;
                }
                // Workaround for https://github.com/dotnet/aspire/issues/1023
                else if (sqlException.ErrorCode is 0 || (sqlException.ErrorCode is 203 && sqlException.InnerException is Win32Exception))
                {
                    return true;
                }
            }

            return base.ShouldRetryOn(exception);
        }
    }
}
