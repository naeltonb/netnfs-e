USE [Bd]
GO
/****** Object:  Table [dbo].[tb_NaturezaOperacao]    Script Date: 10/04/2012 01:54:38 ******/
INSERT [dbo].[tb_NaturezaOperacao] ([Id], [Descricao]) VALUES (1, N'TRIBUTAÇÃO NO MUNICIPIO')
INSERT [dbo].[tb_NaturezaOperacao] ([Id], [Descricao]) VALUES (2, N'TRIBUTAÇÃO FORA DO MUNICIPIO')
INSERT [dbo].[tb_NaturezaOperacao] ([Id], [Descricao]) VALUES (3, N'ISENÇÃO')
INSERT [dbo].[tb_NaturezaOperacao] ([Id], [Descricao]) VALUES (4, N'IMUNE')
INSERT [dbo].[tb_NaturezaOperacao] ([Id], [Descricao]) VALUES (5, N'EXIGIBILIDADE SUSPENSA POR DECISÃO JUDICIAL')
INSERT [dbo].[tb_NaturezaOperacao] ([Id], [Descricao]) VALUES (6, N'EXIGIBILIDADE SUSPENSA POR PROCEDIMENTO ADMINISTRATIVO')
/****** Object:  Table [dbo].[tb_Municipio]    Script Date: 10/04/2012 01:54:38 ******/
INSERT [dbo].[tb_Municipio] ([CodigoMunicipio], [Municipio]) VALUES (N'3106200', N'BELO HORIZONTE')
INSERT [dbo].[tb_Municipio] ([CodigoMunicipio], [Municipio]) VALUES (N'3118601', N'CONTAGEM')
INSERT [dbo].[tb_Municipio] ([CodigoMunicipio], [Municipio]) VALUES (N'3154606', N'RIBEIRÃO DAS NEVES')
INSERT [dbo].[tb_Municipio] ([CodigoMunicipio], [Municipio]) VALUES (N'3171204', N'VESPASIANO')
/****** Object:  Table [dbo].[tb_ItemListaServico]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_ItemListaServico] ON
INSERT [dbo].[tb_ItemListaServico] ([Id], [CodigoServico], [DescricaoServico]) VALUES (3, N'33.01', N'SERVICOS DE DESEMBARACO ADUANEIRO, COMISSARIOS, DESPACHANTES E CONGENERES')
SET IDENTITY_INSERT [dbo].[tb_ItemListaServico] OFF
/****** Object:  Table [dbo].[tb_ConfigGridNfse]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_ConfigGridNfse] ON
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (1, N'NumRps', 1, N'SIM', N'Nº do Rps')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (2, N'NumNota', 2, N'SIM', N'Nº da Nota')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (3, N'DataEmissao', 4, N'SIM', N'Data de emissão')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (4, N'NumLote', 0, N'SIM', N'Nº do Lote')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (5, N'Serie', 3, N'SIM', N'Série')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (6, N'Competencia', 5, N'SIM', N'Competência')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (7, N'Tomador', 7, N'SIM', N'Tomador do serviço (cliente)')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (8, N'Intermediario', 9, N'NÃO', N'Intermediário do serviço')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (9, N'OrgaoGerador', 13, N'SIM', N'Municipio de emissão')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (10, N'CodigoObra', 10, N'NÃO', N'Código da Obra')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (11, N'CodigoVerificacao', 8, N'SIM', N'Código de Verificação')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (12, N'ValorServico', 6, N'SIM', N'Valor do serviço')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (13, N'EmailTomador', 12, N'SIM', N'E-mail do tomador (cliente)')
INSERT [dbo].[tb_ConfigGridNfse] ([Id], [Nome_Coluna], [Index_Coluna], [Coluna_Visivel], [Titulo_Coluna]) VALUES (14, N'StatusEnvioEmail', 11, N'SIM', N'Status envio e-mail')
SET IDENTITY_INSERT [dbo].[tb_ConfigGridNfse] OFF
/****** Object:  Table [dbo].[tb_CadEmpresa]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_CadEmpresa] ON
INSERT [dbo].[tb_CadEmpresa] ([Id], [RazaoSocial], [NomeFantasia], [CodigoCnae], [Cnpj], [InscricaoMunicipal], [InscricaoEstadual], [Logradouro], [Numero], [Complemento], [Bairro], [Cidade], [Uf], [Cep], [Telefone], [Email], [Contato]) VALUES (3, N'HERALDO BELISSARIO ACESSORIA ADUANEIRA LTDA', N'HERALDO BELISSARIO', N'1234', N'25.385.444/0001-13', N'3637900019', N'', N'AV COSTA E SILVA', N'230', N'COMPLEMENTO', N'MENEZES', N'RIBEIRÃO DAS NEVES', N'MG', N'33913-290', N'(31)3333-3333', N'heraldo@heraldobelisario.com.br', N'HERALDO')
SET IDENTITY_INSERT [dbo].[tb_CadEmpresa] OFF
/****** Object:  Table [dbo].[tb_Perfil]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_Perfil] ON
INSERT [dbo].[tb_Perfil] ([Id], [Nome_Perfil]) VALUES (1, N'ADMINISTRADOR')
INSERT [dbo].[tb_Perfil] ([Id], [Nome_Perfil]) VALUES (2, N'FINANCEIRO')
SET IDENTITY_INSERT [dbo].[tb_Perfil] OFF
/****** Object:  Table [dbo].[tb_TributacaoMunicipio]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_TributacaoMunicipio] ON
INSERT [dbo].[tb_TributacaoMunicipio] ([Id], [Codigo], [Descricao]) VALUES (1, N'330100188', N'SERVICOS DE DESEMBARACO ADUANEIRO, COMISSARIOS, DESPACHANTES E CONGENERES.')
SET IDENTITY_INSERT [dbo].[tb_TributacaoMunicipio] OFF
/****** Object:  Table [dbo].[tb_TipoRps]    Script Date: 10/04/2012 01:54:38 ******/
INSERT [dbo].[tb_TipoRps] ([Id], [Descricao]) VALUES (1, N'RPS')
INSERT [dbo].[tb_TipoRps] ([Id], [Descricao]) VALUES (2, N'NOTA FISCAL CONJUGADA')
INSERT [dbo].[tb_TipoRps] ([Id], [Descricao]) VALUES (3, N' CUPOM')
/****** Object:  Table [dbo].[tb_RegimeEspTributacao]    Script Date: 10/04/2012 01:54:38 ******/
INSERT [dbo].[tb_RegimeEspTributacao] ([Id], [Descricao]) VALUES (1, N'MICROEMPRESA MUNICIPAL')
INSERT [dbo].[tb_RegimeEspTributacao] ([Id], [Descricao]) VALUES (2, N'ESTIMATIVA')
INSERT [dbo].[tb_RegimeEspTributacao] ([Id], [Descricao]) VALUES (3, N'SOCIEDADE DE PROFISSIONAIS')
INSERT [dbo].[tb_RegimeEspTributacao] ([Id], [Descricao]) VALUES (4, N'COOPERATIVA')
INSERT [dbo].[tb_RegimeEspTributacao] ([Id], [Descricao]) VALUES (5, N'MEI - SIMPLES NACIONAL')
INSERT [dbo].[tb_RegimeEspTributacao] ([Id], [Descricao]) VALUES (6, N'ME EPP - SIMPLES NACIONAL')
/****** Object:  Table [dbo].[tb_Usuarios]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_Usuarios] ON
INSERT [dbo].[tb_Usuarios] ([Id], [Nome], [Login], [Senha], [Id_Perfil], [Alterar_Senha]) VALUES (1, N'JOSIMAR CORDEIRO DA SILVA', N'JOSIMAR', N'sCec0GDyMcg=', 1, N'NAO')
INSERT [dbo].[tb_Usuarios] ([Id], [Nome], [Login], [Senha], [Id_Perfil], [Alterar_Senha]) VALUES (3, N'ADMIN', N'ADMIN', N'Ynq77LtUnKU=', 1, N'NAO')
SET IDENTITY_INSERT [dbo].[tb_Usuarios] OFF
/****** Object:  Table [dbo].[tb_Permissoes]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_Permissoes] ON
INSERT [dbo].[tb_Permissoes] ([Id], [Id_Perfil], [Descricao_Permissao], [Permissao]) VALUES (2, 1, N'ASSINAR_LOTE_RPS', N'SIM')
INSERT [dbo].[tb_Permissoes] ([Id], [Id_Perfil], [Descricao_Permissao], [Permissao]) VALUES (3, 1, N'ENVIAR_LOTE_RPS', N'SIM')
INSERT [dbo].[tb_Permissoes] ([Id], [Id_Perfil], [Descricao_Permissao], [Permissao]) VALUES (4, 1, N'VERIFICAR_STATUS_LOTE_RPS', N'SIM')
INSERT [dbo].[tb_Permissoes] ([Id], [Id_Perfil], [Descricao_Permissao], [Permissao]) VALUES (5, 1, N'IMPORTAR_MSG_RETORNO_LOTE_RPS', N'SIM')
INSERT [dbo].[tb_Permissoes] ([Id], [Id_Perfil], [Descricao_Permissao], [Permissao]) VALUES (6, 1, N'IMPORTAR_NFSE', N'SIM')
SET IDENTITY_INSERT [dbo].[tb_Permissoes] OFF
/****** Object:  Table [dbo].[tb_Parametros]    Script Date: 10/04/2012 01:54:38 ******/
SET IDENTITY_INSERT [dbo].[tb_Parametros] ON
INSERT [dbo].[tb_Parametros] ([Id], [TipoRps], [NumRps], [NaturezaOperacao], [RegimeEspTributacao], [OptanteSimples], [IncentivadorCultural], [ItemListaServico], [CodigoTributacao], [NumNota], [DiretorioLoteRps], [NumLote], [Serie], [CodigoMunicipio], [PIS], [COFINS], [CSLL], [AliquotaIRRF], [ValorLimiteImpostoIRRF], [AcumulaImposto], [AcumulaIRRF], [Ambiente], [ConverterPadraoAbrasf], [EmailRemetente], [AssuntoEmail], [MensagemEmail], [UtilizarNumNfseNoAssunto], [UtilizarEmailCliente], [EmailDestinatarioPadrao], [EnderecoSmtp], [PortaSmtp]) VALUES (7, 1, N'002', 1, 5, N'SIM', N'NAO', N'33.01', N'330100188', N'003', N'C:\Users\Josimar\Projetos\NFS-E\NetNfs-e\NetNfs-e\NetNfs-e\bin\Debug\NFS-e\Lote_Rps', N'001', N'UNICA', N'3106200', 0, 0, 0, 0, 0, N'NÃO', N'NÃO', N'HOMOLOGAÇÃO', N'SIM', N'josimar<josimar@netsystemas>', N'Nota fiscal:', N'Prezado cliente,

Em anexo NFS-e

Atenciosamente
Josimar Cordeiro da Silva
NetSystemas', N'SIM', N'NAO', N'josimarcsilva@gmail.com', N'mail.netsystemas.com.br', 25)
SET IDENTITY_INSERT [dbo].[tb_Parametros] OFF
