jQuery(function () {

    $("#dvMenu").load("../Paginas/Menu.html");

    $("#btnInsertar").on("click", function () {
        EjecutarComando("POST");
    });
    $("#btnActualizar").on("click", function () {
        EjecutarComando("PUT");
    });
    $("#btnEliminar").on("click", function () {
        EjecutarComando("DELETE");
    });
    $("#btnConsultar").on("click", function () {
        Consultar();
    });
    LlenarTabla();
});

async function Consultar() {

    let documento = $("#txtdocumento").val();

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Clientes?documento=" + documento,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        $("#txtnombre").val(Resultado.nombre);
        $("#txtapellido").val(Resultado.apellido);
        $("#txttelefono").val(Resultado.telefono);
        $("#txtemail").val(Resultado.email);

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarTabla() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Clientes",
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        var Columnas = [];
        NombreColumnas = Object.keys(Resultado[0]);
        for (var i in NombreColumnas) {
            Columnas.push({
                data: NombreColumnas[i],
                title: NombreColumnas[i]
            });
        }

        $("#tblClientes").DataTable({
            data: Resultado,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }

}

async function EjecutarComando(Comando) {
    let documento = $("#txtdocumento").val();
    let nombre = $("#txtnombre").val();
    let apellido = $("#txtapellido").val();
    let telefono = $("#txttelefono").val();
    let email = $("#txtemail").val();

    let DatosCliente = {
        documento: documento,
        nombre: nombre,
        apellido: apellido,
        telefono: telefono,
        email: email
    }

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Clientes",
            {
                method: Comando,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DatosCliente)
            });
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}