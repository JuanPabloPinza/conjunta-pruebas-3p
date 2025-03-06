Feature: ReporteCompleto

Vamos a agregar un cliente pero en este caso el teléfono va a tener solo 9 caracteres, por ende nos va a dar un error al agregar el cliente
@tag1
Scenario: Agregar Cliente con cedula menos de 10 digitos
	Given Nos encontramos en http://localhost:5279/cliente/Index
	And click en el boton Agregar Nuevo Cliente
	When llenamos el formulario
		| Cedula     | Nombres | Apellidos | FechaNacimiento | Mail                | Telefono | Direccion | Estado |
		| 175500892 | Juan    | Pinza     | 01/15/2004      | jppinza@espe.edu.ec | 1234567890 | Quito     | Activo |
	And click en el boton Registrar Cliente
	Then el sistema muestra un mensaje "La cédula debe tener 10 dígitos."


@tag2
Scenario: Agregar Cliente con datos correctosw
	Given Estamos en la URL principal http://localhost:5279/cliente/Index
	And Doy click en el boton Agregar Nuevo Cliente
	When llenamos el formulario con los datos
		| Cedula     | Nombres | Apellidos | FechaNacimiento | Mail                | Telefono | Direccion | Estado |
		| 1755008925 | Juan    | Pinza     | 01/15/2004      | jppinza@espe.edu.ec | 1234567890 | Quito     | Activo |
	And damos click en el botonn Registrar Cliente
	Then nos redirigimos a la URL iniciall	http://localhost:5279/Cliente


@tag3
Scenario: Se va a editar un nombbre del cliente
	Given Nos encontramos en la URLL  http://localhost:5279/cliente/Index
	And damos click en el botón editar del id 7
	When cambiamos el nombre a "Prueba"
	And damos click en el botón Guardar Cambios
	Then el sistema nos redirige al listado de clientes http://localhost:5279/Cliente

@tag4
Scenario: Se va a editar un nombre del cliente
	Given Nos encontramos en  http://localhost:5279/cliente/Index
	And damos click en el botón editar del id 7
	When cambiamos el la cedula erronea a 175500892
	And damos click en el botón Guardar Cambios
	Then el sistema indica un mensaje de error "La cédula debe tener 10 dígitos."