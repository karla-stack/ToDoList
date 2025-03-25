select * from task
select * from users

DROP TABLE IF EXISTS task;
DROP TABLE IF EXISTS users;


CREATE TABLE users (
Id INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL,
Contraseña VARCHAR(255) NOT NULL,
);

CREATE TABLE task (
Id INT PRIMARY KEY IDENTITY(1, 1),
Nombre VARCHAR(100),
Estado VARCHAR(50),
Descripcion VARCHAR(255),
UsuarioId INT,
FOREIGN KEY (UsuarioId) REFERENCES users(Id)
);


-- Insertar los datos
INSERT INTO task (Nombre, Estado, Descripcion) VALUES
('Hacer ejercicio', 'Completado', 'Correr 5km'),
('Leer un libro', 'En progreso', 'Capítulo 3');

INSERT INTO users (Nombre, Email, Contraseña)
VALUES ('Juan Peréz', 'juan.perez@example.com', 'admin123');

