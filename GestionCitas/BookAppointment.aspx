<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="GestionCitas.BookAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--------------------------------------  GESTIÓN DE CITAS  ----------------------------------------------------------------------%>
    <section class="information-section ptb-70">

        <div class="section-information-content">

            <header>
                <h2 class="information-section-title">GESTIONAR CITA</h2>
            </header>

            <h3>Reservá tu cita</h3>

            <fieldset>

                <%-- ********************************************** INFORMACION DEL CLIENTE ********************************************** --%>

                <legend>Información personal</legend>
                <div class="input-data-row">

                    <div class="input-data-column">

                        <%-- COLUMNA DE NOMBRE Y APELLIDO --%>
                        <asp:Label Text="Nombre:" runat="server" for="name" CssClass="form-label" />
                        <asp:TextBox name="name" ID="NameTextBox" placeholder="Escriba su nombre aquí..." runat="server" CssClass="form-control" required="true" />

                    </div>

                    <div class="input-data-column">

                        <asp:Label Text="Apellido:" runat="server" for="surname" CssClass="form-label" />
                        <asp:TextBox name="surname" ID="SurnameTextBox" placeholder="Escriba su apellido aquí..." runat="server" CssClass="form-control" required="true" />

                    </div>

                </div>

                <div class="input-data-row">

                    <div class="input-data-column">

                        <%-- COLUMNA DE EMAIL --%>
                        <asp:Label Text="Email:" runat="server" for="mail" CssClass="form-label" />
                        <asp:TextBox name="mail" ID="MailTextBox" placeholder="example@example.com" runat="server" CssClass="form-control" required="true" />

                    </div>

                </div>

            </fieldset>

            <%-- ********************************************** INFORMACION DE LA CITA ********************************************** --%>

            <fieldset>

                <legend>Información de la cita</legend>
                <div class="input-data-row">

                    <%-- COLUMNA DE FECHA Y HORA DE LA CITA --%>
                    <div class="input-data-column">

                        <asp:Label Text="Fecha a reservar:" runat="server" for="date" CssClass="form-label" />
                        <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>

                    </div>

                    <div class="input-data-column">

                        <asp:Label Text="Horario:" runat="server" for="hours" CssClass="form-label" />
                        <asp:DropDownList name="hours" ID="HoursDropDownList" runat="server"></asp:DropDownList>

                    </div>

                </div>

                <div class="input-data-row">

                    <%-- COLUMNA DE SERVICIO Y MONTO A SEÑAR --%>
                    <div class="input-data-column">

                        <asp:Label Text="Servicio:" runat="server" for="service" CssClass="form-label" />
                        <asp:DropDownList name="service" ID="ServicesDropDownList" runat="server"></asp:DropDownList>

                    </div>
                    
                    <div class="input-data-column">

                        <asp:Label Text="Monto a señar:" runat="server" for="amount" CssClass="form-label" />
                        <asp:TextBox name="amount" ID="AmountTextBox" runat="server"></asp:TextBox>

                    </div>

                </div>

            </fieldset>

        </div>

    </section>
</asp:Content>
