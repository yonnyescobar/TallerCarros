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
    LlenarServicios();
    LlenarTabla();
});

async function LlenarServicios() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Servicios",
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        for (i = 0; i < Resultado.length; i++) {
            $("#cboServicio").append('<option value="' + Resultado[i].id_servicio + '">' + Resultado[i].nombre + '</option >');
        }

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function EjecutarComando(Comando) {
    let servicio = $("#cboServicio").val();
    let documento = $("#txdocumento").val();
    let nombre = $("#txtnombre").val();
    let apellido = $("#txtapellido").val();
    let telefono = $("#txttelefono").val();
    let email = $("#txtemail").val();
    let fecha = $("#txtfecha").val();

    let DatosVisita = {
        id_servicio: servicio,
        documento: documento,
        nombre: nombre,
        apellido: apellido,
        telefono: telefono,
        email: email,
        fecha: fecha
    }

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Visitas",
            {
                method: Comando,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DatosVisita)
            });
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

