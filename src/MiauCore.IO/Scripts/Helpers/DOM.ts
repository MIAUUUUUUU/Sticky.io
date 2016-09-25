function element<T> (selector: string, constructor: { new (): T }): T {
    var result = getElement(selector);

    if (!(result instanceof constructor)) {
        throw new Error(`Selector "${selector}" didn't return the required element type.`);
    }

    return result;
}

function getElement(selector: string): Element {
    var element: Element | null = document.querySelector(selector);

    if (element === null) {
        throw new Error(`Selector "${selector}" didn't return any element.`);
    }

    return element;
}

export { element, getElement }
