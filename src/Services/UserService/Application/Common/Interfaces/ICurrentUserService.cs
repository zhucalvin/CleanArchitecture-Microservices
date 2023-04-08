namespace Services.User.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
}
