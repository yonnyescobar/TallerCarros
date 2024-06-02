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
    LlenarCargo();
    LlenarTabla();
});

async function LlenarCargo() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Cargos",
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        for (i = 0; i < Resultado.length; i++) {
            $("#cboCargo").append('<option value="' + Resultado[i].id_cargo + '">' + Resultado[i].nombre + '</option >');
        }
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarTabla() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Empleados",
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

        $("#tblEmpleados").DataTable({
            data: Resultado,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }

}

async function Consultar() {

    let documento = $("#txtdocumento").val();

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Empleados?documento=" + documento,
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
        $("#cboCargo").val(Resultado.nombre);

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
    let cargo = $("#cboCargo").val();

    let DatosEmpleado = {
        documento: documento,
        nombre: nombre,
        apellido: apellido,
        telefono: telefono,
        email: email,
        id_cargo: cargo
    }

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Empleados",
            {
                method: Comando,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DatosEmpleado)
            });
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}