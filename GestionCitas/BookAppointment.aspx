<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="GestionCitas.BookAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--------------------------------------  GESTIÓN DE CITAS  ----------------------------------------------------------------------%>
    <section class="information-section ptb-70">

        <div class="section-information-content">

            <header>
                <h2 class="information-section-title">RESERVÁ TU CITA</h2>
            </header>

            <fieldset class="form-border">

                <%-- ********************************************** INFORMACION DEL CLIENTE ********************************************** --%>

                <legend class="form-legend"><span class="custom-legend">Información personal</span></legend>
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

            <fieldset class="form-border">

                <legend class="form-legend"><span class="custom-legend">Información de la cita</span></legend>
                <div class="input-data-row">

                    <%-- COLUMNA DE FECHA Y HORA DE LA CITA --%>
                    <div class="input-data-column">

                        <asp:Label Text="Fecha a reservar:" runat="server" for="date" CssClass="form-label" />
                        <asp:Calendar ID="Calendar" runat="server" CssClass="calendar" BorderColor="#2B3438" NextMonthText="&gt;" BorderWidth="2px" Font-Names="Work Sans" Font-Size="14pt" ForeColor="White" Height="200px" NextPrevFormat="FullMonth" Width="100%" >
                            <DayHeaderStyle Font-Bold="True" Font-Size="10pt" BackColor="#6E5C3D"/>
                            <NextPrevStyle Font-Bold="True" Font-Size="12pt" ForeColor="#333333" VerticalAlign="Bottom"/>
                            <OtherMonthDayStyle ForeColor="#999999" BackColor="#39454A"/>
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle Font-Bold="True" Font-Size="14pt" ForeColor="#333399" BackColor="#1E2427"/>
                            <TodayDayStyle BackColor="#BABABA" CssClass="today-day-style"/>
                        </asp:Calendar>

                    </div>

                    <div class="input-data-column">

                        <%-- COLUMNA DE HORARI, SERVICIO Y MONTO A SEÑAR --%>
                        <div class="input-data-column">

                            <asp:Label Text="Horario:" runat="server" for="hours" CssClass="form-label" />
                            <asp:DropDownList name="hours" ID="HoursDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Servicio:" runat="server" for="service" CssClass="form-label" />
                            <asp:DropDownList name="service" ID="ServicesDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Monto a señar:" runat="server" for="amount" CssClass="form-label" />
                            <asp:TextBox name="amount" ID="AmountTextBox" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>

                    </div>

                </div>

            </fieldset>


        </div>

        <asp:Button Text="RESERVAR" runat="server" CssClass="button btn-book"/>

    </section>

</asp:Content>
