<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchAppointment.aspx.cs" Inherits="GestionCitas.CancelAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--------------------------------------  CANCELACIÓN DE CITA (BÚSQUEDA)  ----------------------------------------------------------------------%>

    <section class="information-section pt-90 pb-160">

        <div class="section-information-content">

            <header>
                <h2 class="information-section-title">BUSCÁ TU CITA</h2>
            </header>

            <%-- ********************************************** BÚSQUEDA DE CITA ********************************************** --%>

            <fieldset class="form-border">

                <legend class="form-legend"><span class="custom-legend">Búsqueda de cita:</span></legend>
                <div class="input-data-row">

                    <%-- COLUMNA DE NUMERO DE CITA --%>
                    <div class="input-data-column">

                        <asp:Label Text="Número de cita:" runat="server" for="idTurno" CssClass="form-label" />
                        <asp:TextBox name="idTurno" ID="TextBoxIdTurno" runat="server" CssClass="form-control" placeholder="Ej: 1111"></asp:TextBox>

                    </div>

                </div>

            </fieldset>

        </div>

        <asp:Button Text="BUSCAR" ID="btnSearch" runat="server" CssClass="button btn-search" OnClick="btnSearch_Click"/>

    </section>

</asp:Content>
