document.addEventListener("DOMContentLoaded", () => {
    const loginCard = document.getElementById("loginCard");
    const registerCard = document.getElementById("registerCard");

    const btnIrARegistro = document.getElementById("btnIrARegistro");
    const linkLogin = document.getElementById("linkLogin");

    // Mostrar Registro / Ocultar Login
    if (btnIrARegistro) {
        btnIrARegistro.addEventListener("click", (e) => {
            e.preventDefault();
            loginCard.classList.add("d-none");
            registerCard.classList.remove("d-none");
        });
    }

    // Mostrar Login / Ocultar Registro
    if (linkLogin) {
        linkLogin.addEventListener("click", (e) => {
            e.preventDefault();
            registerCard.classList.add("d-none");
            loginCard.classList.remove("d-none");
        });
    }
});