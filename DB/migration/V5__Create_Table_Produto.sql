
IF OBJECT_ID('dbo.dbProduto', 'U') IS NOT NULL
BEGIN
CREATE TABLE dbProduto
(
    Id INT PRIMARY KEY,
    Nome VARCHAR(100),
    Descricao VARCHAR(255),
    Valor DECIMAL(10, 2),
    TipoProduto INT,
    FOREIGN KEY (TipoProduto) REFERENCES dbTipoProduto(Id)
)
END;
