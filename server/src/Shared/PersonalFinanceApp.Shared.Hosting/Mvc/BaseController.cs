using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Application.Utility.Commands;

namespace PersonalFinanceApp.Shared.Hosting.Mvc;

[ApiController]
public abstract class BaseController : ControllerBase
{
    public ActionResult HandleCommand<T>(CommandResult<T> commandResult, Func<ActionResult> successCallback)
    {
        var (status, _) = commandResult;
        return status switch
        {
            CommandStatus.NotFound => NotFound(),
            CommandStatus.Conflict => Conflict(),
            CommandStatus.Success => successCallback(),
            _ => throw new NotSupportedException()
        };
    }
}
