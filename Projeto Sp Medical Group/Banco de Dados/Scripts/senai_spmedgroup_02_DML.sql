USE SP_Medical_Group;

--Inserindo as especialidades
INSERT INTO Especialidades(NomeEspecialidade)
VALUES					  ('Acupuntura')
					      ,('Anestesiologia')
						  ,('Angiologia')
						  ,('Cardiologia')
						  ,('Cirurgia Cardiovascular')
						  ,('Cirurgia da Mão')
						  ,('Cirurgia do Aparelho Digestivo')
						  ,('Cirurgia Geral')
						  ,('Cirurgia Pediátrica')
						  ,('Cirurgia Plástica')
						  ,('Cirurgia Torácica')
						  ,('Cirurgia Vascular')
						  ,('Dermatologia')
						  ,('Radioterapia')
						  ,('Urologia')
						  ,('Pediatria')
						  ,('Psiquiatria');


--Inserindo os tipos de usuario
INSERT INTO TipoUsuario(NomeTipoUsuario)
VALUES				   ('Administrador')
					   ,('Médico')
					   ,('Paciente');

--Inserindo a clinica
INSERT INTO Clinica(NomeFantasia, RazaoSocial, Endereco, CNPJ, HorarioFuncionamento)
VALUES			   ('Clinica Possarle', 'Sp Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP', '93.196.571/0001-24', '24H');


--Inserido os usuarios
INSERT INTO Usuario(IdTipoUsuario, Nome, Email, Senha)
VALUES			   (1, 'Administrador', 'SpMedi.admin@gmail.com', 'SpAdmin0101')
				   ,(2, 'Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', 'LemosSpMedi123')
				   ,(2, 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br', 'PossarleSpMedi321')
				   ,(2, 'Helena Strada', 'helena.souza@spmedicalgroup.com.br', 'SouzaSpMedi456')
				   ,(3, 'Ligia', 'ligia@gmail.com', 'Ligia@132')
				   ,(3, 'Alexandre', 'alexandre@gmail.com', 'Ale@132')
				   ,(3, 'Fernando', 'fernando@gmail.com', 'Fer@132')
				   ,(3, 'Henrique', 'henrique@gmail.com', 'Henri@132')
				   ,(3, 'João', 'joao@hotmail.com', 'Joao@132')
				   ,(3, 'Bruno', 'bruno@gmail.com', 'Bruno@132')
				   ,(3, 'Mariana', 'mariana@outlook.com', 'Mari@132');

--Inserindo os medicos
INSERT INTO Medico(IdEspecialidade, IdClinica, IdUsuario, Nome, CRM)
VALUES			  (2, 1, 2, 'Ricardo Lemos', '54356-SP')
				  ,(17, 1, 3, 'Roberto Possarle', '53452-SP')
				  ,(16, 1, 4, 'Helena Strada', '65463-SP');

--Inserindo os prontuario dos pacientes
INSERT INTO Prontuario(IdUsuario, Nome, Telefone, RG, CPF, DataNascimento, Endereco)
VALUES				  (5, 'Ligia', '1134567654', '435225435', '94839859000', '10/13/1983', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000')
					  ,(6, 'Alexandre', '11987656543', '32654345-7', '73556944057','7/23/2001', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200')
					  ,(7, 'Fernando', '11972084453', '546365253', '16839338002', '10/10/1978', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200')
					  ,(8, 'Henrique', '1134566543', '54366362-5', '14332654765', '10/13/1985', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
					  ,(9, 'João', '1176566377', '532544441', '91305348010', '8/27/1975', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380')
					  ,(10, 'Bruno', '11954368769', '54566266-7', '79799299004', '3/21/1972', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001')
					  ,(11, 'Mariana', '', '545662668', '13771913039', '3/5/2018', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

--Inserindo as consultas
INSERT INTO Consulta(IdProntuario, IdMedico, DataConsulta, Situacao)
VALUES				(7, 3, '1/20/20 15:00', 'Realizada')
					,(2, 2, '1/6/20 10:00',	'Cancelada')
					,(3, 2, '2/7/20 11:00',	'Realizada')
					,(2, 2, '2/6/18 10:00',	'Realizada')
					,(4, 1, '2/7/19 11:00',	'Cancelada')
					,(7, 3, '3/8/20 15:00',	'Agendada')
					,(4, 1, '3/8/20 15:00',	'Agendada');