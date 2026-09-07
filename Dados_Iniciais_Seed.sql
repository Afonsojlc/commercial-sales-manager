USE Software_Vendas_Pai;
GO

-- 1. Inserir Tipos de Produto
IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'ILUM')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('ILUM', 'Iluminação LED e Técnica', 'Ativo');

IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'CAB')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('CAB', 'Cablagem e Condutores', 'Ativo');

IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'APAR')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('APAR', 'Aparelhagem e Tomadas', 'Ativo');

IF NOT EXISTS (SELECT * FROM Tipo_Produto WHERE Id_Produto = 'PROT')
    INSERT INTO Tipo_Produto (Id_Produto, Designacao, Estado) VALUES ('PROT', 'Proteção e Quadros Elétricos', 'Ativo');
GO

-- 2. Inserir Materiais (Catálogo de Material Elétrico)
IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'CAB-001')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('CAB-001', 'Cabo H07V-U 1.5mm² Preto (Rolo 100m)', 'RL', 1, 28.50, 45, 'CAB', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'CAB-002')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('CAB-002', 'Cabo H07V-U 2.5mm² Azul (Rolo 100m)', 'RL', 1, 42.00, 30, 'CAB', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'DIS-016')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('DIS-016', 'Disjuntor Magnetotérmico 1P+N 16A Curva C', 'UN', 12, 6.80, 115, 'PROT', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'DIS-032')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('DIS-032', 'Disjuntor Magnetotérmico 1P+N 32A Curva C', 'UN', 12, 9.20, 80, 'PROT', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'INT-001')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('INT-001', 'Interruptor Simples Efapel Logus 90 Branco', 'UN', 20, 4.50, 180, 'APAR', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'TOM-001')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('TOM-001', 'Tomada 2P+T Schuko Efapel Logus 90 Branco', 'UN', 20, 5.20, 160, 'APAR', 23.00);

IF NOT EXISTS (SELECT * FROM Material WHERE Codigo = 'LED-018')
    INSERT INTO Material (Codigo, Descricao, Unidade_Venda, Embalagem, PVP_Unidade, Stock, ID_Tipo, Taxa_IVA)
    VALUES ('LED-018', 'Painel LED Encastrar 60x60 40W 4000K Branco', 'UN', 4, 18.90, 65, 'ILUM', 23.00);
GO

-- 3. Inserir Clientes Reais
IF NOT EXISTS (SELECT * FROM Clientes WHERE ID_Cliente = 'CLI-001')
    INSERT INTO Clientes (ID_Cliente, Nome_Cliente, NIF, Morada_Completa, Codigo_Postal, Cidade, Email, Telefone)
    VALUES ('CLI-001', 'ElectroNorte - Instalações Elétricas Lda', '501234567', 'Rua da Indústria, 120, Zona Industrial', '4470-001', 'Maia', 'compras@electronorte.pt', '229876543');

IF NOT EXISTS (SELECT * FROM Clientes WHERE ID_Cliente = 'CLI-002')
    INSERT INTO Clientes (ID_Cliente, Nome_Cliente, NIF, Morada_Completa, Codigo_Postal, Cidade, Email, Telefone)
    VALUES ('CLI-002', 'Luz & Força Instalações Técnicas Unipessoal', '509876543', 'Avenida dos Aliados, 45, 2º Andar', '4000-064', 'Porto', 'geral@luzeforca.pt', '223456789');

IF NOT EXISTS (SELECT * FROM Clientes WHERE ID_Cliente = 'CLI-003')
    INSERT INTO Clientes (ID_Cliente, Nome_Cliente, NIF, Morada_Completa, Codigo_Postal, Cidade, Email, Telefone)
    VALUES ('CLI-003', 'Volt & Watt Engenharia e Automação', '504567890', 'Rua das Oliveiras, 88', '4400-240', 'Vila Nova de Gaia', 'projetos@voltwatt.pt', '227654321');
GO

-- 4. Inserir Vendedores (Admin / Diretor Comercial e Vendedor)
IF NOT EXISTS (SELECT * FROM Vendedores WHERE PIN = '1234')
    INSERT INTO Vendedores (Cargo, Nome, PIN, Email, Senha, Telemovel, Percentagem_Comissao, Ativo)
    VALUES ('Diretor Comercial', 'Afonso Carvalho (Diretor Comercial)', '1234', 'admin@comercial.pt', 'admin', '912345678', 5.00, 1);

IF NOT EXISTS (SELECT * FROM Vendedores WHERE PIN = '1111')
    INSERT INTO Vendedores (Cargo, Nome, PIN, Email, Senha, Telemovel, Percentagem_Comissao, Ativo)
    VALUES ('Vendedor', 'João Silva', '1111', 'joao.silva@comercial.pt', 'vendedor', '934567890', 3.50, 1);
GO

-- 5. Inserir Encomenda Exemplo
IF NOT EXISTS (SELECT * FROM Encomenda WHERE Numero_Encomenda = 1)
BEGIN
    SET IDENTITY_INSERT Encomenda ON;
    INSERT INTO Encomenda (Numero_Encomenda, Data_Encomenda, Valor_Total, Estado, ID_Cliente, ID_Vendedor, Desconto_Global)
    VALUES (1, CAST(GETDATE() AS DATE), 312.45, 'PENDENTE', 'CLI-001', 1, 2.50);
    SET IDENTITY_INSERT Encomenda OFF;

    INSERT INTO Linha_Encomenda (NE, Linha_Encomenda, Quantidade, Descricao, Preco, Desconto, Imposto, Codigo_Material, Desconto_Texto)
    VALUES (1, 1, 5, 'Cabo H07V-U 1.5mm² Preto (Rolo 100m)', 28.50, 55.00, 23.00, 'CAB-001', '50+10');

    INSERT INTO Linha_Encomenda (NE, Linha_Encomenda, Quantidade, Descricao, Preco, Desconto, Imposto, Codigo_Material, Desconto_Texto)
    VALUES (1, 2, 20, 'Disjuntor Magnetotérmico 1P+N 16A Curva C', 6.80, 43.00, 23.00, 'DIS-016', '40+5');
END
GO
