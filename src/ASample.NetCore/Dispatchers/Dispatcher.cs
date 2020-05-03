﻿using System.Threading.Tasks;
using ASample.NetCore.Domain;
using ASample.NetCore.Domain.Message;

namespace ASample.NetCore.Dispatchers
{
    public class Dispatcher : IDispatcher
    {

        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var result = await _queryDispatcher.QueryAsync<TResult>(query);
            return result;
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _commandDispatcher.SendAsync(command);
        }
    }
}
