function initialiseSlider(id, options) {

    var slider = document.getElementById(id);

    var sliderOptions = {
        start: options.start,
        range: { min: options.min, max: options.max },
        step: options.step,
        tooltips: options.tooltips ? wNumb(options.format) : false,
        format: wNumb(options.format),
        pips: options.pips ? {
            format: wNumb(options.pips.format ? options.pips.format : options.format),
            mode: options.pips.mode,
            values: options.pips.values,
            density: options.pips.density,
            stepped: options.pips.stepped,
        } : undefined
    };

    if (options.pips.filterMultiples) {
        sliderOptions.pips.filter = function (value) {
            var type = -1;
            options.pips.filterMultiples.forEach(function (filterMultiple) {
                if (value % filterMultiple.multiple == 0) {
                    type = filterMultiple.pipType;
                }
            });
            return type;
        }
    }

    noUiSlider.create(slider, sliderOptions);

    slider.noUiSlider.on('set', onSet);
}

function filterPips(value) {
    return value % 100 ? 0 : 1;
}

function onSet(values, handle, unencoded, tap, positions, noUiSlider) {
    if (unencoded.length > 1) {
        DotNet.invokeMethodAsync('NoUiSlider.Blazor', 'UpdateMultipleValues', unencoded);
    }
    else {
        DotNet.invokeMethodAsync('NoUiSlider.Blazor', 'UpdateSingleValue', unencoded[0]);
    }
}