USE CommercialSalesDB;
GO

----------------------------------------------------------------
-- 1. Insert Product Types / Categories (Electrical Material Families)
----------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'CAB')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('CAB', 'Cablagens e Condutores Industriais', 'Ativo');

IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'PROT')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('PROT', 'Aparelhagem Modular e Proteções', 'Ativo');

IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'APAR')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('APAR', 'Mecanismos e Aparelhagem de Embutir', 'Ativo');

IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'ILUM')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('ILUM', 'Iluminação Técnica e Projetores LED', 'Ativo');

IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'TUB')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('TUB', 'Tubos e Infraestruturas Técnicas', 'Ativo');
GO

----------------------------------------------------------------
-- 2. Insert Catalog Materials (Synthetic Model Data)
----------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'COND-15-PR')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('COND-15-PR', 'Cabo Flexível Sintético 1.5mm² Preto (Rolo 100m)', 'RL', 1, 29.80, 50, 'CAB', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'COND-25-AZ')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('COND-25-AZ', 'Cabo Flexível Sintético 2.5mm² Azul (Rolo 100m)', 'RL', 1, 44.20, 35, 'CAB', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'COND-3G15-CZ')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('COND-3G15-CZ', 'Cabo Multicondutor 3G1.5mm² Cinzento (Bobine 100m)', 'RL', 1, 68.50, 25, 'CAB', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'DISJ-1PN-16')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('DISJ-1PN-16', 'Disjuntor Modular DPN 1P+N 16A 4.5kA Curva C', 'UN', 12, 5.95, 140, 'PROT', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'DISJ-1PN-25')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('DISJ-1PN-25', 'Disjuntor Modular DPN 1P+N 25A 4.5kA Curva C', 'UN', 12, 7.20, 90, 'PROT', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'DIF-2P-40')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('DIF-2P-40', 'Interruptor Diferencial 2P 40A 30mA AC', 'UN', 1, 32.80, 40, 'PROT', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'MEC-INT-01')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('MEC-INT-01', 'Interruptor Unipolar Mecanismo Branco com Tecla', 'UN', 20, 3.90, 160, 'APAR', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'MEC-TOM-01')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('MEC-TOM-01', 'Tomada Schuko 2P+T 16A com Alvéolos Protegidos', 'UN', 20, 4.60, 150, 'APAR', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'LED-PAIN-40')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('LED-PAIN-40', 'Painel LED Modular 600x600 36W 4000K Neutro', 'UN', 4, 21.50, 60, 'ILUM', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'LED-PROJ-50')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('LED-PROJ-50', 'Projetor LED Exterior IP65 50W 5000K Preto', 'UN', 1, 24.90, 45, 'ILUM', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'TUB-VD-20')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('TUB-VD-20', 'Tubo Corrugado Flexível VD 20mm (Rolo 100m)', 'RL', 1, 17.50, 55, 'TUB', 23.00);
GO

----------------------------------------------------------------
-- 3. Insert Model Customers (Realistic Industrial Sector Companies)
----------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM Clientes WHERE ID_Cliente = 'CLI-001')
    INSERT INTO Clientes (ID_Cliente, Nome_Cliente, NIF, Morada_Completa, Codigo_Postal, Cidade, Email, Telefone)
    VALUES ('CLI-001', 'VoltNorte - Soluções Elétricas e Automação, Lda.', '509876540', 'Rua da Indústria, Lote 12 - Zona Industrial', '4470-001', 'Maia', 'compras@voltnorte.exemplo.pt', '229000101');

IF NOT EXISTS (SELECT * FROM Clientes WHERE ID_Cliente = 'CLI-002')
    INSERT INTO Clientes (ID_Cliente, Nome_Cliente, NIF, Morada_Completa, Codigo_Postal, Cidade, Email, Telefone)
    VALUES ('CLI-002', 'ElectroBraga - Instalações Técnicas, S.A.', '501234560', 'Avenida Principal, 88 - Celeirós', '4700-322', 'Braga', 'geral@electrobraga.exemplo.pt', '253000202');

IF NOT EXISTS (SELECT * FROM Clientes WHERE ID_Cliente = 'CLI-003')
    INSERT INTO Clientes (ID_Cliente, Nome_Cliente, NIF, Morada_Completa, Codigo_Postal, Cidade, Email, Telefone)
    VALUES ('CLI-003', 'Luz & Potência - Engenharia Eletrotécnica, Unipessoal', '503456780', 'Rua das Oliveiras, 45 - 2º Andar', '4400-240', 'Vila Nova de Gaia', 'projetos@luzpotencia.exemplo.pt', '227000303');

IF NOT EXISTS (SELECT * FROM Clientes WHERE ID_Cliente = 'CLI-004')
    INSERT INTO Clientes (ID_Cliente, Nome_Cliente, NIF, Morada_Completa, Codigo_Postal, Cidade, Email, Telefone)
    VALUES ('CLI-004', 'Central Minho - Comércio e Montagens Elétricas, Lda.', '508765430', 'Parque de Ciência e Tecnologia, Edifício B', '4800-050', 'Guimarães', 'obras@centralminho.exemplo.pt', '253000404');
GO

----------------------------------------------------------------
-- 4. Insert Model Sales Representatives (Demo Commercial Team)
----------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM Vendedores WHERE Email = 'carlos.silva@eletrodist.pt' OR PIN = '1755')
    INSERT INTO Vendedores (Cargo, Nome, PIN, Email, Senha, Telemovel, Percentagem_Comissao, Ativo)
    VALUES ('Director Comercial', 'Carlos Silva', '1755', 'carlos.silva@eletrodist.pt', 'Paredes10', '910000001', 7.00, 1);

IF NOT EXISTS (SELECT * FROM Vendedores WHERE Email = 'mariana.santos@eletrodist.pt' OR PIN = '1514')
    INSERT INTO Vendedores (Cargo, Nome, PIN, Email, Senha, Telemovel, Percentagem_Comissao, Ativo)
    VALUES ('Vendedora Comercial', 'Mariana Santos', '1514', 'mariana.santos@eletrodist.pt', 'Paredes11', '910000002', 2.00, 1);
GO

----------------------------------------------------------------
-- 5. Insert Sample Order with Cascading Discounts
----------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM Encomenda WHERE Numero_Encomenda = 1)
BEGIN
    SET IDENTITY_INSERT Encomenda ON;
    INSERT INTO Encomenda (Numero_Encomenda, Data_Encomenda, Valor_Total, Estado, ID_Cliente, ID_Vendedor, Desconto_Global)
    VALUES (1, CAST(GETDATE() AS DATE), 324.80, 'PENDENTE', 'CLI-001', 1, 2.50);
    SET IDENTITY_INSERT Encomenda OFF;

    INSERT INTO Linha_Encomenda (NE, Linha_Encomenda, Quantidade, Descricao, Preco, Desconto, Imposto, Codigo_Material, Desconto_Texto)
    VALUES (1, 1, 5, 'Cabo Flexível Sintético 1.5mm² Preto (Rolo 100m)', 29.80, 55.00, 23.00, 'COND-15-PR', '50+10');

    INSERT INTO Linha_Encomenda (NE, Linha_Encomenda, Quantidade, Descricao, Preco, Desconto, Imposto, Codigo_Material, Desconto_Texto)
    VALUES (1, 2, 20, 'Disjuntor Modular DPN 1P+N 16A 4.5kA Curva C', 5.95, 43.00, 23.00, 'DISJ-1PN-16', '40+5');
END
GO
