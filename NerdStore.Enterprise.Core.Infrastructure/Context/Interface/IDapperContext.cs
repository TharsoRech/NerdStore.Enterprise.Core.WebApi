namespace NerdStore.Enterprise.Core.Infrastructure.Context.Interface
{
    public interface IDapperContext
    {
        Task<int> ExecuteAsync(string sql, object entity);

        Task<dynamic> QuerySingleOrDefaultAsync(string sql, object entity);

        Task<dynamic> QueryFirstOrDefaultAsync(string sql, object entity);

        Task<dynamic> QueryFirstAsync(string sql, object entity);

        Task<IEnumerable<dynamic>> QueryAsync(string sql, object entity);
    }
}
