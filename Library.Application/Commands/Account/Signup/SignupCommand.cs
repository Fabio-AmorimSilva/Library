using Library.Core.Result;

namespace Library.Application.Commands.Account.Signup;

public sealed record SignupCommand(
    string Name,
    string Email,
    string Password,
    Role Role
) : IRequest<ResultResponse<Guid>>;