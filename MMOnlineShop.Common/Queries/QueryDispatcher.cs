namespace MMOnlineShop.Common.Queries
{
    public class QueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public virtual async Task<T> Dispatch<T>(IQuery query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            T result = await handler.Handle((dynamic)query);
            return result;
        }
    }
}
