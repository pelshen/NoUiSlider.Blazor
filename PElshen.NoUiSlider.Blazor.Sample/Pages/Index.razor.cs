using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace PElshen.NoUiSlider.Blazor.Sample.Pages
{
    public partial class Index : ComponentBase
    {
        #region Basic
        private double ValueBasic { get; set; } = 10;

        private string BasicExample { get; set; } = "<NoUiSlider @bind-Value=\"Value\" Min=\"0\" Max=\"100\" Tooltips=\"true\" />";
        #endregion

        #region Disabled
        private double ValueDisabled { get; set; } = 10;
        private bool IsDisabled { get; set; } = false;

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
        #endregion

        #region Options object
        private NoUiSliderOptions Options = new NoUiSliderOptions
        {
            Start = new[] { 10.0 },
            Min = 0,
            Max = 100,
            Pips = new NoUiSliderOptions.PipsOptions
            {
                Mode = PipsMode.Steps,
                Stepped = true,
                FilterMultiples = new List<NoUiSliderOptions.PipFilterMultiples>
                {
                    new NoUiSliderOptions.PipFilterMultiples { Multiple = 10, PipType = 0 },
                },
                Density = 1,
                AlwaysShowMinMax = true,
            },
            Tooltips = true,
            Step = 1,
        };

        private string OptionsExample { get; set; } = @"private NoUiSliderOptions Options = new NoUiSliderOptions
{
    Start = new[] { 10.0 },
    Min = 0,
    Max = 100,
    Pips = new NoUiSliderOptions.PipsOptions
    {
        Mode = PipsMode.Steps,
        Stepped = true,
        FilterMultiples = new List<NoUiSliderOptions.PipFilterMultiples>
        {
            new NoUiSliderOptions.PipFilterMultiples { Multiple = 10, PipType = 0 },
        },
        Density = 1,
        AlwaysShowMinMax = true,
    },
    Tooltips = true,
    Step = 1,
};

<NoUiSlider Options=""Options"" />";
        #endregion
    }
}
