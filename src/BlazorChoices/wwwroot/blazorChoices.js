const instances = {};

export function init(elementId, options, dotNetHelper, callbackName) {
    const element = document.getElementById(elementId);
    if (!element) {
        console.error('Element not found:', elementId);
        return false;
    }

    try {
        const choices = new Choices(element, options);
        instances[elementId] = choices;

        // Set up event handlers
        if (dotNetHelper && callbackName) {
            element.addEventListener('change', function (event) {
                const value = choices.getValue(true);
                dotNetHelper.invokeMethodAsync(callbackName, value);
            });

            element.addEventListener('addItem', function (event) {
                const value = choices.getValue(true);
                dotNetHelper.invokeMethodAsync(callbackName, value);
            });

            element.addEventListener('removeItem', function (event) {
                const value = choices.getValue(true);
                dotNetHelper.invokeMethodAsync(callbackName, value);
            });
        }

        return true;
    } catch (error) {
        console.error('Error initializing Choices:', error);
        return false;
    }
}

export function destroy(elementId) {
    const choices = instances[elementId];
    if (choices) {
        choices.destroy();
        delete instances[elementId];
        return true;
    }
    return false;
}

export function setValue(elementId, value) {
    const choices = instances[elementId];
    if (choices) {
        choices.setChoiceByValue(value);
        return true;
    }
    return false;
}

export function getValue(elementId) {
    const choices = instances[elementId];
    if (choices) {
        return choices.getValue(true);
    }
    return null;
}

export function clearStore(elementId) {
    const choices = instances[elementId];
    if (choices) {
        choices.clearStore();
        return true;
    }
    return false;
}
