CREATE DATABASE cine_db;
GO

USE cine_db;
GO

CREATE TABLE pelicula (
    id_pelicula INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(150) NOT NULL,
    duracion INT NOT NULL,
    estado BIT NOT NULL DEFAULT 1,

);

CREATE TABLE sala_cine (
    id_sala INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    estado BIT NOT NULL DEFAULT 1,

);


CREATE TABLE pelicula_sala_cine (
    id_pelicula_sala INT IDENTITY(1,1) PRIMARY KEY,
    id_pelicula INT NOT NULL,
    id_sala INT NOT NULL,
    fecha_publicacion DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    estado BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_PeliculaSala_Pelicula
        FOREIGN KEY (id_pelicula) REFERENCES pelicula(id_pelicula),

    CONSTRAINT FK_PeliculaSala_Sala
        FOREIGN KEY (id_sala) REFERENCES sala_cine(id_sala)
);

INSERT INTO pelicula (nombre, duracion) VALUES
('Avengers: Endgame', 181),
('Spider-Man: No Way Home', 148),
('The Batman', 176),
('Fast & Furious 9', 145),
('Jurassic World Dominion', 147),
('Doctor Strange 2', 126),
('Black Panther', 134),
('Inception', 148);

INSERT INTO sala_cine (nombre) VALUES
('Sala 1'),
('Sala 2'),
('Sala 3'),
('Sala VIP'),
('Sala IMAX');
INSERT INTO pelicula_sala_cine (id_pelicula, id_sala, fecha_publicacion, fecha_fin) VALUES
(1, 1, '2026-04-01', '2026-04-15'),
(2, 2, '2026-04-01', '2026-04-20'),
(3, 3, '2026-04-05', '2026-04-25'),
(4, 1, '2026-04-10', '2026-04-30'),
(5, 4, '2026-04-01', '2026-04-18'),
(6, 5, '2026-04-03', '2026-04-22'),
(7, 2, '2026-04-07', '2026-04-28'),
(8, 3, '2026-04-01', '2026-04-15');

INSERT INTO pelicula_sala_cine (id_pelicula, id_sala, fecha_publicacion, fecha_fin) VALUES
(3, 1, '2026-04-01', '2026-04-20'),
(5, 1, '2026-04-01', '2026-04-20');
INSERT INTO pelicula_sala_cine (id_pelicula, id_sala, fecha_publicacion, fecha_fin) VALUES
(1, 2, '2026-04-01', '2026-04-20'),
(3, 2, '2026-04-01', '2026-04-20'),
(4, 2, '2026-04-01', '2026-04-20'),
(5, 2, '2026-04-01', '2026-04-20');


INSERT INTO pelicula (nombre, duracion) VALUES
('Sin piedad', 90);

/* liste todas las películas activas osea estado = 1 junto con las salas y las fechas de publicación*/
CREATE PROCEDURE sp_ListarPeliculasActivas
AS
BEGIN
    SELECT 
        p.id_pelicula,
        p.nombre AS pelicula,
        p.duracion,
        s.id_sala,
        s.nombre AS sala,
        ps.fecha_publicacion,
        ps.fecha_fin
    FROM pelicula p
    INNER JOIN pelicula_sala_cine ps ON p.id_pelicula = ps.id_pelicula
    INNER JOIN sala_cine s ON s.id_sala = ps.id_sala
    WHERE p.estado = 1 AND s.estado = 1 AND ps.estado = 1
    ORDER BY ps.fecha_publicacion;
END;
GO
EXEC sp_ListarPeliculasActivas;

