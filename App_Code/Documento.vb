Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Text


Public Class Documento
    Private CI02_ID_DOCUMENTOS As Integer
    Private CI01_ID_ALUNO As Integer
    Private CI02_NM_MAE As String
    Private CI02_NU_CPF_MAE As String
    Private CI02_NM_PAI As String
    Private CI02_NU_CPF_PAI As String
    Private CI02_NU_TELEFONE_RESPONSAVEL As String
    Private CI02_NU_RG_ALUNO As String
    Private CI02_DT_EMISSAO_RG_ALUNO As String
    Private CI02_DT_NASCIMENTO_ALUNO As String
    Private CI02_TP_SEXO_ALUNO As Char
    Private CI02_DH_CADASTRO As String

    Public Property CodigoDoc() As Integer
        Get
            Return CI02_ID_DOCUMENTOS
        End Get
        Set(ByVal Value As Integer)
            CI02_ID_DOCUMENTOS = Value
        End Set
    End Property

    'Ultima feita
    Public Property CodigoAluno() As Integer
        Get
            Return CI01_ID_ALUNO
        End Get
        Set(ByVal Value As Integer)
            CI01_ID_ALUNO = Value
        End Set
    End Property

    Public Property NomeMae() As String
        Get
            Return CI02_NM_MAE
        End Get
        Set(ByVal Value As String)
            CI02_NM_MAE = Value
        End Set
    End Property

    Public Property CPFMae() As String
        Get
            Return CI02_NU_CPF_MAE
        End Get
        Set(ByVal Value As String)
            CI02_NU_CPF_MAE = Value
        End Set
    End Property
    Public Property NomePai() As String
        Get
            Return CI02_NM_PAI
        End Get
        Set(ByVal Value As String)
            CI02_NM_PAI = Value
        End Set
    End Property
    Public Property CPFPai() As String
        Get
            Return CI02_NU_CPF_PAI
        End Get
        Set(ByVal Value As String)
            CI02_NU_CPF_PAI = Value
        End Set
    End Property
    Public Property TelefoneResponsavel() As String
        Get
            Return CI02_NU_TELEFONE_RESPONSAVEL
        End Get
        Set(ByVal Value As String)
            CI02_NU_TELEFONE_RESPONSAVEL = Value
        End Set
    End Property
    Public Property RGAluno() As String
        Get
            Return CI02_NU_RG_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_NU_RG_ALUNO = Value
        End Set
    End Property
    Public Property DTEmissaoRGAluno() As String
        Get
            Return CI02_DT_EMISSAO_RG_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_DT_EMISSAO_RG_ALUNO = Value
        End Set
    End Property
    Public Property NascimentoAluno() As String
        Get
            Return CI02_DT_NASCIMENTO_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_DT_NASCIMENTO_ALUNO = Value
        End Set
    End Property
    Public Property SexoAluno() As Char
        Get
            Return CI02_TP_SEXO_ALUNO
        End Get
        Set(ByVal Value As Char)
            CI02_TP_SEXO_ALUNO = Value
        End Set
    End Property
    Public Property HoraCadastro() As String
        Get
            Return CI02_DH_CADASTRO
        End Get
        Set(value As String)
            CI02_DH_CADASTRO = value
        End Set
    End Property


    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & CodigoDoc)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("CI02_ID_DOCUMENTOS") = ProBanco(CI02_ID_DOCUMENTOS, eTipoValor.CHAVE)
        dr("CI01_ID_ALUNO") = ProBanco(CI01_ID_ALUNO, eTipoValor.CHAVE)
        dr("CI02_NM_MAE") = ProBanco(CI02_NM_MAE, eTipoValor.TEXTO)
        dr("CI02_NU_CPF_MAE") = ProBanco(CI02_NU_CPF_MAE, eTipoValor.TEXTO_LIVRE)
        dr("CI02_NM_PAI") = ProBanco(CI02_NM_PAI, eTipoValor.TEXTO)
        dr("CI02_NU_CPF_PAI") = ProBanco(CI02_NU_CPF_PAI, eTipoValor.TEXTO_LIVRE)
        dr("CI02_NU_TELEFONE_RESPONSAVEL") = ProBanco(CI02_NU_TELEFONE_RESPONSAVEL, eTipoValor.TEXTO_LIVRE)
        dr("CI02_NU_RG_ALUNO") = ProBanco(CI02_NU_RG_ALUNO, eTipoValor.TEXTO_LIVRE)
        dr("CI02_DT_EMISSAO_RG_ALUNO") = ProBanco(CI02_DT_EMISSAO_RG_ALUNO, eTipoValor.DATA)
        dr("CI02_DT_NASCIMENTO_ALUNO") = ProBanco(CI02_DT_NASCIMENTO_ALUNO, eTipoValor.DATA)
        dr("CI02_TP_SEXO_ALUNO") = ProBanco(CI02_TP_SEXO_ALUNO, eTipoValor.TEXTO_LIVRE)
        dr("CI02_DH_CADASTRO") = ProBanco(CI02_DH_CADASTRO, eTipoValor.DATA_COMPLETA)


        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Sub Obter(ByVal Codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            CI02_ID_DOCUMENTOS = ProBanco(CI02_ID_DOCUMENTOS, eTipoValor.CHAVE)
            CI01_ID_ALUNO = ProBanco(CI01_ID_ALUNO, eTipoValor.CHAVE)   'Ultima feita
            CI02_NM_MAE = ProBanco(CI02_NM_MAE, eTipoValor.TEXTO)
            CI02_NU_CPF_MAE = ProBanco(CI02_NU_CPF_MAE, eTipoValor.TEXTO_LIVRE)
            CI02_NM_PAI = ProBanco(CI02_NM_PAI, eTipoValor.TEXTO)
            CI02_NU_CPF_PAI = ProBanco(CI02_NU_CPF_PAI, eTipoValor.TEXTO_LIVRE)
            CI02_NU_TELEFONE_RESPONSAVEL = ProBanco(CI02_NU_TELEFONE_RESPONSAVEL, eTipoValor.TEXTO_LIVRE)
            CI02_NU_RG_ALUNO = ProBanco(CI02_NU_RG_ALUNO, eTipoValor.TEXTO_LIVRE)
            CI02_DT_EMISSAO_RG_ALUNO = ProBanco(CI02_DT_EMISSAO_RG_ALUNO, eTipoValor.DATA)
            CI02_DT_NASCIMENTO_ALUNO = ProBanco(CI02_DT_NASCIMENTO_ALUNO, eTipoValor.DATA)
            CI02_TP_SEXO_ALUNO = ProBanco(CI02_TP_SEXO_ALUNO, eTipoValor.TEXTO_LIVRE)
            CI02_DH_CADASTRO = ProBanco(CI02_DH_CADASTRO, eTipoValor.DATA_COMPLETA)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                          Optional ByVal CodigoDoc As Integer = 0,
                          Optional ByVal CodigoAluno As Integer = 0,
                          Optional ByVal NomeMae As String = "",
                          Optional ByVal CPFMae As String = "",
                          Optional ByVal NomePai As String = "",
                          Optional ByVal CPFPai As String = "",
                          Optional ByVal TelefoneResponsavel As String = "",
                          Optional ByVal RGAluno As String = "",
                          Optional ByVal DTEmissaoRGAluno As String = "",
                          Optional ByVal NascimentoAluno As String = "",
                          Optional ByVal SexoAluno As Char = "",
                          Optional ByVal HoraCadastro As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS Is Not null")

        If CodigoDoc > 0 Then
            strSQL.Append(" And CI02_ID_DOCUMENTOS = " & CodigoDoc)
        End If

        'Ultima feita
        If CodigoAluno > 0 Then
            strSQL.Append(" And CI01_ID_ALUNO = " & CodigoAluno)
        End If

        If NomeMae <> "" Then
            strSQL.Append(" And upper(CI02_NM_MAE) Like '%" & NomeMae.ToUpper & "%'")
        End If

        If NomePai <> "" Then
            strSQL.Append(" and upper(CI02_NM_PAI) like '%" & NomePai.ToUpper & "%'")
        End If

        If CPFMae <> "" Then
            strSQL.Append(" and upper(CI02_NU_CPF_MAE) like '%" & CPFMae.ToUpper & "%'")
        End If

        If CPFPai <> "" Then
            strSQL.Append(" and upper(CI02_NU_CPF_PAI) like '%" & CPFPai.ToUpper & "%'")
        End If

        If RGAluno <> "" Then
            strSQL.Append(" and upper(CI02_NU_RG_ALUNO) like '%" & RGAluno.ToUpper & "%'")
        End If

        If DTEmissaoRGAluno <> "" Then
            strSQL.Append(" and upper(CI02_DT_EMISSAO_RG_ALUNO) like '%" & DTEmissaoRGAluno.ToUpper & "%'")
        End If

        If NascimentoAluno <> "" Then
            strSQL.Append(" and upper(CI02_DT_NASCIMENTO_ALUNO) like '%" & NascimentoAluno.ToUpper & "%'")
        End If

        If SexoAluno <> "" Then
            strSQL.Append(" and upper(CI02_TP_SEXO_ALUNO) like '%" & SexoAluno & "%'")
        End If

        If HoraCadastro <> "" Then
            strSQL.Append(" and upper(CI02_DH_CADASTRO) like '%" & HoraCadastro.ToUpper & "%'")
        End If

        If TelefoneResponsavel <> "" Then
            strSQL.Append(" and upper(CI02_NU_TELEFONE_REPONSAVEL) like '%" & TelefoneResponsavel.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "CI02_ID_DOCUMENTOS", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    'FIZ AGORA
    Public Function ObterIdDoc(ByVal IdAluno As Integer) As Integer
        Dim cnn As New Conexao

        Dim dt As Integer
        Dim strSQL As New StringBuilder

        strSQL.Append(" select CI02_ID_DOCUMENTOS as CODIGO")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI01_ID_ALUNO = " & IdAluno)

        With cnn.AbrirDataTable(strSQL.ToString)
            If .Rows.Count > 0 Then
                dt = .Rows(0)(0)
            Else
                dt = 0
            End If
        End With

        cnn = Nothing

        Return dt
    End Function

    Public Function Excluir(ByVal Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class
