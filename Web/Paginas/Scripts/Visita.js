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
    LlenarClientes();
    LlenarVehiculo();
    LlenarEmpleado();
    LlenarTabla();
});

async function LlenarClientes() {
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

async function LlenarVehiculo() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Vehiculos",
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        for (i = 0; i < Resultado.length; i++) {
            $("#cboVehiculo").append('<option value="' + Resultado[i].id_vehiculo + '">' + Resultado[i].placa + '</option >');
        }

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarEmpleado() {
    try {
        const Respuesta = await fetch("http://localhost:50046/api/Empleados",
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Resultado = await Respuesta.json();
        for (i = 0; i < Resultado.length; i++) {
            $("#cboEmpleado").append('<option value="' + Resultado[i].id_empleado + '">' + Resultado[i].nombre + " " + Resultado[i].apellido + '</option >');
        }

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}