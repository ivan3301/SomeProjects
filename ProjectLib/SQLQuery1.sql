CREATE TABLE [dbo].[users_db] (
login NVARCHAR(25) NOT NULL,
password NVARCHAR(25) NOT NULL,
name NVARCHAR(25) NOT NULL,
PRIMARY KEY (login)
);

INSERT INTO users_db (login, password, name) VALUES ('adm', 'adm', N'Администратор')