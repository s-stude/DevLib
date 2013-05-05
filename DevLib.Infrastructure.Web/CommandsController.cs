using System;
using System.Web.Mvc;
using DevLib.Infrastructure.Commands;

namespace DevLib.Infrastructure.Web
{
    public abstract class CommandsController : Controller
    {
        public ICommandHandlerFactory CommandHandlerFactory { get; set; }
        protected const string ModelStateKey = "ModelState";

        protected ActionResult Handle<TCommand>(TCommand command, ActionResult onSuccess)
            where TCommand : ICommand
        {
            return Handle(command, () => onSuccess);
        }

        protected ActionResult Handle<TCommand>(TCommand command, ActionResult onSuccess, ActionResult onFailure)
            where TCommand : ICommand
        {
            return Handle(command, () => onSuccess, () => onFailure);
        }

        protected ActionResult Handle<TCommand>(TCommand command, Func<ActionResult> onSuccess)
            where TCommand : ICommand
        {
            var actionName = RouteData.Values["action"].ToString();
            var controllerName = RouteData.Values["controller"].ToString();

            return Handle(command, onSuccess, () => RedirectToAction(actionName, controllerName));
        }

        protected ActionResult Handle<TCommand>(TCommand command, Func<ActionResult> onSuccess, Func<ActionResult> onFailure)
            where TCommand : ICommand
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var handler = CommandHandlerFactory.Create<TCommand>();
                    handler.Handle(command);

                    return onSuccess();
                }
                catch (CommandHandlerException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            TempData[ModelStateKey] = ModelState;
            return onFailure();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (TempData[ModelStateKey] != null && ModelState.Equals(TempData[ModelStateKey]) == false)
                ModelState.Merge((ModelStateDictionary) TempData[ModelStateKey]);
            
            base.OnActionExecuted(filterContext);
        }
    }
}