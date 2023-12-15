window.setTheme = (IsDarkMode) => {

    // Bootstrap now supports color modes, starting with dark mode! With v5.3.0 
    // you can implement your own color mode toggler(see below for an example from Bootstrap’s docs)
    // and apply the different color modes as you see fit.We support a light mode(default ) and now dark mode.
    // Color modes can be toggled globally on the < html > element, or on specific components and elements,
    // thanks to the data-bs-theme attribute.
    const htmlTag = document.getElementsByTagName("html")[0];
    htmlTag.setAttribute("data-bs-theme", IsDarkMode ? "dark" : "light")
}
