type ReadyState = "any" | "interactive" | "complete";

class UI {
    elements: Object;

    constructor(callback: Function, readyState: ReadyState = "any") {
        document.addEventListener("readystatechange", (event: Event) => {
            if (readyState === "any" || (readyState === "interactive" && document.readyState === "complete") || document.readyState === readyState) {
                callback.call(this);
            }
        });
    }

    addEvents(callback: Function) {
        callback.call(this);
    }
}

export default UI;
