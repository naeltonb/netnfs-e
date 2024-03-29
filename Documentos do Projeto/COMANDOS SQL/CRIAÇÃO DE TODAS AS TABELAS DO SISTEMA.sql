USE [Bd]
GO
/****** Object:  Table [dbo].[tb_Nfse]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Nfse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Nfse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumRps] [varchar](30) NOT NULL,
	[NumNota] [varchar](30) NOT NULL,
	[DataEmissao] [smalldatetime] NULL,
	[NumLote] [varchar](30) NULL,
	[Serie] [varchar](20) NULL,
	[Competencia] [smalldatetime] NULL,
	[Tomador] [varchar](200) NULL,
	[Intermediario] [varchar](200) NULL,
	[OrgaoGerador] [varchar](10) NULL,
	[CodigoObra] [varchar](30) NULL,
	[CodigoVerificacao] [varchar](30) NULL,
	[ValorServico] [float] NULL,
	[EmailTomador] [varchar](100) NULL,
	[StatusEnvioEmail] [varchar](50) NULL,
 CONSTRAINT [PK_tb_Nfse] PRIMARY KEY CLUSTERED 
(
	[NumNota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_NaturezaOperacao]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_NaturezaOperacao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_NaturezaOperacao](
	[Id] [int] NOT NULL,
	[Descricao] [varchar](100) NULL,
 CONSTRAINT [PK_tb_NaturezaOperacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Municipio]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Municipio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Municipio](
	[CodigoMunicipio] [varchar](20) NOT NULL,
	[Municipio] [varchar](80) NULL,
 CONSTRAINT [PK_tb_Municipio] PRIMARY KEY CLUSTERED 
(
	[CodigoMunicipio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_MensagemLote]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_MensagemLote]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_MensagemLote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumLote] [int] NULL,
	[CodMensagem] [varchar](10) NULL,
	[Mensagem] [varchar](250) NULL,
 CONSTRAINT [PK_tb_MensagemLote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Lote]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Lote]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Lote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumLote] [int] NULL,
	[Status] [int] NULL,
	[Protocolo] [varchar](50) NULL,
	[DataEnvio] [varchar](20) NULL,
	[DataProtocolo] [varchar](20) NULL,
 CONSTRAINT [PK_tb_Lote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_ItemListaServico]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_ItemListaServico]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_ItemListaServico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoServico] [varchar](20) NOT NULL,
	[DescricaoServico] [varchar](max) NOT NULL,
 CONSTRAINT [PK_tb_ItemListaServico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_ConfigGridNfse]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_ConfigGridNfse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_ConfigGridNfse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome_Coluna] [varchar](100) NOT NULL,
	[Index_Coluna] [int] NOT NULL,
	[Coluna_Visivel] [varchar](3) NOT NULL,
	[Titulo_Coluna] [varchar](100) NULL,
 CONSTRAINT [PK_tb_ConfgGridNfse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_CadEmpresa]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_CadEmpresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_CadEmpresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RazaoSocial] [varchar](100) NULL,
	[NomeFantasia] [varchar](100) NULL,
	[CodigoCnae] [varchar](10) NULL,
	[Cnpj] [varchar](20) NULL,
	[InscricaoMunicipal] [varchar](20) NULL,
	[InscricaoEstadual] [varchar](20) NULL,
	[Logradouro] [varchar](100) NULL,
	[Numero] [varchar](10) NULL,
	[Complemento] [varchar](20) NULL,
	[Bairro] [varchar](50) NULL,
	[Cidade] [varchar](50) NULL,
	[Uf] [varchar](2) NULL,
	[Cep] [varchar](9) NULL,
	[Telefone] [varchar](20) NULL,
	[Email] [varchar](60) NULL,
	[Contato] [varchar](50) NULL,
 CONSTRAINT [PK_tb_CadEmpresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Perfil]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Perfil]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome_Perfil] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tb_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_TributacaoMunicipio]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_TributacaoMunicipio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_TributacaoMunicipio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Descricao] [varchar](max) NULL,
 CONSTRAINT [PK_tb_TributacaoMunicipio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_TipoRps]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_TipoRps]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_TipoRps](
	[Id] [int] NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_tb_TipoRps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Status]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_tb_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_RegimeEspTributacao]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_RegimeEspTributacao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_RegimeEspTributacao](
	[Id] [int] NOT NULL,
	[Descricao] [varchar](100) NULL,
 CONSTRAINT [PK_tb_RegimeEspTributacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Xml_Nfse]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Xml_Nfse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Xml_Nfse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumNota] [varchar](30) NOT NULL,
	[Xml] [xml] NULL,
 CONSTRAINT [PK_tb_Xml_Nfse] PRIMARY KEY CLUSTERED 
(
	[NumNota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Usuarios]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Id_Perfil] [int] NULL,
	[Alterar_Senha] [varchar](3) NULL,
 CONSTRAINT [PK_tb_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Permissoes]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Permissoes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Permissoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Perfil] [int] NOT NULL,
	[Descricao_Permissao] [varchar](50) NOT NULL,
	[Permissao] [varchar](3) NOT NULL,
 CONSTRAINT [PK_tb_Permissoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_Parametros]    Script Date: 10/04/2012 01:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Parametros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tb_Parametros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoRps] [int] NULL,
	[NumRps] [varchar](30) NULL,
	[NaturezaOperacao] [int] NULL,
	[RegimeEspTributacao] [int] NULL,
	[OptanteSimples] [varchar](3) NULL,
	[IncentivadorCultural] [varchar](3) NULL,
	[ItemListaServico] [varchar](10) NULL,
	[CodigoTributacao] [varchar](25) NULL,
	[NumNota] [varchar](30) NULL,
	[DiretorioLoteRps] [varchar](max) NULL,
	[NumLote] [varchar](30) NULL,
	[Serie] [varchar](20) NULL,
	[CodigoMunicipio] [varchar](20) NULL,
	[PIS] [float] NULL,
	[COFINS] [float] NULL,
	[CSLL] [float] NULL,
	[AliquotaIRRF] [float] NULL,
	[ValorLimiteImpostoIRRF] [float] NULL,
	[AcumulaImposto] [varchar](3) NULL,
	[AcumulaIRRF] [varchar](3) NULL,
	[Ambiente] [varchar](20) NULL,
	[ConverterPadraoAbrasf] [varchar](3) NULL,
	[EmailRemetente] [varchar](max) NULL,
	[AssuntoEmail] [varchar](max) NULL,
	[MensagemEmail] [varchar](max) NULL,
	[UtilizarNumNfseNoAssunto] [varchar](3) NULL,
	[UtilizarEmailCliente] [varchar](3) NULL,
	[EmailDestinatarioPadrao] [varchar](max) NULL,
	[EnderecoSmtp] [varchar](100) NULL,
	[PortaSmtp] [int] NULL,
 CONSTRAINT [PK_tb_Paramentros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_tb_Paramentros_tb_NaturezaOperacao]    Script Date: 10/04/2012 01:39:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Paramentros_tb_NaturezaOperacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros]  WITH CHECK ADD  CONSTRAINT [FK_tb_Paramentros_tb_NaturezaOperacao] FOREIGN KEY([NaturezaOperacao])
REFERENCES [dbo].[tb_NaturezaOperacao] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Paramentros_tb_NaturezaOperacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros] CHECK CONSTRAINT [FK_tb_Paramentros_tb_NaturezaOperacao]
GO
/****** Object:  ForeignKey [FK_tb_Paramentros_tb_RegimeEspTributacao]    Script Date: 10/04/2012 01:39:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Paramentros_tb_RegimeEspTributacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros]  WITH CHECK ADD  CONSTRAINT [FK_tb_Paramentros_tb_RegimeEspTributacao] FOREIGN KEY([RegimeEspTributacao])
REFERENCES [dbo].[tb_RegimeEspTributacao] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Paramentros_tb_RegimeEspTributacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros] CHECK CONSTRAINT [FK_tb_Paramentros_tb_RegimeEspTributacao]
GO
/****** Object:  ForeignKey [FK_tb_Paramentros_tb_TipoRps]    Script Date: 10/04/2012 01:39:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Paramentros_tb_TipoRps]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros]  WITH CHECK ADD  CONSTRAINT [FK_tb_Paramentros_tb_TipoRps] FOREIGN KEY([TipoRps])
REFERENCES [dbo].[tb_TipoRps] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Paramentros_tb_TipoRps]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros] CHECK CONSTRAINT [FK_tb_Paramentros_tb_TipoRps]
GO
/****** Object:  ForeignKey [FK_tb_Parametros_tb_Municipio]    Script Date: 10/04/2012 01:39:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Parametros_tb_Municipio]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros]  WITH CHECK ADD  CONSTRAINT [FK_tb_Parametros_tb_Municipio] FOREIGN KEY([CodigoMunicipio])
REFERENCES [dbo].[tb_Municipio] ([CodigoMunicipio])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Parametros_tb_Municipio]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Parametros]'))
ALTER TABLE [dbo].[tb_Parametros] CHECK CONSTRAINT [FK_tb_Parametros_tb_Municipio]
GO
/****** Object:  ForeignKey [FK_tb_Permissoes_tb_Perfil]    Script Date: 10/04/2012 01:39:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Permissoes_tb_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Permissoes]'))
ALTER TABLE [dbo].[tb_Permissoes]  WITH CHECK ADD  CONSTRAINT [FK_tb_Permissoes_tb_Perfil] FOREIGN KEY([Id_Perfil])
REFERENCES [dbo].[tb_Perfil] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Permissoes_tb_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Permissoes]'))
ALTER TABLE [dbo].[tb_Permissoes] CHECK CONSTRAINT [FK_tb_Permissoes_tb_Perfil]
GO
/****** Object:  ForeignKey [FK_tb_Usuarios_tb_Perfil]    Script Date: 10/04/2012 01:39:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Usuarios_tb_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Usuarios]'))
ALTER TABLE [dbo].[tb_Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_tb_Usuarios_tb_Perfil] FOREIGN KEY([Id_Perfil])
REFERENCES [dbo].[tb_Perfil] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Usuarios_tb_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Usuarios]'))
ALTER TABLE [dbo].[tb_Usuarios] CHECK CONSTRAINT [FK_tb_Usuarios_tb_Perfil]
GO
/****** Object:  ForeignKey [FK_tb_Xml_Nfse_tb_Nfse]    Script Date: 10/04/2012 01:39:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Xml_Nfse_tb_Nfse]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Xml_Nfse]'))
ALTER TABLE [dbo].[tb_Xml_Nfse]  WITH CHECK ADD  CONSTRAINT [FK_tb_Xml_Nfse_tb_Nfse] FOREIGN KEY([NumNota])
REFERENCES [dbo].[tb_Nfse] ([NumNota])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tb_Xml_Nfse_tb_Nfse]') AND parent_object_id = OBJECT_ID(N'[dbo].[tb_Xml_Nfse]'))
ALTER TABLE [dbo].[tb_Xml_Nfse] CHECK CONSTRAINT [FK_tb_Xml_Nfse_tb_Nfse]
GO
