IF OBJECT_ID('dbo.dbProduto', 'U') IS NOT NULL
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.dbProduto)
    BEGIN
        INSERT INTO dbo.dbProduto (Nome, Descricao, Valor, TipoProduto)
        VALUES
            ('Sucrilhos', 'Descri��o do Produto 1', 10.50, 1),
            ('Sabonete', 'Descri��o do Produto 2', 15.75, 2),
            ('Amaciante', 'Descri��o do Produto 3', 20.00, 3),
            ('Ma�a', 'Descri��o do Produto 4', 12.99, 4),
            ('Luminaria', 'Descri��o do Produto 5', 8.50, 5),
            ('P�o Franc�s', 'Descri��o do Produto 6', 8.50, 6),
            ('Frango', 'Descri��o do Produto 7', 8.50, 7),
            ('Refrigerante', 'Descri��o do Produto 8', 8.50, 8),
            ('Caderno', 'Descri��o do Produto 9', 8.50, 9);
    END;
END;