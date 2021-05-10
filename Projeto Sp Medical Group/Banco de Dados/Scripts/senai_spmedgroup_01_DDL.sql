CREATE DATABASE SP_Medical_Group;

USE SP_Medical_Group;


--Criando a tabela de tipos de usuarios
CREATE TABLE TipoUsuario
(
	IdTipoUsuario    	INT PRIMARY KEY IDENTITY
	,NomeTipoUsuario  	VARCHAR(50) NOT NULL
)

--Criando a tabela de usuarios
CREATE TABLE Usuario
(
	IdUsuario			INT PRIMARY KEY IDENTITY
	,IdTipoUsuario  	INT FOREIGN KEY REFERENCES TipoUSuario(IdTipoUsuario)
	,Nome				VARCHAR(50) NOT NULL
	,Email				VARCHAR(50) NOT NULL
	,Senha				VARCHAR(50) NOT NULL
)

--Criando a tabela de prontuarios
CREATE TABLE Prontuario
(
	IdProntuario	 	INT PRIMARY KEY IDENTITY
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
	,Nome				VARCHAR(50) NOT NULL
	,Telefone			VARCHAR(50) NOT NULL
	,RG					VARCHAR(50) NOT NULL
	,CPF				VARCHAR(50) NOT NULL
	,Endereco			VARCHAR(100) NOT NULL
	,DataNascimento	 	VARCHAR(100) NOT NULL
)

--Criando a tabela de clinicas
CREATE TABLE Clinica
(
	IdClinica					INT PRIMARY KEY IDENTITY
	,RazaoSocial				VARCHAR(100) NOT NULL
	,NomeFantasia				VARCHAR(100) NOT NULL
	,CNPJ						VARCHAR(50) NOT NULL
	,Endereco					VARCHAR(100) NOT NULL
	,HorarioFuncionamento   	VARCHAR(100)
)

--Criando a tabela de especialidades
CREATE TABLE Especialidades
(
	IdEspecialidade			INT PRIMARY KEY IDENTITY
	,NomeEspecialidade  	VARCHAR(100) NOT NULL
)

--Criando a tabela de medicos
CREATE TABLE Medico
(
	IdMedico			INT PRIMARY KEY IDENTITY
	,IdEspecialidade	INT FOREIGN KEY REFERENCES Especialidades(IdEspecialidade)
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
	,IdClinica			INT FOREIGN KEY REFERENCES Clinica(IdClinica)
	,Nome				VARCHAR(100) NOT NULL
	,CRM				VARCHAR(50) NOT NULL
)

--Criando a tabela de consultas
CREATE TABLE Consulta
(
	IdConsulta		INT PRIMARY KEY IDENTITY
	,IdProntuario   INT FOREIGN KEY REFERENCES Prontuario(IdProntuario)
	,IdMedico		INT FOREIGN KEY REFERENCES Medico(IdMedico)
	,DataConsulta	VARCHAR(100) NOT NULL
	,Situacao		VARCHAR(50) NOT NULL
)
