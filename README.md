# bank_account_management_api

Para este projeto, com base no desafio de gestão de contas bancárias apresentado abiaxo, foi realizado a construção de uma API
Para o gerenciamento de contas. 

DESAFIO
===============================================================================
Teste Backend .NET
Criar um projeto de API em c# para gestão de contas bancárias.
Requisitos:
• Criar um endpoint para cadastrar nome, e-mail e senha e gerar o número da conta aleatoriamente
• Criar um endpoint para realizar o login com e-mail e senha
• Criar um endpoint para obter o saldo da conta
• Criar um endpoint para obter extrato da conta
• Criar um endpoint para transferir valores entre contas
Diferenciais:
• Documentação via Swagger
• Arquivo de build do Docker (Dockerfile ou compose.yaml)
• Arquitetura baseada em microserviços
Entrega:
• Disponibilizar o código fonte em um repositório público no Github
==================================================================================

O banco de dados utilizado para salvar as informações foi o postgreSQL, o nome do banco a ser criado deve ser
bank_account_management.

As Querys utilizadas para a criação das tabelas são:

Criação da Tabela Accounts
===================================================================================
CREATE TABLE IF NOT EXISTS public.accounts
(
    id serial PRIMARY KEY,
    nome character varying(255) COLLATE pg_catalog."default" NOT NULL,
    email character varying(255) COLLATE pg_catalog."default" NOT NULL,
    senha character varying(255) COLLATE pg_catalog."default" NOT NULL,
    numeroConta character varying(255) COLLATE pg_catalog."default" NOT NULL,
    saldo numeric(10, 2) NOT NULL
);
=====================================================================================


Criação da Tabela Transfer, de transferencias.

======================================================================================
CREATE TABLE IF NOT EXISTS public.transfers
(
    id serial PRIMARY KEY,
    contaOrigemId integer NOT NULL,
    contaDestinoId integer NOT NULL,
    valor numeric(10, 2) NOT NULL,
    dataTransacao timestamp without time zone NOT NULL
);
=======================================================================================
