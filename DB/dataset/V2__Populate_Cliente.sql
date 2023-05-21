IF EXISTS (SELECT 1 FROM dbo.dbCliente)

INSERT INTO dbo.dbCliente (Cpf, Nome, Sobrenome, Email)
VALUES
	('16291163004','Antonio', 'Ayrton', 'tonio@gmil.com'),
	('63163511007','Gabrielle', 'Leonardo', 'Bibi@gmail.com'),
	('02623731063','Julia', 'Mahatma', 'Ju@caju.com'),
	('49925782090','Enzo', 'Mohamed Ali', 'Enzo@hotmail.com'),
	('18234489097','Cristina', 'Nelson', 'Criszinha@outlook.com');