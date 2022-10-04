using Npgsql;

namespace FreshMarket.Exceptions.Postgres
{
    public static class HandlePostgresException
    {
        /// <summary>
        /// Throws specific violation if specified or rethrows original PostgresException
        /// </summary>
        /// <exception cref="UniqueViolationException"></exception>
        /// <exception cref="PostgresException"></exception>
        public static void HandleException<T>(this PostgresException postgresException)
        {
            switch (postgresException.SqlState)
            {
                case PostgresErrorCodes.UniqueViolation:
                    Console.WriteLine(postgresException);
                    throw new UniqueViolationException(typeof(T), postgresException.ColumnName);
                default:
                    throw postgresException;
            }
        }
    }
}
