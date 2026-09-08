----------------------------------------------------------------
-- Commercial Sales Manager - Database Verification & Diagnostics
----------------------------------------------------------------
USE CommercialSalesDB;
GO

-- 1. Table Record Counts Summary
SELECT 'Tipo_Produto' AS Tabela, COUNT(*) AS TotalRegistos FROM Tipo_Produto
UNION ALL
SELECT 'Material' AS Tabela, COUNT(*) AS TotalRegistos FROM Material
UNION ALL
SELECT 'Clientes' AS Tabela, COUNT(*) AS TotalRegistos FROM Clientes
UNION ALL
SELECT 'Vendedores' AS Tabela, COUNT(*) AS TotalRegistos FROM Vendedores
UNION ALL
SELECT 'Encomenda' AS Tabela, COUNT(*) AS TotalRegistos FROM Encomenda
UNION ALL
SELECT 'Linha_Encomenda' AS Tabela, COUNT(*) AS TotalRegistos FROM Linha_Encomenda;
GO

-- 2. Inspect Records by Table
SELECT * FROM Tipo_Produto;
SELECT * FROM Material;
SELECT * FROM Clientes;
SELECT * FROM Vendedores;
SELECT * FROM Encomenda;
SELECT * FROM Linha_Encomenda;
GO