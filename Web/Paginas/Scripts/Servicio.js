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

async function LlenarTabla() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Servicios",
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

        $("#tblServicios").DataTable({
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

    let placa = $("#txtplaca").val();

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Servicios?id_servicio=" + id_servicio,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        $("#txtnombre").val(Resultado.nombre);
        $("#txtcosto").val(Resultado.costo);

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function EjecutarComando(Comando) {
    let nombre = $("#txtnombre").val();
    let costo = $("#txtcosto").val();

    let DatosServicio = {
        nombre: nombre,
        costo: costo
    }

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Servicios",
            {
                method: Comando,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DatosServicio)
            });
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}