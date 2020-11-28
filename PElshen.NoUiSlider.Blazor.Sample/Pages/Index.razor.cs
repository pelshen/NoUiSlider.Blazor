using Microsoft.AspNetCore.Components;

namespace PElshen.NoUiSlider.Blazor.Sample.Pages
{
    public partial class Index : ComponentBase
    {
        private double ValueBasic { get; set; } = 10;

        private bool IsDisabled { get; set; } = false;

        private string BasicExample { get; set; } = "<NoUiSlider @bind-Value=\"Value\" Min=\"0\" Max=\"100\" Tooltips=\"true\" />";

        private string DisableExample { get; set; } = @"<NoUiSlider @bind-Value=""ValueBasic"" Min=""0"" Max=""100"" Tooltips=""true"" IsDisabled=""IsDisabled"" />
<button @onclick=""ToggleDisabled"">@(IsDisabled ? ""Enable"" : ""Disable"")</button>

private void ToggleDisabled()
{
    IsDisabled = !IsDisabled;
}";

        private void ToggleDisabled()
        {
            IsDisabled = !IsDisabled;
        }
    }
}
