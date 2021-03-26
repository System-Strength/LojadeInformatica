/*Criando o banco de dados */
CREATE DATABASE BDLOJA
default character set utf8
default collate utf8_general_ci;

/*Usando o banco de dados */
USE BDLOJA;

/*Criando as tabelas do banco de dados */

CREATE TABLE tbl_Funcionario(
cod_Func int primary key auto_increment,
nome_Func varchar(50) not null,
cel_Func varchar(20) not null,
endereco_Func varchar(50) not null,
cargo_Func varchar(50) not null,
rg_Func char(11) unique not null,
senha_Func varchar(15) not null,
tipo_Func char(1) not null
);

CREATE TABLE tbl_Cliente(
cod_Cli int primary key auto_increment,
nome_Cli varchar(50) not null,
cel_Cli varchar(11) not null,
email_Cli varchar(50) unique not null,
endereco_Cli varchar(50) not null
);

CREATE TABLE tbl_Produto(
cod_Prod int primary key auto_increment,
nome_Prod varchar(50) not null,
marca_Prod varchar(100) not null,
categoria_Prod varchar (50) not null,
valor_Prod decimal(10,2) not null,
qtd_Prod int not null
);

CREATE TABLE tbl_Pagamento(
cod_Pagamento int primary key auto_increment,
forma_Pagamento varchar(50) not null
);

CREATE TABLE tbl_Vendas(
cod_Vendas int primary key auto_increment,
nome_Cli varchar(50) not null references tbl_Cliente(nome_Cli),
endereco_Cli varchar(50) not null references tbl_Cliente(endereco_Cli),
cel_Cli varchar(11) not null references tbl_Cliente(cel_Cli),
nome_Prod varchar(50) not null references tbl_Produto(nome_Prod),
qtd_Prod int not null references tbl_Produto(qtd_Prod),
forma_Pagamento varchar(50) not null references tbl_Pagamento(forma_Pagamento)
);

/*Inserindo dados nas tables */

insert into tbl_Pagamento (forma_Pagamento) values ('Débito');
insert into tbl_Pagamento (forma_Pagamento) values ('Crédito');

insert into tbl_Funcionario (nome_Func, cel_Func, endereco_Func, cargo_Func, rg_Func, senha_Func, tipo_Func) values ('Danilo Santos','11963251487','Rua Padre N°6','Gerente', 11111111111, "123456789", 0);

insert into tbl_Funcionario (nome_Func, cel_Func, endereco_Func, cargo_Func, rg_Func, senha_Func, tipo_Func) values ('Matheus Souza','11925469887','Rua São João N°6','Gerente', 22222222222, "1234567", 1);

select * from tbl_funcionario;

drop database bdloja;

select * from tbl_Funcionario where rg_Func = @RgFunc and senha_Func = @SenhaFunc
