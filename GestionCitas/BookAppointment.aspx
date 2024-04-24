<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="GestionCitas.BookAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--------------------------------------  GESTIÓN DE CITAS  ----------------------------------------------------------------------%>
    <section class="information-section">

        <div class="section-information-content">

            <header>
                <h2 class="information-section-title">GESTIONAR CITA</h2>
            </header>

            <h3>Reservá tu cita</h3>
            <%-- COLUMNA DE NOMBRE Y APELLIDO --%>
            <div class="input-data-row">
                <div class="input-data-column">

                    <asp:Label Text="Nombre:" runat="server" for="name" CssClass="form-label" />
                    <asp:TextBox name="name" ID="name" placeholder="Escriba su nombre aquí..." runat="server" CssClass="form-control" />

                </div>
                <div class="input-data-column">

                    <asp:Label Text="Apellido:" runat="server" for="surname" CssClass="form-label" />
                    <asp:TextBox name="surname" ID="surname" placeholder="Escriba su apellido aquí..." runat="server" CssClass="form-control" />

                </div>
            </div>

            <asp:Button Text="text" ID="pruebaBttn" OnClick="pruebaBttn_Click" runat="server" />

            <asp:Label Text="text" ID="prueba" runat="server" />
        </div>

    </section>
</asp:Content>
