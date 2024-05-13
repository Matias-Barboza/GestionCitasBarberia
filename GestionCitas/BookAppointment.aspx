<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="GestionCitas.BookAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--------------------------------------  RESERVA DE CITA  ----------------------------------------------------------------------%>

    <section class="information-section ptb-90">

        <div class="section-information-content">

            <header>
                <h2 class="information-section-title">RESERVÁ TU CITA</h2>
            </header>

            <%-- ********************************************** INFORMACIÓN DEL CLIENTE ********************************************** --%>

            <fieldset class="form-border">


                <legend class="form-legend"><span class="custom-legend">Información personal</span></legend>
                <div class="input-data-row">

                    <%-- COLUMNA DE NOMBRE Y APELLIDO --%>
                    <div class="input-data-column">

                        <asp:Label Text="Nombre:" runat="server" for="name" CssClass="form-label" />
                        <asp:TextBox name="name" ID="NameTextBox" placeholder="Escriba su nombre aquí..." runat="server" CssClass="form-control" required="true" />

                    </div>

                    <div class="input-data-column">

                        <asp:Label Text="Apellido:" runat="server" for="surname" CssClass="form-label" />
                        <asp:TextBox name="surname" ID="SurnameTextBox" placeholder="Escriba su apellido aquí..." runat="server" CssClass="form-control" required="true" />

                    </div>

                </div>

                <div class="input-data-row">

                    <%-- COLUMNA DE EMAIL --%>
                    <div class="input-data-column">

                        <asp:Label Text="Email:" runat="server" for="mail" CssClass="form-label" />
                        <asp:TextBox name="mail" ID="EmailTextBox" placeholder="example@example.com" runat="server" CssClass="form-control" required="true" />

                    </div>

                </div>

                <div class="input-data-row">

                    <%-- COLUMNA DE TELEFONO --%>
                    <div class="input-data-column">

                        <asp:Label Text="Teléfono:" runat="server" for="cel" CssClass="form-label" />
                        <asp:TextBox name="cel" ID="TelTextBox" placeholder="Ej: +543624999999" runat="server" CssClass="form-control" required="true" />

                    </div>

                </div>

            </fieldset>

            <%-- ********************************************** INFORMACIÓN DE LA CITA ********************************************** --%>

            <fieldset class="form-border">

                <legend class="form-legend"><span class="custom-legend">Información de la cita</span></legend>
                <div class="input-data-row">

                    <%-- COLUMNA DE FECHA Y HORARIO --%>
                    <div class="input-data-column-wsp">

                        <div class="input-data-column">

                            <asp:Label Text="Fecha a reservar:" runat="server" for="date" CssClass="form-label" />
                            <asp:Calendar ID="Calendar" runat="server" CssClass="calendar" BorderColor="#2B3438" NextMonthText="&gt;" BorderWidth="2px" Font-Names="Work Sans" Font-Size="14pt" ForeColor="White" Height="200px"
                                NextPrevFormat="FullMonth" Width="100%" required="true" OnSelectionChanged="Calendar_SelectionChanged">
                                <DayHeaderStyle Font-Bold="True" Font-Size="10pt" BackColor="#6E5C3D" />
                                <NextPrevStyle Font-Bold="True" Font-Size="12pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" BackColor="#39454A" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle Font-Bold="True" Font-Size="14pt" ForeColor="#333399" BackColor="#1E2427" />
                                <TodayDayStyle BackColor="#BABABA" CssClass="today-day-style" />
                            </asp:Calendar>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Barbero:" runat="server" for="barber" CssClass="form-label" />
                            <asp:DropDownList name="barber" ID="BarbersDropDownList" runat="server" CssClass="form-control" required="true" AutoPostBack="true" 
                                OnSelectedIndexChanged="BarbersDropDownList_SelectedIndexChanged"></asp:DropDownList>

                        </div>

                    </div>

                    <%-- COLUMNA DE SERVICIO, BARBERO, TIEMPO ESTIMADO Y PRECIO FINAL --%>
                    <div class="input-data-column-wsp">

                        <div class="input-data-column">

                            <asp:Label Text="Horario:" runat="server" for="hours" CssClass="form-label" />
                            <asp:DropDownList name="hours" ID="HoursDropDownList" runat="server" CssClass="form-control" required="true" AutoPostBack="true"></asp:DropDownList>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Servicio:" runat="server" for="service" CssClass="form-label" />
                            <asp:DropDownList name="service" ID="ServicesDropDownList" runat="server" CssClass="form-control" required="true" AutoPostBack="true"
                                OnSelectedIndexChanged="ServicesDropDownList_SelectedIndexChanged"></asp:DropDownList>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Tiempo estimado:" runat="server" for="estimated-time" CssClass="form-label" />
                            <asp:TextBox name="estimated-time" ID="EstimatedTimeTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                        </div>

                        <div class="input-data-column">

                            <asp:Label Text="Precio final del servicio:" runat="server" for="amount" CssClass="form-label" />
                            <asp:TextBox name="amount" ID="AmountTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                        </div>

                    </div>

                </div>

                <div class="input-data-row">

                    <div class="input-data-column">

                        <asp:Label Text="Nota: Recuerde que unicamente trabajamos de martes a sábados." runat="server" CssClass="form-label-info" />

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

        <asp:Button Text="RESERVAR" ID="BookBtn" runat="server" CssClass="button btn-book" OnClick="BookBtn_Click" />

    </section>

</asp:Content>
