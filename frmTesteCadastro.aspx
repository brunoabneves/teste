<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmTesteCadastro.aspx.vb" Inherits="frmTesteCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">

    </section>
    <section class="content">
        <h4 class="page-header">Teste Cadastro</h4>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-8">
                        <div class="form-group">
                            <label for="Aluno">Aluno:</label>
                            <asp:DropDownList runat="server" required="required" id="DropDLAluno" class="form-control" name="Aluno" placeholder="Selecione o aluno"/>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label for="Nascimento">Nascimento:</label>
                            <asp:TextBox runat="server" required="required" type="date" class="form-control" id="txtNascimento" name="Nascimento" Height="34px"/>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label for="Sexo">Sexo:</label>
                            <asp:DropDownList runat="server" required="required" id="DropDLSexo" class="form-control" name="Sexo">
                                <asp:ListItem value="">Selecione</asp:ListItem>
                                <asp:ListItem value="M">M</asp:ListItem>
                                <asp:ListItem value="F">F</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="RG">RG:</label>
                            <asp:TextBox runat="server" type="text" class="form-control" id="txtRG" name="RG" placeholder="Ex.: 0123421456734" maxlength="13"/>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="DataEmissao">Data de Emissao:</label>
                            <asp:TextBox runat="server" type="date" class="form-control" id="txtDTEmissao" name="DataEmissao" Height="35px"/>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="TelefoneResponsavel">Telefone do Responsável:</label>
                                <asp:TextBox runat="server" type="tel" class="form-control" id="txtTelefoneResp" name="TelefoneResp" placeholder="Ex.: (11) 2020-3030" maxlength="15"/>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Mae">Mãe:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtNomeMae" name="NomeMae" maxlength="250" placeholder="Ex.: Maria Clara"/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="CPFMae">CPF:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtCPFMae" name="CPFMae" placeholder="Ex.: 010.011.111-00" maxlength="14"/>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Pai">Pai:</label>
                            <asp:TextBox runat="server" type="text" class="form-control" id="txtNomePai" name="NomePai" placeholder="Ex.: João da Silva" maxlength="250"/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="CPFPai">CPF:</label>
                            <asp:TextBox runat="server" type="text" class="form-control" id="txtCPFPai" name="CPFPai" placeholder="Ex.: 010.011.111-00" maxlength="14"/>
                        </div>
                    </div>
                </div>
                
        </div>
        <div class="box-footer">
            <div class="col-md-6">
                <asp:Button class="btn btn-primary" runat="server" ID="btnSalvar" Text="Salvar" />
            </div>
        </div>
    </section>
</asp:Content>
