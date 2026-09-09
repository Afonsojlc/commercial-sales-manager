----------------------------------------------------------------
-- Commercial Sales Manager - Database Schema Initialization
----------------------------------------------------------------
USE master;
GO

-- Drop database if it already exists (fresh installation setup)
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'CommercialSalesDB')
BEGIN
    ALTER DATABASE CommercialSalesDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CommercialSalesDB;
END
GO

----------------------------------------------------------------
-- Create Database
----------------------------------------------------------------
CREATE DATABASE CommercialSalesDB;
GO

USE CommercialSalesDB;
GO

----------------------------------------------------------------
-- Database Tables Creation
----------------------------------------------------------------	
-- Phase 1: Core Entities and Tables
----------------------------------------------------------------
create table Encomenda(
    Numero_Encomenda int identity(1,1),
    Data_Encomenda date,
    Valor_Total money,
    Estado varchar(100),
    constraint pk_Encomenda primary key(Numero_Encomenda)
);

create table Linha_Encomenda(
    NE int,
    Linha_Encomenda int,
    Quantidade int not null,
    Descricao varchar(150),
    Preco money,
    Desconto decimal(5, 2),
    Imposto decimal(5, 2),
    constraint pk_Linha_Encomenda primary key(NE, Linha_Encomenda),
    constraint fk_Linha_Encomenda foreign key(NE) references Encomenda(Numero_Encomenda)
);

create table Tipo_Produto(
    Id_Produto varchar(10),
    Designacao varchar(50),
    Estado varchar(25),
    constraint pk_Id_Produto primary key(Id_Produto)
);

create table Material(
    Codigo varchar(15),
    Descricao varchar(150),
    Unidade_Venda varchar(10),
    Embalagem int,
    PVP_Unidade money,
    Stock int,
    constraint pk_Material primary key(Codigo)
);

create table Clientes(
	ID_Cliente varchar(15),
	Nome_Cliente varchar(100) NOT NULL,
	NIF varchar(20) NOT NULL,
	Morada_Completa varchar(200) NOT NULL,
	Codigo_Postal varchar(10),
	Cidade varchar(20),
	Email varchar(150) NOT NULL,
	Telefone varchar(150) NOT NULL,
    constraint pk_Clientes primary key(ID_Cliente)
);

create table Vendedores (
    ID_Vendedor int identity(1,1),
    Cargo varchar(50) default 'Vendedor',
    Nome varchar(100) NOT NULL,
    PIN varchar(4) NOT NULL, -- Access PIN code
    Email varchar(150) NULL, -- Optional email address
    Senha varchar(50) NULL,
    Telemovel varchar(20) NULL, -- Contact mobile number
    Percentagem_Comissao decimal(5,2) default 5.00,
    Ativo bit default 1, -- Active status: 1 = Active staff, 0 = Inactive (preserves historical sales)
    constraint pk_Vendedores primary key(ID_Vendedor)
);

----------------------------------------------------------------	
-- Phase 2: Foreign Keys and Relational Constraints
----------------------------------------------------------------

-- Order placed by Customer: 1-to-N relationship (Customer is mandatory)
alter table Encomenda add 
	ID_Cliente varchar(15) not null,
	constraint fk_Encomenda_Cliente foreign key(ID_Cliente) references Clientes(ID_Cliente);

-- Order Line contains Material/Product: 1-to-N relationship
alter table Linha_Encomenda add
    Codigo_Material varchar(15),
    constraint fk_Linha_Encomenda_Material foreign key(Codigo_Material) references Material(Codigo);

-- Each Material belongs to a Product Type / Category: 1-to-N relationship
alter table Material add
    ID_Tipo varchar(10),
    constraint fk_Material_Produto foreign key(ID_Tipo) references Tipo_Produto(Id_Produto);

-- Each Order is created by a Seller / Sales Representative: 1-to-N relationship
alter table Encomenda add 
    ID_Vendedor int,
    constraint FK_Encomenda_Vendedor foreign key(ID_Vendedor) references Vendedores(ID_Vendedor);

----------------------------------------------------------------	
-- Phase 3: Commercial Extensions and Tax Calculations
----------------------------------------------------------------

-- Global order discount field (e.g. 2.50%)
alter table Encomenda 
add Desconto_Global decimal(5, 2) default 0;

-- Expression string for cascade discounts (e.g. "50+10")
alter table Linha_Encomenda 
add Desconto_Texto VARCHAR(20);

-- Product-specific VAT rate (default 23.00%)
alter table Material 
add Taxa_IVA decimal(5, 2) default 23.00;