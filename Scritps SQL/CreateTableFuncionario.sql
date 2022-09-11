CREATE TABLE dbo.TB_Funcionario
	(
	CodFuncionario int NOT NULL IDENTITY (1, 1),
	Nome varchar(400) NOT NULL,
	DataNascimento datetime NOT NULL,
	Salario numeric(18, 2) NOT NULL,
	Atividades varchar(MAX) NOT NULL
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.TB_Funcionario ADD CONSTRAINT
	PK_TB_Funcionario PRIMARY KEY CLUSTERED 
	(
	CodFuncionario
	) ON [PRIMARY]

GO