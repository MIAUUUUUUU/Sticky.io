namespace DOM {
    export function getElement(selector: string): Element {
        var element: Element | null = document.querySelector(selector);

        if (element === null) throw new Error(`Selector "${selector}" didn't return any Element.`);

        return element;
    }
}

export default DOM;
