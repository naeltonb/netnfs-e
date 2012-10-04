Imports System.Data.SqlClient
Public Class ConexaoBd

#Region "Variáveis"
    Private strConexao As String
    Public ConnBd As SqlConnection
    Private sqlComando As SqlCommand
    Private da As SqlDataAdapter
    Private ds As DataSet
    Private dt As DataTable
#End Region

#Region "Construtor"
    Public Sub New()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
        strConexao = configurationAppSettings.GetValue("ConexaoBanco", GetType(System.String))
        'strConexao = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Josimar\Projetos\NFS-E\NetNfs-e\NetNfs-e\NetNfs-e\Bd\Bd.mdf;Integrated Security=True;User Instance=True"

        ConectarBd()
    End Sub
#End Region

#Region "Métodos privados"

    Private Sub ConectarBd()
        ConnBd = New SqlConnection(strConexao)
        ConnBd.Open()
    End Sub

    Private Sub DesconetarBd()
        ConnBd.Close()
    End Sub

#End Region

#Region "Métodos públicos"

    Friend Function Consultar(ByVal sql As String, ByVal entidade As String) As DataTable
        da = New SqlDataAdapter(sql, ConnBd.ConnectionString)
        ds = New DataSet
        da.Fill(ds, entidade)
        dt = ds.Tables(entidade)
        Return dt
    End Function


    Friend Function ExecutarSqlTransacao(ByVal sql As String, ByVal transaction As SqlTransaction) As Integer
        Dim reg As Integer
        sqlComando = New SqlCommand(sql, ConnBd, transaction)

        da = New SqlDataAdapter
        da.InsertCommand = sqlComando
        reg = sqlComando.ExecuteNonQuery()

        Return reg
    End Function

    Friend Function ExecutarSql(ByVal sql As String) As Integer
        Dim reg As Integer
        sqlComando = New SqlCommand(sql, ConnBd)

        da = New SqlDataAdapter
        da.InsertCommand = sqlComando
        reg = sqlComando.ExecuteNonQuery()

        Return reg
    End Function

    Friend Function ExecutarSqlNfse(ByVal sql As String, ByVal transaction As SqlTransaction, ByVal DataEmissao As DateTime, ByVal Competencia As DateTime) As Integer
        Dim reg As Integer
        sqlComando = New SqlCommand(sql, ConnBd, transaction)
        da = New SqlDataAdapter
        da.InsertCommand = sqlComando

        Dim _dataEmissao As New SqlParameter("@DataEmissao", SqlDbType.DateTime)
        _dataEmissao.Value = DataEmissao
        sqlComando.Parameters.Add(_dataEmissao)

        Dim _Competencia As New SqlParameter("@Competencia", SqlDbType.SmallDateTime)
        _Competencia.Value = Competencia
        sqlComando.Parameters.Add(_Competencia)

        reg = sqlComando.ExecuteNonQuery()

        Return reg
    End Function

    Friend Function ExecutarSqlParametros(ByVal sql As String, ByVal impostos As Impostos) As Integer
        Dim reg As Integer
        sqlComando = New SqlCommand(sql, ConnBd)
        da = New SqlDataAdapter
        da.InsertCommand = sqlComando

        Dim _PIS As New SqlParameter("@PIS", SqlDbType.Float)
        _PIS.Value = impostos.PIS
        sqlComando.Parameters.Add(_PIS)

        Dim _COFINS As New SqlParameter("@COFINS", SqlDbType.Float)
        _COFINS.Value = impostos.COFINS
        sqlComando.Parameters.Add(_COFINS)

        Dim _CSLL As New SqlParameter("@CSLL", SqlDbType.Float)
        _CSLL.Value = impostos.CSLL
        sqlComando.Parameters.Add(_CSLL)

        Dim _AliquotaIRRF As New SqlParameter("@AliquotaIRRF", SqlDbType.Float)
        _AliquotaIRRF.Value = impostos.AliquotaIRRF
        sqlComando.Parameters.Add(_AliquotaIRRF)

        Dim _AliquotaISS As New SqlParameter("@AliquotaISS", SqlDbType.Float)
        _AliquotaISS.Value = impostos.AliquotaISS
        sqlComando.Parameters.Add(_AliquotaISS)

        Dim _ValorLimiteImpostoIRRF As New SqlParameter("@ValorLimiteImpostoIRRF", SqlDbType.Float)
        _ValorLimiteImpostoIRRF.Value = impostos.ValorLimiteIRRF
        sqlComando.Parameters.Add(_ValorLimiteImpostoIRRF)

        reg = sqlComando.ExecuteNonQuery()

        Return reg
    End Function

#End Region

End Class
