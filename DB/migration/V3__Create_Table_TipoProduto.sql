IF OBJECT_ID('dbo.dbTipoProduto', 'U') IS NULL
BEGIN
    CREATE TABLE dbTipoProduto
    (
        Id INT PRIMARY KEY,
        TipoProduto VARCHAR(100)
    )
END
