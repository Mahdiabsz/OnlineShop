using Microsoft.AspNetCore.Http;

namespace MMOnlineShop.Common.Commands
{
    public abstract class CommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly CommandResult _result = new CommandResult();

        protected Task<Response> ResultAsync(int code, List<string> messages = null, object data = null)
        {
            Response response = new Response();
            if (code == StatusCodes.Status200OK)
            {
                _result.ClearErrors();
                _result.IsSuccess = true;
            }
            else
            {
                _result.IsSuccess = false;
            }

            response.Code = code;
            response.Messages.AddRange(messages);
            response.Data = data;

            return Task.FromResult(response);
        }

        protected void AddError(string error)
        {
            _result.AddError(error);
        }

        public abstract Task<Response> Handle(TCommand command);

    }
}
