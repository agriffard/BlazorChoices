window.blazorChoices = {
    instances: {},
    
    init: function (elementId, options, dotNetHelper, callbackName) {
        const element = document.getElementById(elementId);
        if (!element) {
            console.error('Element not found:', elementId);
            return false;
        }

        try {
            const choices = new Choices(element, options);
            this.instances[elementId] = choices;

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
    },

    destroy: function (elementId) {
        const choices = this.instances[elementId];
        if (choices) {
            choices.destroy();
            delete this.instances[elementId];
            return true;
        }
        return false;
    },

    setValue: function (elementId, value) {
        const choices = this.instances[elementId];
        if (choices) {
            choices.setChoiceByValue(value);
            return true;
        }
        return false;
    },

    getValue: function (elementId) {
        const choices = this.instances[elementId];
        if (choices) {
            return choices.getValue(true);
        }
        return null;
    },

    clearStore: function (elementId) {
        const choices = this.instances[elementId];
        if (choices) {
            choices.clearStore();
            return true;
        }
        return false;
    }
};
