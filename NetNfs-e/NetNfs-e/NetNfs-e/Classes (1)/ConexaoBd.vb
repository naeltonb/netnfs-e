Imports System.Data.SqlClient
Public Class ConexaoBd
    Private strConexao As String
    Public ConnBd As SqlConnection
    Private sqlComando As SqlCommand
    Private da As SqlDataAdapter
    Private ds As DataSet
    Private dt As DataTable


    Public Sub New()
        strConexao = "Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Google Drive\NETSYSTEMAS\NetNfs-e\NetNfs-e\NetNfs-e\Bd\Bd.mdf;Integrated Security=True;User Instance=True"
        ConectarBd()
    End Sub

    Private Sub ConectarBd()
        ConnBd = New SqlConnection(strConexao)
    End Sub

    Private Sub DesconetarBd()
        ConnBd.Close()
    End Sub

    Public Function Consultar(ByVal sql As String, ByVal entidade As String) As DataTable
        da = New SqlDataAdapter(sql, ConnBd.ConnectionString)
        ds = New DataSet
        da.Fill(ds, entidade)
        dt = ds.Tables(entidade)
        'DesconetarBd()
        Return dt
    End Function

    Public Function ExecutarSql(ByVal sql As String) As Integer
        Dim reg As Integer
        sqlComando = New SqlCommand(sql, ConnBd)
        da = New SqlDataAdapter
        da.InsertCommand = sqlComando
        ConnBd.Open()

        reg = sqlComando.ExecuteNonQuery()

        ConnBd.Close()
        Return reg
    End Function

    Public Function ExecutarSqlNfse(ByVal sql As String, ByVal DataEmissao As DateTime, ByVal Competencia As DateTime) As Integer
        Dim reg As Integer
        sqlComando = New SqlCommand(sql, ConnBd)
        da = New SqlDataAdapter
        da.InsertCommand = sqlComando

        Dim _dataEmissao As New SqlParameter("@DataEmissao", SqlDbType.DateTime)
        _dataEmissao.Value = DataEmissao
        sqlComando.Parameters.Add(_dataEmissao)

        Dim _Competencia As New SqlParameter("@Competencia", SqlDbType.SmallDateTime)
        _Competencia.Value = Competencia
        sqlComando.Parameters.Add(_Competencia)

        ConnBd.Open()
        reg = sqlComando.ExecuteNonQuery()

        ConnBd.Close()
        Return reg
    End Function

    Public Function ExecutarSqlParametros(ByVal sql As String, ByVal impostos As Impostos) As Integer
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

        Dim _ValorLimiteImpostoIRRF As New SqlParameter("@ValorLimiteImpostoIRRF", SqlDbType.Float)
        _ValorLimiteImpostoIRRF.Value = impostos.ValorLimiteIRRF
        sqlComando.Parameters.Add(_ValorLimiteImpostoIRRF)

        ConnBd.Open()
        reg = sqlComando.ExecuteNonQuery()

        ConnBd.Close()
        Return reg
    End Function

End Class
