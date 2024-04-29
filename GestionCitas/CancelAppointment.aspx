<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelAppointment.aspx.cs" Inherits="GestionCitas.CancelAppointement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--------------------------------------  CANCELACIÓN DE CITA (EFECTIVA)  ----------------------------------------------------------------------%>

    <section class="information-section ptb-70">

        <header>
            <h2 class="information-section-title">CANCELAR CITA</h2>
        </header>

        <div class="section-information-content">

            <fieldset class="form-border">

                <legend class="form-legend"><span class="custom-legend">Información de la cita</span></legend>
                <div class="input-data-row">

                    <%-- COLUMNA DE HORARIO, SERVICIO Y MONTO A SEÑAR --%>
                    <div class="input-data-column">

                        <div class="input-data-column">

                            <asp:Label Text="Fecha reservada:" runat="server" for="date" CssClass="form-label" />
                            <asp:TextBox name="date" ID="AmountTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Horario:" runat="server" for="hour" CssClass="form-label" />
                            <asp:TextBox name="hour" ID="TextBoxHour" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Servicio:" runat="server" for="service" CssClass="form-label" />
                            <asp:TextBox name="service" ID="TextBoxService" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                        </div>

                    </div>

                </div>

            </fieldset>

            <%-- ********************************************** INFORMACIÓN ADICIONAL ********************************************** --%>

            <fieldset class="form-border">

                <legend class="form-legend"><span class="custom-legend">Información adicional</span></legend>
                <div class="input-data-row">

                    <%-- COLUMNA DE COMENTARIOS --%>
                    <div class="input-data-column">

                        <asp:Label Text="Comentario (opcional):" runat="server" for="comments" CssClass="form-label" />
                        <asp:TextBox name="comments" ID="TextBoxComments" runat="server" MaxLength="220" TextMode="MultiLine" CssClass="form-control not-resizing-control" Rows="10"></asp:TextBox>

                    </div>

                </div>

            </fieldset>

        </div>

        <div class="actions-container">

            <asp:Button Text="CANCELAR CITA" runat="server" CssClass="button btn-cancel" />
            <asp:Button Text="REGRESAR AL INICIO" runat="server" CssClass="button btn-back-to-inicio" />

        </div>

    </section>

</asp:Content>
