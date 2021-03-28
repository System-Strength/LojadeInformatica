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
cod_Cli int not null references tbl_Cliente(cod_Cli),
endereco_Cli varchar(50) not null references tbl_Cliente(endereco_Cli),
cel_Cli varchar(11) not null references tbl_Cliente(cel_Cli),
cod_Prod int not null references tbl_Produto(cod_Prod),
qtd_Prod int not null ,
cod_Pagamento int not null references tbl_Pagamento(cod_Pagamento)
);


drop table tbl_Vendas;

select tbl_Vendas.cod_Vendas, tbl_Cliente.nome_Cli, tbl_Cliente.endereco_Cli, tbl_Cliente.cel_Cli,
tbl_Produto.nome_Prod, tbl_Produto.qtd_Prod, tbl_Pagamento.forma_Pagamento from tbl_Vendas, tbl_Cliente, tbl_Produto, tbl_Pagamento 
where tbl_Vendas.cod_Cli = tbl_Cliente.cod_Cli and tbl_Vendas.cod_Prod = tbl_Produto.cod_Prod and tbl_Vendas.cod_Pagamento = tbl_Pagamento.cod_Pagamento ;

select tbl_Vendas.cod_Vendas, tbl_Cliente.nome_Cli, tbl_Cliente.endereco_Cli, tbl_Cliente.cel_Cli,
tbl_Produto.nome_Prod, tbl_Produto.qtd_Prod, tbl_Pagamento.forma_Pagamento from tbl_Vendas, tbl_Cliente, tbl_Produto, tbl_Pagamento
where tbl_Vendas.cod_Cli = tbl_Cliente.cod_Cli and tbl_Vendas.cod_Prod = tbl_Produto.cod_Prod and tbl_Vendas.cod_Pagamento = tbl_Pagamento.cod_Pagamento;



select tbl_Produto.nome_Prod, tbl_Produto.qtd_Prod from tbl_Vendas, tbl_Produto 
where tbl_Vendas.cod_Prod = tbl_Produto.cod_Prod;

select * from tbl_Vendas;

select * from tbl_Produto;

select * from tbl_funcionario;


/*Inserindo dados nas tables */

insert into tbl_Pagamento (forma_Pagamento) values ('Débito');
insert into tbl_Pagamento (forma_Pagamento) values ('Crédito');

insert into tbl_Funcionario (nome_Func, cel_Func, endereco_Func, cargo_Func, rg_Func, senha_Func, tipo_Func) values ('Danilo Santos','11963251487','Rua Padre N°6','Gerente', 11111111111, "123456789", 0);

insert into tbl_Funcionario (nome_Func, cel_Func, endereco_Func, cargo_Func, rg_Func, senha_Func, tipo_Func) values ('Matheus Souza','11925469887','Rua São João N°6','Gerente', 22222222222, "1234567", 1);

insert into tbl_Produto (nome_Prod, marca_Prod, categoria_Prod, valor_Prod, qtd_Prod) values("Teclado Dell", "Dell", "Teclado", "199.00", "300");

drop database bdloja;

select * from tbl_Funcionario where rg_Func = @RgFunc and senha_Func = @SenhaFunc
