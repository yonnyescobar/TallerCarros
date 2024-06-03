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
    LlenarComboClientes();
    LlenarMarcasVehiculo();
    LlenarTabla();
});

async function LlenarComboClientes() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Clientes",
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        for (i = 0; i < Resultado.length; i++) {
            $("#cboCliente").append('<option value="' + Resultado[i].id_cliente + '">' + Resultado[i].nombre + " " + Resultado[i].apellido + '</option >');
        }

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarMarcasVehiculo() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/MarcaVehiculos",
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        for (i = 0; i < Resultado.length; i++) {
            $("#cboMarcasVehiculo").append('<option value="' + Resultado[i].id_marca + '">' + Resultado[i].nombre + '</option >');
        }
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarTabla() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Vehiculos",
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

        $("#tblVehiculos").DataTable({
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
        const Respuesta = await fetch("http://localhost:50046/api/Vehiculos?placa=" + placa,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        $("#cboMarcasVehiculo").val(Resultado.id_marca);
        $("#txtmodelo").val(Resultado.modelo);
        $("#txtano").val(Resultado.ano);
        $("#cboCliente").val(Resultado.id_cliente);

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function EjecutarComando(Comando) {
    let marca = $("#cboMarcasVehiculo").val();
    let modelo = $("#txtmodelo").val();
    let ano = $("#txtano").val();
    let placa = $("#txtplaca").val();
    let Cliente = $("#cboCliente").val();

    let DatosVehiculo = {
        id_marca: marca,
        modelo: modelo,
        ano: ano,
        placa: placa,
        id_cliente: Cliente
    }

    try {
        const Respuesta = await fetch("http://localhost:50046/api/Vehiculos",
            {
                method: Comando,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(DatosVehiculo)
            });
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}