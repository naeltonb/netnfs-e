Imports System.Security.Cryptography.Xml
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Object
Imports System.IO
Imports System.Net
Imports System.IO.FileStream
Imports System.Windows.Forms
Imports System.Text


Public Class CertificadoDigital

#Region "Funções Públicas"

    '//BUSCA CERTIFICADOS INSTALADOS SE INFORMADO UMA SERIE BUSCA A MESMA
    '//SE NÃO ABRE CAIXA DE DIALOGOS DE CERTIFICADO
    Public Function SelecionarCertificado(ByVal CerSerie As String) As X509Certificate2

        Dim certificate As New X509Certificate2
        Try
            Dim certificatesSel As X509Certificate2Collection
            Dim store As New X509Store("MY", StoreLocation.CurrentUser)
            store.Open(OpenFlags.OpenExistingOnly)
            Dim certificates As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, True).Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, True)
            If (CerSerie = "") Then
                certificatesSel = X509Certificate2UI.SelectFromCollection(certificates, "Certificados Digitais", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection)
                If (certificatesSel.Count = 0) Then
                    certificate.Reset()
                    Throw New Exception("Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas.")
                Else
                    certificate = certificatesSel.Item(0)
                End If
            Else
                certificatesSel = certificates.Find(X509FindType.FindBySerialNumber, CerSerie, True)
                If (certificatesSel.Count = 0) Then
                    certificate.Reset()
                    Throw New Exception("Certificado digital não encontrado")
                Else
                    certificate = certificatesSel.Item(0)
                End If
            End If
            store.Close()
            Return certificate
        Catch exception As Exception
            Throw New Exception(exception.Message)
            Return certificate
        End Try
    End Function

    '//Função publica que remove assina do arquivo
    Public Function RemoverAssinaturas(ByVal conteudoXML As String) As String
        Try
            Dim XmlDoc As XmlDocument = StringToXmlDocument(conteudoXML) '// converte string para XmlDocument
            RemoverAssinaturasXml(XmlDoc) '// remove assinaturas do documento
            Dim ConteudoXmlSemAssinatura As String = XmlDocumentToString(XmlDoc) '// converte XmlDocument para string
            Return ConteudoXmlSemAssinatura '// retorna string com XML sem assinaturas
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return Nothing
        End Try
    End Function

    '//Função publica que assina o arquivo com certificado digital
    Public Function AssinarXml(ByVal conteudoXML As String, ByVal _certificado As X509Certificate2, ByVal tag As String) As String
        Try
            Dim XMLDoc As XmlDocument = StringToXmlDocument(conteudoXML) '// converte string para XmlDocument
            Assinar(XMLDoc, _certificado, tag) '// assina no Xml os elementos com a tag informada
            Dim ConteudoXmlAssinado As String = XmlDocumentToString(XMLDoc) '// converte XmlDocument para string
            Return ConteudoXmlAssinado '// retorna string com XML assinado
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return Nothing
        End Try
    End Function

    '///Função que valida o XML do lote com Schema XSD
    Public Function ValidarXML(ByVal docXml As XmlDocument, ByVal Municipio As MunicipioDeEmissao, ByVal Servico As ServicoWebService) As Boolean
        Try
            ValidarXML = False
            Dim xmlLoteSaida As Stream
            xmlLoteSaida = New MemoryStream()

            docXml.Save(xmlLoteSaida)
            xmlLoteSaida.Flush()
            xmlLoteSaida.Position = 0

            Dim settings As New XmlReaderSettings
            Dim _nameSpace As String = WsUrls.UrlNameSpace(Municipio)

            Dim _Xsd As ListaUrl = WsUrls.UrlXsd(Municipio, Servico)

            settings.Schemas.Add(_nameSpace, _Xsd.UrlEnvLoteRps)

            Dim resolver = New XmlUrlResolver()
            resolver.Credentials = CredentialCache.DefaultCredentials
            settings.XmlResolver = resolver
            settings.ValidationType = ValidationType.Schema

            Dim reader As XmlReader = XmlReader.Create(xmlLoteSaida, settings)
            Dim xmlDoc As XmlDocument = New XmlDocument

            xmlDoc.Load(reader)
            Return True

        Catch ex As Exception
            Throw New Exception("Erro ao validar o .xml gerado com seu respectivo xsd" & Chr(13) & ex.Message & Chr(13) & "Versão do sistema: " & Application.ProductVersion & Chr(13) & "Acesse www.netsystemas.com.br e verifique a última versão disponível")
            Return False
        End Try

    End Function

#End Region


#Region "Funções Privadas"

    '//Função privada que remove assina do arquivo
    Private Sub RemoverAssinaturasXml(ByVal doc As XmlDocument)
        Dim listaAssinaturas As XmlNodeList = doc.GetElementsByTagName("Signature")
        Do While (listaAssinaturas.Count > 0)
            listaAssinaturas(0).ParentNode.RemoveChild(listaAssinaturas(0))
        Loop
    End Sub


    '//Função privada que assina o arquivo com certificado digital
    Private Sub Assinar(ByVal doc As XmlDocument, ByVal certificado As X509Certificate2, ByVal tag As String)

        Dim listaTagsAssinar As XmlNodeList = doc.GetElementsByTagName(tag)
        Dim signedXml As SignedXml

        '// Faz um loop procurando a Tag informada
        For Each infNFe As XmlElement In listaTagsAssinar
            '// obtem o valor da propriedade "Id" da tag que será assinada
            Dim id As String = ""
            If (infNFe.HasAttribute("id")) Then
                id = infNFe.Attributes.GetNamedItem("id").Value
            ElseIf (infNFe.HasAttribute("Id")) Then
                id = infNFe.Attributes.GetNamedItem("Id").Value
            ElseIf (infNFe.HasAttribute("ID")) Then
                id = infNFe.Attributes.GetNamedItem("ID").Value
            ElseIf (infNFe.HasAttribute("iD")) Then
                id = infNFe.Attributes.GetNamedItem("iD").Value
            Else
                Throw New Exception("Tag " + tag + " não tem atributo Id")
            End If

            signedXml = New SignedXml(infNFe)
            signedXml.SigningKey = certificado.PrivateKey

            '// Transformações p/ DigestValue da Nota
            Dim reference As New Reference("#" + id)
            reference.AddTransform(New XmlDsigEnvelopedSignatureTransform())

            signedXml.SignedInfo.CanonicalizationMethod += "#WithComments"

            '//reference.AddTransform(new XmlDsigC14NTransform());
            signedXml.AddReference(reference)

            Dim keyInfo As New KeyInfo()
            keyInfo.AddClause(New KeyInfoX509Data(certificado))
            signedXml.KeyInfo = keyInfo

            '// gerar o valor da assinatura
            signedXml.ComputeSignature()

            '// criar elemento <Signature>
            Dim xmlSignature As XmlElement = doc.CreateElement("Signature", "http://www.w3.org/2000/09/xmldsig#")

            '// criar Id da tag <Signature>
            Dim idAssinatura As XmlAttribute = doc.CreateAttribute("Id")
            idAssinatura.Value = "Ass_" + id.Replace(":", "_")
            xmlSignature.Attributes.InsertAfter(idAssinatura, xmlSignature.GetAttributeNode("xmlns"))

            '// gerar elemento <SignedInfo>
            Dim xmlSignedInfo As XmlElement = signedXml.SignedInfo.GetXml()

            '// gerar elemento <KeyInfo>
            Dim xmlKeyInfo As XmlElement = signedXml.KeyInfo.GetXml()

            '// compor nó <SignatureValue>
            Dim xmlSignatureValue As XmlElement = doc.CreateElement("SignatureValue", xmlSignature.NamespaceURI)
            Dim signBase64 As String = Convert.ToBase64String(signedXml.Signature.SignatureValue)
            Dim Text As XmlText = doc.CreateTextNode(signBase64)
            xmlSignatureValue.AppendChild(Text)

            '// incluir nós filhos da assinatura
            xmlSignature.AppendChild(doc.ImportNode(xmlSignedInfo, True))
            xmlSignature.AppendChild(xmlSignatureValue)
            xmlSignature.AppendChild(doc.ImportNode(xmlKeyInfo, True))

            '// incluir assinatura no documento
            infNFe.ParentNode.AppendChild(xmlSignature)

        Next
    End Sub


    '/// Serializar documento xml (Não esta sendo utilizada 07/08/2012)
    Private Function SerializarXml(ByVal documento As XmlDocument) As XmlDocument

        Dim oType As Type = documento.GetType 'oData e o obejto que representa o XML, o mesmo criado com o comando XSD.exe

        Dim Serializer = New Serialization.XmlSerializer(oType)

        Dim sb As New StringBuilder

        Dim SchemaXsd As New Schema.XmlSchemaSet()
        SchemaXsd.Add("http://www.abrasf.org.br/nfse.xsd", "C:\Users\Josimar\ValidaXML\nfse.xsd")
        SchemaXsd.Compile()

        Dim ConfigXmlWrite As New XmlWriterSettings
        ConfigXmlWrite.Encoding = System.Text.Encoding.UTF8
        Dim ns As New Xml.Serialization.XmlSerializerNamespaces
        ns = CType(SchemaXsd.Schemas()(0), Schema.XmlSchema).Namespaces

        Serializer.Serialize(XmlWriter.Create(sb, ConfigXmlWrite), documento, ns)

        Dim docSerializado As New XmlDocument
        docSerializado.LoadXml(sb.ToString)
        Return docSerializado
    End Function

    '/// Converte um String para objeto XmlDocument
    Private Function StringToXmlDocument(ByVal strXML As String) As XmlDocument
        Dim XmlDoc As New XmlDocument
        XmlDoc.Load(New StringReader(strXML))
        Return XmlDoc
    End Function

    '/// Converte o conteúdo de um objeto XmlDocument para String
    Private Function XmlDocumentToString(ByRef XmlDoc As XmlDocument) As String
        Dim sw As New StringWriter()
        Dim xtw As New XmlTextWriter(sw)
        XmlDoc.WriteTo(xtw)
        Return sw.ToString()
    End Function

#End Region

End Class
