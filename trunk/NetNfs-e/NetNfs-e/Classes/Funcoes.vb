Imports System.Xml
Imports System.IO
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates

Public Module Funcoes

    '/// Converte um String para objeto XmlDocument
    Friend Function StringToXmlDocument(ByVal strXML As String) As XmlDocument
        Dim XmlDoc As New XmlDocument
        XmlDoc.Load(New StringReader(strXML))
        Return XmlDoc
    End Function

    '/// Converte o conteúdo de um objeto XmlDocument para String
    Friend Function XmlDocumentToString(ByRef XmlDoc As XmlDocument) As String
        Dim sw As New StringWriter()
        Dim xtw As New XmlTextWriter(sw)
        XmlDoc.WriteTo(xtw)
        Return sw.ToString()
    End Function

    '// Centraliza os formulários
    Friend Sub CentralizarForm(ByVal frm As Form)
        frm.Left = ((frmPrincipal.Width - frm.Width) / 2) - 5
        frm.Top = ((frmPrincipal.Height - frm.Height) / 2) - 60
    End Sub

    '// Limpa os campos text e combobox e um grupo de GroupBox
    Friend Sub LimparCamposGroupBox(ByVal groupBox As GroupBox)
        For Each groupChild As GroupBox In groupBox.Controls
            groupChild.Controls(0).Text = ""
        Next

    End Sub

    '// Permite somente a digitação de números (inteiros ou fracionários) no campos passado como parâmentro
    Friend Sub SoNumeros(ByVal txt As TextBox)
        If txt.Text <> "" Then
            If Not IsNumeric(txt.Text) Then
                MsgBox("Este campo só aceita números!", vbExclamation, "Atenção")
                txt.Text = ""
                txt.Focus()
            Else
                txt.Text = txt.Text.Replace(".", ",")
                txt.SelectionStart = Len(txt.Text)
            End If
        End If
    End Sub

    '//Retira a formatação de uma determinada string
    Public Function removeFormatacao(ByVal texto As String) As String
        Dim txt As String = ""
        txt = texto.Replace(".", "")
        txt = txt.Replace("-", "")
        txt = txt.Replace("/", "")
        txt = txt.Replace("(", "")
        txt = txt.Replace(")", "")
        txt = txt.Replace(" ", "")

        Return Trim(txt)
    End Function

    '// Analise o preenchimento de campos obrigatórios de um grupo de GoupBox
    Friend Function VerificarPreenchimentoObrigatorio(ByVal groupBox As GroupBox) As Boolean
        Dim i As Integer = groupBox.Controls.Count - 1
        Do While i >= 0
            Dim groupChild As GroupBox = groupBox.Controls(i)
            If groupChild.Controls(0).Tag = "SIM" And Trim(removeFormatacao(groupChild.Controls(0).Text)) = "" Then
                MsgBox("O campo " & groupChild.Text & " é de preechimento obrigatório!", vbExclamation, "Atenção")
                groupChild.Controls(0).Focus()
                Return False
            End If
            i = i - 1
        Loop
        Return True
    End Function

    '// Atribui valores as variàveis globais utilizadas como parâmetros do sistema
    Public Sub CarregarParametrosSistema()

        Dim conBd As New ConexaoBd

        'CONSULTA NA TABELA PARÂMETROS
        Dim Sql As String = "Select * from tb_Parametros"
        Dim dt As DataTable = conBd.Consultar(Sql, "tb_Parametros")
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            strDiretorioNFSe = dr("DiretorioLoteRps")
            If dr("Ambiente") = "PRODUÇÃO" Then
                AmbienteWebService = Ambiente.Producao
            Else
                AmbienteWebService = Ambiente.Teste
            End If

            Select Case dr("CodigoMunicipio")
                Case "3106200" 'BELO HORIZONTE
                    MunicipioEmissao = MunicipioDeEmissao.BeloHorizonte
                Case "3118601" 'CONTAGEM
                    MunicipioEmissao = MunicipioDeEmissao.Contagem
                Case "3154606" 'RIBEIRÃO DAS NEVES
                    MunicipioEmissao = MunicipioDeEmissao.RibeiraoDasNeves
                Case Else
                    MunicipioEmissao = Nothing
            End Select

            UtilizarConversorAbrasf = dr("ConverterPadraoAbrasf")


            'CONSULTA NA TABELA DE CADASTRO DA EMPRESA
            Sql = "Select Cnpj,InscricaoMunicipal from tb_CadEmpresa"
            Dim dt1 As DataTable = conBd.Consultar(Sql, "tb_CadEmpresa")
            If dt1.Rows.Count > 0 Then
                Dim dr1 As DataRow = dt1.Rows(0)
                CnpjDoEmitente = removeFormatacao(dr1("Cnpj"))
                InscricaoMunicipalDoEmitente = removeFormatacao(dr1("InscricaoMunicipal"))
                ParametrosCarregados = True
            Else 'Identifca que o cadastro da empresa não foi cadastrado
                strMsgParametros = "Você deve efeturar a cadastro da empresa antes de utilizar essa opção do sistema!"
            End If

        Else 'Identifica que não foi configurado os parâmentros do sistema
            strMsgParametros = "Você deve configurar os parâmentros do sistema antes de utilizar essa opção!"
        End If
    End Sub

    '// Valida data em campo MaskedTextBox
    Friend Sub ValidarData(ByVal MaskedBox As MaskedTextBox)
        If MaskedBox.Text <> "  /  /" Then
            If Not IsDate(MaskedBox.Text) Then
                MsgBox("Data inválida!", vbExclamation, "Atenção")
                MaskedBox.Text = ""
                MaskedBox.Focus()
            End If
        End If
    End Sub

    '// Deleta arquivos de um determinado diretório
    Friend Sub DeletarArquivos(ByVal Diretorio As String)
        'Apaga os arquivos da pasta Temp
        Dim _diretorio As New DirectoryInfo(Diretorio)
        Dim arquivos() As FileInfo = _diretorio.GetFiles
        For Each _arquivo As FileInfo In arquivos
            _arquivo.Delete()
        Next
    End Sub

End Module

Public Module RetornoMsg
    Public MsgRetorno As String = ""
    Public TituloMsg As String = ""
    Public StyleMsgBox As New MsgBoxStyle
    Public Situacao As Byte = 0
End Module

Friend Module ParametrosSistema

    'Identifica se os parâmetros necessário foram carregados
    Public ParametrosCarregados As Boolean = False

    'Parâmetros do sistema
    Public AmbienteWebService As Ambiente = Ambiente.Teste
    Public strDiretorioNFSe As String = ""
    Public MunicipioEmissao As MunicipioDeEmissao
    Public CnpjDoEmitente As String
    Public InscricaoMunicipalDoEmitente As String
    Public UtilizarConversorAbrasf As String

    'Mensagem de retorno para usuário caso os parâmetros e o cadastro
    'do cliente não estejam configurados
    Public strMsgParametros As String

    'Verifica se o formulário de consulta de Nfs-e está em processo de envio de e-mail 
    'Caso esteja não deixa o usuário iniciar uma nova instância do formulário nem sai do sistema
    Public ProcessoEnvioEmailAtivo As Boolean = False


End Module

Public Enum MunicipioDeEmissao
    BeloHorizonte
    Contagem
    Betim
    RibeiraoDasNeves
End Enum

Public Enum Ambiente
    Teste
    Producao
End Enum

Public Enum ServicoWebService
    EnviarLote
    ConsultarSitLote
End Enum

Public Structure Impostos
    Dim PIS As String
    Dim COFINS As String
    Dim CSLL As String
    Dim AliquotaIRRF As String
    Dim AliquotaISS As String
    Dim ValorLimiteIRRF As String
End Structure

'// Modulo de funções que faz a validação do CPF ou do CNPJ (Retorno True ou False)
Friend Module ValidaCpfCnpj
    Private dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", _
                                              "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
    Private bValida As Boolean
    Private sCPF As String


    '////CPF////
    Public Function ValidarCpf(ByVal sCPF As String) As Boolean
        bValida = ValidaCPF(removeFormatacao(sCPF))
        Return bValida
    End Function

    Private Function ValidaCPF(ByVal CPF As String) As Boolean

        Dim i, x, n1, n2 As Integer

        CPF = CPF.Trim
        For i = 0 To dadosArray.Length - 1
            If CPF.Length <> 11 Or dadosArray(i).Equals(CPF) Then
                Return False
            End If
        Next
        'remove a maskara
        'CPF = CPF.Substring(0, 3) + CPF.Substring(4, 3) + CPF.Substring(8, 3) + CPF.Substring(12)
        For x = 0 To 1
            n1 = 0
            For i = 0 To 8 + x
                n1 = n1 + Val(CPF.Substring(i, 1)) * (10 + x - i)
            Next
            n2 = 11 - (n1 - (Int(n1 / 11) * 11))
            If n2 = 10 Or n2 = 11 Then n2 = 0

            If n2 <> Val(CPF.Substring(9 + x, 1)) Then
                Return False
            End If
        Next

        If CPF = "00000000000" Then
            Return False
        End If

        Return True
    End Function



    '////CNPJ////
    Public Function ValidarCnpj(ByVal sCNPJ As String) As Boolean
        bValida = ValidaCNPJ(removeFormatacao(sCNPJ))
        Return bValida
    End Function

    Private Function ValidaCNPJ(ByVal CNPJ As String) As Boolean

        Dim i As Integer
        Dim valida As Boolean
        CNPJ = CNPJ.Trim

        For i = 0 To dadosArray.Length - 1
            If CNPJ.Length <> 14 Or dadosArray(i).Equals(CNPJ) Then
                Return False
            End If
        Next

        If CNPJ.ToString = "00000000000000" Then
            Return False
        End If


        'remove a maskara
        'CNPJ = CNPJ.Substring(0, 2) + CNPJ.Substring(3, 3) + CNPJ.Substring(7, 3) + CNPJ.Substring(11, 4) + CNPJ.Substring(16)
        valida = efetivaValidacao(CNPJ)

        If valida Then
            ValidaCNPJ = True
        Else
            ValidaCNPJ = False
        End If

    End Function

    Private Function efetivaValidacao(ByVal cnpj As String)
        Dim Numero(13) As Integer
        Dim soma As Integer
        Dim i As Integer
        Dim resultado1 As Integer
        Dim resultado2 As Integer
        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(cnpj.Substring(i, 1))
        Next
        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 + _
                   Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2
        soma = soma - (11 * (Int(soma / 11)))
        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            resultado1 = 11 - soma
        End If

        If resultado1 = Numero(12) Then
            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + _
                         Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2
            soma = soma - (11 * (Int(soma / 11)))
            If soma = 0 Or soma = 1 Then
                resultado2 = 0
            Else
                resultado2 = 11 - soma
            End If
            If resultado2 = Numero(13) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

End Module
