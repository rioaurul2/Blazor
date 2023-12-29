using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public class CounterBase: ComponentBase
    {
        protected int currentCount = 0;
        protected string fontFamily = "Monotype Corsiva";

        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
