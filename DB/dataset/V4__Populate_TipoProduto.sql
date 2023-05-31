IF OBJECT_ID('dbo.dbTipoProduto', 'U') IS NOT NULL
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbTipoProduto)
    BEGIN
        INSERT INTO dbTipoProduto (Id, TipoProduto)
        VALUES
            (1, 'Alimentos'),
            (2, 'Higiene'),
            (3, 'Limpeza'),
            (4, 'Hortifruti'),
            (5, 'Decoracao'),
            (6, 'Padaria'),
            (7, 'Congelados'),
            (8, 'Bebidas'),
            (9, 'Papelaria');
    END;
END;