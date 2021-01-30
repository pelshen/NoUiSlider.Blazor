using PElshen.NoUiSlider.Blazor.Utilities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PElshen.NoUiSlider.Blazor
{
    public class NoUiSliderOptions
    {
        /// <summary>
        /// Supply this directly only if you are not using two way binding with @bind. Your supplied Value or Values will override this otherwise.
        /// </summary>
        public double[] Start { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Step { get; set; }
        public FormatOptions Format { get; set; }
        public bool Tooltips { get; set; } = false;
        public PipsOptions Pips { get; set; }

        public class PipsOptions
        {
            public PipsMode Mode { get; set; }
            public int Density { get; set; }
            public FormatOptions Format { get; set; }
            public int[] Values { get; set; }
            public bool Stepped { get; set; }
            public bool AlwaysShowMinMax { get; set; }
            public List<PipFilterMultiples> FilterMultiples { get; set; }
        }

        public class PipFilterMultiples
        {
            public int Multiple { get; set; }
            public int PipType { get; set; }
        }

        public class FormatOptions
        {
            public int Decimals { get; set; } = 2;
            public string Prefix { get; set; } = "";
            public string Suffix { get; set; } = "";
            public string Mark { get; set; } = ".";
            public string Thousands { get; set; } = "";
            public string Negative { get; set; } = "-";
            public string NegativeBefore { get; set; } = "";
        }
    }

    [JsonConverter(typeof(PipsModeJsonConverter))]
    public enum PipsMode
    {
        Range,
        Steps,
        Positions,
        Count,
        Values
    }
}
