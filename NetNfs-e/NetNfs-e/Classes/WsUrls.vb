Module WsUrls
    'Endereço do webservice
    Friend Function UrlWebService(ByVal Municipio As MunicipioDeEmissao, ByVal Ambiente As Ambiente) As String
        Dim UrlWs As String = Nothing
        Select Case Municipio
            Case Is = MunicipioDeEmissao.BeloHorizonte
                If Ambiente = Global.xmlNFSe.Ambiente.Producao Then
                    UrlWs = "https://bhissdigital.pbh.gov.br/bhiss-ws/nfse?wsdl"
                Else
                    UrlWs = "https://bhisshomologa.pbh.gov.br/bhiss-ws/nfse?wsdl"
                End If

            Case Is = MunicipioDeEmissao.Contagem
                If Ambiente = Global.xmlNFSe.Ambiente.Producao Then
                    UrlWs = "http://nfse.contagem.mg.gov.br/NFSEWS/Services.svc?wsdl"
                Else
                    UrlWs = "http://teste.contagem.mg.gov.br/NFSEWSTESTE/Services.svc?wsdl"
                End If
            Case Is = MunicipioDeEmissao.RibeiraoDasNeves
                If Ambiente = Global.xmlNFSe.Ambiente.Producao Then
                    UrlWs = "https://producao.ginfes.com.br/ServiceGinfesImpl?wsdl"
                Else
                    UrlWs = "https://homologacao.ginfes.com.br/ServiceGinfesImpl?wsdl"
                End If
        End Select
        Return UrlWs
    End Function

    'NameSpaces
    Friend Function UrlNameSpace(ByVal Municipio As MunicipioDeEmissao) As String
        Dim _nameSpace As String = Nothing
        Select Case Municipio
            Case Is = MunicipioDeEmissao.BeloHorizonte
                _nameSpace = "http://www.abrasf.org.br/nfse.xsd"
            Case Is = MunicipioDeEmissao.Contagem
                _nameSpace = "http://tempuri.org/tipos_complexos.xsd"
            Case Is = MunicipioDeEmissao.RibeiraoDasNeves
                _nameSpace = "http://www.ginfes.com.br/tipos_v03.xsd"
        End Select
        Return _nameSpace
    End Function

    'URL do xds para validação do arquivo
    Friend Function UrlXsd(ByVal Municipio As MunicipioDeEmissao, ByVal Servico As ServicoWebService) As ListaUrl
        Dim _urlXsd As ListaUrl = Nothing
        Select Case Municipio
            Case Is = MunicipioDeEmissao.BeloHorizonte
                _urlXsd.UrlEnvLoteRps = My.Application.Info.DirectoryPath & "\Schemas\Belo_Horizonte\nfse.xsd"
            Case Is = MunicipioDeEmissao.Contagem
                _urlXsd.UrlEnvLoteRps = My.Application.Info.DirectoryPath & "\Schemas\Contagem\tipos_complexos.xsd"
            Case Is = MunicipioDeEmissao.RibeiraoDasNeves
                _urlXsd.UrlEnvLoteRps = My.Application.Info.DirectoryPath & "\Schemas\Ribeirao_das_Neves\tipos_v03.xsd"
        End Select
        Return _urlXsd
    End Function

    Friend Structure ListaUrl
        Dim UrlEnvLoteRps As String
        Dim UrlConSitLoteRps As String
    End Structure

End Module
