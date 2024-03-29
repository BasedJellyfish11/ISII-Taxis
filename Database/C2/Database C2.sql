USE [ISII-TAXIS]
GO

CREATE PROCEDURE consulta_taxi 
@matricula_taxi VARCHAR(20)
AS
BEGIN
	SELECT 
		matricula_taxi,
		nombre_parada,
		email,
		desc_estado,
		hora_disponible

	FROM
		taxis
	LEFT JOIN
		estados_taxi
	ON 
		taxis.id_estado = estados_taxi.id_estado
	LEFT JOIN
		paradas
	ON
		taxis.id_parada = paradas.id_parada
	WHERE
		taxis.matricula_taxi = @matricula_taxi
END


GO


CREATE PROCEDURE consulta_paradas 
AS
BEGIN
	SELECT 
		id_parada,
		nombre_parada

	FROM
		paradas
END
GO

INSERT INTO estados_solicitud
VALUES
	(0, 'Sin confirmar'),
	(1, 'En progreso'),
	(2, 'Finalizada')
GO


CREATE PROCEDURE registro_solicitud(
	@nombre_usuario VARCHAR(64),
	@matricula_taxi VARCHAR(10),
	@id_parada_origen INT,
	@id_parada_destino INT,
	@hora_fecha DATETIME
	)
AS
BEGIN
	INSERT INTO
		solicitudes(nombre_usuario, matricula_taxi, id_parada_origen, id_parada_destino, id_estado, hora_fecha)
	VALUES
		(@nombre_usuario, @matricula_taxi, @id_parada_origen, @id_parada_destino, 0, @hora_fecha)
END
	
GO


CREATE PROCEDURE consulta_taxis
AS
BEGIN
	SELECT 
		matricula_taxi,
		nombre_parada,
		email,
		desc_estado,
		hora_disponible

	FROM
		taxis
	LEFT JOIN
		estados_taxi
	ON 
		taxis.id_estado = estados_taxi.id_estado
	LEFT JOIN
		paradas
	ON
		taxis.id_parada = paradas.id_parada
END

GO

CREATE PROCEDURE editar_taxi
	@matricula_taxi VARCHAR(10),
	@id_parada TINYINT,
	@id_estado TINYINT,
	@email VARCHAR(100),
	@n_plazas TINYINT,
	@hora_disponible DATETIME
AS
BEGIN 

	UPDATE taxis
	SET 
		email = @email, 
		id_parada = @id_parada, 
		id_estado = @id_estado,
		n_plazas = @n_plazas, 
		hora_disponible = @hora_disponible
	WHERE
		matricula_taxi = @matricula_taxi
	
END
GO

CREATE PROCEDURE eliminar_taxi
	@matricula_taxi VARCHAR(10)
AS
BEGIN 

	DELETE FROM taxis
	WHERE
		matricula_taxi = @matricula_taxi
	
END
GO

CREATE PROCEDURE obtener_solicitudes
@estado TINYINT
AS
BEGIN 

	SELECT
		id_solicitud,
		nombre_usuario,
		matricula_taxi,
		paradas_origen.nombre_parada AS parada_origen,
		paradas_destino.nombre_parada AS parada_destino,
		desc_estado,
		hora_fecha
	FROM
		solicitudes
	LEFT JOIN
		estados_solicitud
	ON
		solicitudes.id_estado = estados_solicitud.id_estado
	LEFT JOIN
		paradas paradas_origen
	ON
		solicitudes.id_parada_origen = paradas_origen.id_parada
	LEFT JOIN
		paradas paradas_destino
	ON
		solicitudes.id_parada_destino = paradas_destino.id_parada
	WHERE
		solicitudes.id_estado = COALESCE(@estado, solicitudes.id_estado)
	
END
GO

CREATE PROCEDURE validar_solicitud
	@id INT
AS
BEGIN 

	UPDATE solicitudes
	SET
		id_estado = 1
	WHERE
		id_solicitud = @id
	
END
GO

CREATE PROCEDURE rechazar_solicitud
	@id INT
AS
BEGIN 

	DELETE FROM solicitudes
	WHERE
		id_solicitud = @id
	
END
GO
