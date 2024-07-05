using System.Activities;
using UiPath.Robot.Activities.Api;

namespace UiPath.Activities.Calculadora.Helpers
{
    public static class ActivityContextExtensions
    {
        public static IExecutorRuntime GetExecutorRuntime(this ActivityContext context) => context.GetExtension<IExecutorRuntime>();
    }
}
