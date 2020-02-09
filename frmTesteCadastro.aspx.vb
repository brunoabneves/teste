Imports System.Data

Partial Class frmTesteCadastro
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objDocumento As New Documento
        Dim aluno As New Aluno

        If Not Page.IsPostBack Then
            CarregarList()
        End If
        Validacao.Outros(txtTelefoneResp, False, "CPF",, Validacao.eFormato.CELULAR)
        Validacao.Outros(txtCPFMae, False, "CPF",, Validacao.eFormato.CPF)
        Validacao.Outros(txtCPFPai, False, "CPF",, Validacao.eFormato.CPF)

        If objDocumento.ObterIdDoc(aluno.ObterIdAluno(DropDLAluno.SelectedValue)) > 0 Then
            objDocumento.CodigoDoc = objDocumento.ObterIdDoc(aluno.ObterIdAluno(DropDLAluno.SelectedValue))
            JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.ATUALIZAR)
        Else
            JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
        End If
    End Sub

#Region "Funções de Cadastro"
    Private Function VerificarCpf() As Boolean
        Dim objDocumento As New Aluno
        Dim Existe As Boolean = False

        With objDocumento.Pesquisar(,,, Replace(Replace(txtCPFMae.Text, ".", ""), "-", ""))
            If .Rows.Count > 0 Then
                MsgBox("CPF já Cadastrado", eCategoriaMensagem.ALERTA)
                Existe = True
            End If
        End With

        objDocumento = Nothing
        Return Existe
    End Function

    Private Function VerificarAluno() As Boolean
        Dim objDocumento As New Documento
        Dim aluno As New Aluno
        Dim Existe As Boolean = False

        With objDocumento.Pesquisar(,, aluno.ObterIdAluno(DropDLAluno.SelectedValue))
            If .Rows.Count > 0 Then
                MsgBox("Aluno já Cadastrado", eCategoriaMensagem.ALERTA)
                Existe = True
            End If
        End With

        objDocumento = Nothing
        Return Existe
    End Function

    Private Sub LimparCampos()

        txtNascimento.Text = ""
        txtRG.Text = ""
        txtDTEmissao.Text = ""
        txtTelefoneResp.Text = ""
        txtNomeMae.Text = ""
        txtCPFMae.Text = ""
        txtNomePai.Text = ""
        txtCPFPai.Text = ""

        DropDLSexo.ClearSelection()

        DropDLAluno.Focus()
    End Sub

    Private Sub Salvar()
        Dim objDocumento As New Documento(ViewState("CodigoDoc"))
        Dim aluno As New Aluno

        With objDocumento

            If objDocumento.ObterIdDoc(aluno.ObterIdAluno(DropDLAluno.SelectedValue)) > 0 Then
                .CodigoDoc = objDocumento.ObterIdDoc(aluno.ObterIdAluno(DropDLAluno.SelectedValue))
            End If
            .NomeMae = txtNomeMae.Text
            .CodigoAluno = aluno.ObterIdAluno(DropDLAluno.SelectedValue)
            If VerificarCpf() = True Then
                Exit Sub
            End If
            .CPFMae = Replace(Replace(txtCPFMae.Text, ".", ""), "-", "")
            .NomePai = txtNomePai.Text
            .CPFPai = Replace(Replace(txtCPFPai.Text, ".", ""), "-", "")
            .RGAluno = txtRG.Text
            .SexoAluno = DropDLSexo.SelectedValue
            .NascimentoAluno = txtNascimento.Text
            .DTEmissaoRGAluno = txtDTEmissao.Text
            .TelefoneResponsavel = txtTelefoneResp.Text
            .HoraCadastro = DateTime.Now.ToString

            .Salvar()
        End With
        objDocumento = Nothing
    End Sub

    Private Sub Excluir(ByVal CodigoAluno As Integer)
        Dim objAluno As New Aluno

        If objAluno.Excluir(CodigoAluno) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objAluno = Nothing

        LimparCampos()

    End Sub

    Private Sub Voltar()
        Response.Redirect(Request.Url.ToString)

        LimparCampos()
    End Sub

#End Region

#Region "Eventos de Cadastro"
    Protected Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

        Salvar()
        LimparCampos()

    End Sub

#End Region

#Region "Funções de Listagem"
    Private Sub CarregarList()
        Dim objAluno As New Aluno

        DropDLAluno.DataSource = objAluno.ObterTabela
        DropDLAluno.DataTextField = "DESCRICAO"
        DropDLAluno.DataBind()

        objAluno = Nothing

        'lblRegistros.Text = DirectCast(DropDLAluno.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub

#End Region

#Region "Eventos de Listagem"


#End Region
End Class
