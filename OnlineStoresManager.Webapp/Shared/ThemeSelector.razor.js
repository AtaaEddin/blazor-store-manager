window.setTheme = (theme) => {

    let themeCssHref;
    switch (theme) {
        case "dark":
            themeCssHref = "https://blazor.cdn.telerik.com/blazor/4.4.0/kendo-theme-default/swatches/default-main-dark.css";
            break;
        default:
            themeCssHref = "https://blazor.cdn.telerik.com/blazor/4.4.0/kendo-theme-default/swatches/default-main.css";
            break;
    }

    const oldThemeCss = document.getElementById("TelerikThemeLink");

    let newThemeCss = document.createElement("link");
    newThemeCss.setAttribute("id", "TelerikThemeLink");
    newThemeCss.setAttribute("rel", "stylesheet");
    newThemeCss.setAttribute("type", "text/css");
    newThemeCss.setAttribute("href", themeCssHref);
    newThemeCss.onload = () => {
        if (oldThemeCss && oldThemeCss.parentElement) {
            oldThemeCss.parentElement.removeChild(oldThemeCss);
        }
    };

    document.getElementsByTagName("head")[0].appendChild(newThemeCss);

    // Bootstrap now supports color modes, starting with dark mode! With v5.3.0 
    // you can implement your own color mode toggler(see below for an example from Bootstrap’s docs)
    // and apply the different color modes as you see fit.We support a light mode(default ) and now dark mode.
    // Color modes can be toggled globally on the < html > element, or on specific components and elements,
    // thanks to the data-bs-theme attribute.
    const htmlTag = document.getElementsByTagName("html")[0];
    htmlTag.setAttribute("data-bs-theme", theme === "dark" ? "dark" : "light")

    // top-row header has a specific light mode color (light grey), so we apply the change manually
    const top_row_class_tags = [...document.getElementsByClassName("top-row")]
    const top_row_class_tags_bg_color = theme === "dark" ? "#212529" : "#f7f7f7"
    top_row_class_tags.forEach(t => t.style.backgroundColor = top_row_class_tags_bg_color);
}
