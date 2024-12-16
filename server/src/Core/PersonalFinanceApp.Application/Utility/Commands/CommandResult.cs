namespace PersonalFinanceApp.Application.Utility.Commands;

public sealed record CommandResult(CommandStatus Status)
{
    public static readonly CommandResult NotFound = new(CommandStatus.NotFound);
    public static readonly CommandResult Conflict = new(CommandStatus.Conflict);

    public static CommandResult<T> Succeeded<T>(T? value) => new(CommandStatus.Success, value);
}

public sealed record CommandResult<T>(CommandStatus Status, T? Value)
{
    public static implicit operator CommandResult<T>(CommandResult commandResult) => new(commandResult.Status, default);
}
