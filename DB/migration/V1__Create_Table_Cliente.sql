IF OBJECT_ID('dbo.dbCliente', 'U') IS NOT NULL
    DROP TABLE dbo.dbCliente;

CREATE TABLE dbo.dbCliente (
  Id int NOT NULL IDENTITY(1,1),
  Cpf varchar(11) NOT NULL,
  Nome varchar(80) NOT NULL,
  Sobrenome varchar(80) NOT NULL,
  Email varchar(100) NOT NULL,
  PRIMARY KEY (Id)
);