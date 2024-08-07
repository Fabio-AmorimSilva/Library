using Library.Core.Result;

namespace Library.Application.Commands.Account.Login;

public sealed record LoginCommand(
    string Username,
    string Password
) : IRequest<ResultResponse<string>>;