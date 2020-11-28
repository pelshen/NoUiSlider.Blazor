using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PElshen.NoUiSlider.Blazor
{
    public partial class NoUiSlider : ComponentBase
    {
        private bool previousIsDisabled;

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public string IdPrefix { get; set; } = "noui-slider";

        /// <summary>
        /// The minimum value on the scale. Required if Options not supplied. Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public double? Min { get; set; }
        /// <summary>
        /// The maximum value on the scale. Required if Options not supplied. Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public double? Max { get; set; }
        /// <summary>
        /// Whether to show a tooltip for the current value. Defaults to false. Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public bool Tooltips { get; set; } = false;
        /// <summary>
        /// How many decimal places to show in all numbers displayed. Defaults to two. Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public int? DecimalPlaces { get; set; }
        /// <summary>
        /// String prefix before number, eg currency. Defaults to empty string. Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public string Prefix { get; set; }
        /// <summary>
        /// String suffix after number. Defaults to empty string. Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public string Suffix { get; set; }
        /// <summary>
        /// Symbol to use to indicate decimal. Defaults to ".". Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public string DecimalSeparator { get; set; }
        /// <summary>
        /// Symbol to indicate negative number. Defaults to "-". Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public string NegativeSymbol { get; set; }
        /// <summary>
        /// Prefix before negative symbol. Defaults to empty string. Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public string NegativePrefix { get; set; }
        /// <summary>
        /// Symbol to separate thousands. Defaults to ",". Ignored if Options is supplied.
        /// </summary>
        [Parameter]
        public string ThousandsSeparator { get; set; }

        /// <summary>
        /// Supply this for full customisation.
        /// </summary>
        [Parameter]
        public NoUiSliderOptions Options { get; set; }
        
        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public double? Value { get; set; }
        
        [Parameter]
        public EventCallback<double> ValueChanged { get; set; }

        [Parameter]
        public double[] Values { get; set; }

        [Parameter]
        public EventCallback<double[]> ValuesChanged { get; set; }

        private static Func<double, Task> updateSingleValueFunction;
        private static Func<double[], Task> updateMultipleValuesFunction;

        private Guid uniqueId;

        private string Id => IdPrefix + uniqueId;

        public NoUiSlider()
        {
            uniqueId = Guid.NewGuid();
        }

        protected override void OnInitialized()
        {
            updateSingleValueFunction = UpdateValue;
            updateMultipleValuesFunction = UpdateValues;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await InitialiseSlider();
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            if (previousIsDisabled != IsDisabled)
            {
                await ToggleEnableSlider(IsDisabled);
            }
            previousIsDisabled = IsDisabled;
        }

        private async Task InitialiseSlider()
        {
            if (Options != null)
            {
                if (Values != null && Values.Any())
                {
                    Options.Start = Values;
                }
                else if (Value != null)
                {
                    Options.Start = new[] { Value.Value };
                }

                await JSRuntime.InvokeVoidAsync("initialiseSlider", Id, Options);
            }
            else
            {
                if (!Min.HasValue)
                {
                    throw new ArgumentNullException(nameof(Min), "You have not supplied the Options object or all the mandatory shortcut parameters.");
                }
                if (!Max.HasValue)
                {
                    throw new ArgumentNullException(nameof(Max), "You have not supplied the Options object or all the mandatory shortcut parameters.");
                }
                var options = new NoUiSliderOptions
                {
                    Start = Values != null && Values.Any() ? Values : new[] { Value.Value },
                    Min = Min.Value,
                    Max = Max.Value,
                    Tooltips = Tooltips,
                    Format = new NoUiSliderOptions.FormatOptions
                    {
                        Decimals = DecimalPlaces ?? 2,
                        Prefix = Prefix ?? string.Empty,
                        Suffix = Suffix ?? string.Empty,
                        Mark = DecimalSeparator ?? ".",
                        Negative = NegativeSymbol ?? "-",
                        NegativeBefore = NegativePrefix ?? string.Empty,
                        Thousands = ThousandsSeparator ?? ",",
                    }
                };
                await JSRuntime.InvokeVoidAsync("initialiseSlider", Id, options);
            }
        }

        private Task UpdateValue(double newValue)
        {
            Value = newValue;
            return ValueChanged.InvokeAsync(newValue);
        }

        private Task UpdateValues(double[] newValues)
        {
            Values = newValues;
            return ValuesChanged.InvokeAsync(newValues);
        }

        private async Task ToggleEnableSlider(bool disable)
        {
            await JSRuntime.InvokeVoidAsync("toggleEnableSlider", Id, disable);
        }

        [JSInvokable]
        public static Task UpdateSingleValue(double update)
        {
            return updateSingleValueFunction.Invoke(update);
        }

        [JSInvokable]
        public static Task UpdateMultipleValues(double[] update)
        {
            return updateMultipleValuesFunction.Invoke(update);
        }
    }
}
