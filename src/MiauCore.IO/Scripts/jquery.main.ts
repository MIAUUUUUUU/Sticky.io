import * as jQuery from "jquery";

class WindowWithJQuery extends Window {
    jQuery: JQueryStatic;
    jq: JQueryStatic;
    $: JQueryStatic;
}

declare var window: WindowWithJQuery;

window.jQuery = jQuery;
window.jq = jQuery;
window.$ = jQuery;
