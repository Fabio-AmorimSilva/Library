﻿namespace Library.Application.Commands.Account.Signup;

public sealed class SignupCommandHandler(LibraryContext context) : IRequestHandler<SignupCommand, ResultResponse<Guid>>
{
    public async Task<ResultResponse<Guid>> Handle(SignupCommand request, CancellationToken cancellationToken)
    {
        var userNameAlreadyExists = await context
            .Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);

        if (userNameAlreadyExists)
            return new ConflictResponse<Guid>(ErrorMessages.AlreadyExists(nameof(LoginCommand.Username)));

        var user = new User(
            request.Name,
            request.Email,
            request.Role
        );

        user.SetPassword(BCrypt.Net.BCrypt.HashPassword(request.Password));

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new CreatedResponse<Guid>(user.Id);
    }
}