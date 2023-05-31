IF OBJECT_ID('dbo.dbProduto', 'U') IS NOT NULL
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.dbProduto)
    BEGIN
        INSERT INTO dbo.dbProduto (Nome, Descricao, Valor, TipoProduto)
        VALUES
            ('Sucrilhos', 'Descrição do Produto 1', 10.50, 1),
            ('Sabonete', 'Descrição do Produto 2', 15.75, 2),
            ('Amaciante', 'Descrição do Produto 3', 20.00, 3),
            ('Maça', 'Descrição do Produto 4', 12.99, 4),
            ('Luminaria', 'Descrição do Produto 5', 8.50, 5),
            ('Pão Francês', 'Descrição do Produto 6', 8.50, 6),
            ('Frango', 'Descrição do Produto 7', 8.50, 7),
            ('Refrigerante', 'Descrição do Produto 8', 8.50, 8),
            ('Caderno', 'Descrição do Produto 9', 8.50, 9);
    END;
END;