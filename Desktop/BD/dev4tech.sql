CREATE DATABASE Dev4Tech;
USE Dev4Tech;
-- Tabela de Empresas
CREATE TABLE Empresas (
    id_empresa INT PRIMARY KEY auto_increment,
    nome_empresa VARCHAR(100) NOT NULL,
    cnpj VARCHAR(14) UNIQUE NOT NULL,
    logradouro varchar(255),
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(15),
    numResidencia VARCHAR(200),
    bairro varchar(255),
    complemento varchar(255),
    data_cadEm DATETIME,
    setorEmpresarial VARCHAR(255)
);
-- Tabela de Administradores
CREATE TABLE Administradores (
    AdminId INT PRIMARY KEY auto_increment,
    Nome VARCHAR(100),
    Cargo VARCHAR(50),
    CPF CHAR(11) UNIQUE,
    DataNascimento DATE,
    Telefone VARCHAR(20),
    Email VARCHAR(100) unique,
    Senha VARCHAR(255),
    data_cadAdmin DATETIME,
    endereco VARCHAR(255) NOT NULL,
    num VARCHAR(255) NOT NULL,
    id_empresa INT,
    FOREIGN KEY (id_empresa) REFERENCES Empresas(id_empresa) ON DELETE CASCADE
);

-- Tabela de Funcionários
CREATE TABLE Funcionarios (
    FuncionarioId INT PRIMARY KEY auto_increment,
    Nome VARCHAR(100),
    Cargo VARCHAR(255),
    CPF CHAR(11) UNIQUE,
    DataNascimento DATE,
    Telefone VARCHAR(20),
    Email VARCHAR(255) UNIQUE,
    Senha VARCHAR(255),
    data_cadFunc DATETIME,
    endereco VARCHAR(255) NOT NULL,
    numero VARCHAR(255) NOT NULL,
    id_empresa INT,
    FOREIGN KEY (id_empresa) REFERENCES Empresas(id_empresa) ON DELETE CASCADE,
    AdminId INT,
    FOREIGN KEY (AdminId) REFERENCES Administradores(AdminId) ON DELETE CASCADE
);

ALTER TABLE Funcionarios ADD COLUMN foto_perfil LONGBLOB;
ALTER TABLE Administradores ADD COLUMN foto_perfil LONGBLOB;


-- Tabela Categorias
CREATE TABLE Categorias (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    nome_categoria VARCHAR(255) NOT NULL UNIQUE
);
-- Tabela Equipes
CREATE TABLE Equipes (
    id_equipe INT AUTO_INCREMENT PRIMARY KEY,
    nome_equipe VARCHAR(255) NOT NULL,
    id_categoria INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria) ON DELETE RESTRICT ON UPDATE CASCADE
);
ALTER TABLE Equipes ADD COLUMN data_criacao DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP;

CREATE TABLE Equipes_Membros (
    id_equipe INT NOT NULL,
    FuncionarioId INT NOT NULL,
    responsavel BOOLEAN DEFAULT FALSE,
    PRIMARY KEY (id_equipe, FuncionarioId),
    FOREIGN KEY (id_equipe) REFERENCES Equipes(id_equipe) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(FuncionarioId) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE MensagensChat (
    id_mensagem INT PRIMARY KEY auto_increment,
    texto varchar(255) NOT NULL,
    data_envio DATETIME,
    id_equipe INT,
    FOREIGN KEY (id_equipe) REFERENCES Equipes(id_equipe) ON DELETE CASCADE 
);



-- Criar tabela para armazenar última atividade
CREATE TABLE UltimaAtividadeEquipe (
    id_equipe INT PRIMARY KEY,
    ultima_atividade DATETIME NOT NULL,
    FOREIGN KEY (id_equipe) REFERENCES Equipes(id_equipe) ON DELETE CASCADE
);

CREATE TABLE Tarefas (
    id_tarefa INT AUTO_INCREMENT PRIMARY KEY,
    nomeTarefa VARCHAR(255) NOT NULL,
    instrucoes VARCHAR(255) NOT NULL,
    id_equipe INT NOT NULL,
    data_entrega DATE NOT NULL,
    nome_arquivo VARCHAR(255),
    arquivo_blob LONGBLOB,
    FOREIGN KEY (id_equipe) REFERENCES Equipes(id_equipe) ON DELETE CASCADE ON UPDATE CASCADE,
    dificuldade VARCHAR(20) NOT NULL
);


CREATE TABLE EntregasTarefa (
    id_entrega INT AUTO_INCREMENT PRIMARY KEY,
    id_tarefa INT NOT NULL,
    id_equipe INT NOT NULL,
    descricao TEXT,
    nome_arquivo VARCHAR(255),
    arquivo_blob LONGBLOB,
    data_entrega DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_tarefa) REFERENCES Tarefas(id_tarefa) ON DELETE CASCADE,
    FOREIGN KEY (id_equipe) REFERENCES Equipes(id_equipe) ON DELETE CASCADE
);
ALTER TABLE EntregasTarefa
ADD COLUMN FuncionarioId INT NOT NULL,
ADD FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(FuncionarioId) ON DELETE CASCADE;

CREATE TABLE PontuacaoFuncionario (
    id_pontuacao INT AUTO_INCREMENT PRIMARY KEY,
    id_funcionario INT NOT NULL,
    pontos INT NOT NULL DEFAULT 0,
    FOREIGN KEY (id_funcionario) REFERENCES Funcionarios(FuncionarioId) ON DELETE CASCADE
);

CREATE TABLE AvaliacaoTarefa (
    id_avaliacao INT AUTO_INCREMENT PRIMARY KEY,
    id_tarefa INT NOT NULL,
    aceita BOOLEAN NOT NULL,
    atraso_justificado BOOLEAN NULL,
    FOREIGN KEY (id_tarefa) REFERENCES Tarefas(id_tarefa) ON DELETE CASCADE
);


CREATE TABLE RelatoProblema (
	idProblema INT PRIMARY KEY AUTO_INCREMENT,
	id_tarefa int not null,
	id_equipe INT NOT NULL,
   FOREIGN KEY (id_tarefa) REFERENCES Tarefas(id_tarefa) ON DELETE CASCADE,
   FOREIGN KEY (id_equipe) REFERENCES Equipes(id_equipe) ON DELETE CASCADE,
	descricao TEXT NOT NULL
);