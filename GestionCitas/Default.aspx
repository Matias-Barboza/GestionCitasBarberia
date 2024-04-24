<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestionCitas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--------------------------------------  FOTO DE INICIO  ----------------------------------------------------------------------%>
    <section class="inicio">
        <div class="inicio-content">
            <h1 class="inicio-title">INK BARBERÍA</h1>
            <img class="img-inicio" src="/imgs/img_inicio_marca.png" alt="Alternate Text" />
        </div>
    </section>

    <%--------------------------------------  SOBRE NOSOTROS Y NUESTRO LUGAR  ------------------------------------------------------%>
    <section class="information-section">

        <div class="section-information-content">

            <article>

                <header>
                    <h2 class="information-section-title">SOBRE NOSOTROS</h2>
                </header>

                <p class="paragraph">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque in nunc convallis, ultricies nibh id, pharetra enim.
                Aenean eget auctor massa. Donec eleifend nisl sapien, ut vulputate ex pulvinar luctus. Suspendisse odio eros, convallis in augue ac,
                lobortis tristique ipsum. Nulla dictum fringilla aliquam. Sed eget malesuada tellus. Ut sed hendrerit ipsum. Nulla sagittis diam nec
                diam euismod, sit amet porttitor elit egestas. Pellentesque volutpat nisi nec quam feugiat egestas. Nulla ultrices auctor nisl.
                In finibus lectus enim, in blandit nisi tincidunt at. Quisque et quam malesuada, fringilla ligula vel, bibendum risus.
                </p>

            </article>

            <article>

                <header>
                    <h2 class="information-section-title">NUESTRO STAFF</h2>
                </header>

                <div class="barberos-content">

                    <div class="barbero-left-content">

                        <img class="img-barber" src="imgs/barber1.png" alt="Alternate Text" />
                        <h3 class="barber-name-title">Matias Aquino</h3>
                        <p class="paragraph">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque in nunc convallis, ultricies nibh id, pharetra enim.
                            Aenean eget auctor massa. Donec eleifend nisl sapien, ut vulputate ex pulvinar luctus. Suspendisse odio eros, convallis in augue ac,
                            lobortis tristique ipsum. Nulla dictum fringilla aliquam. Sed eget malesuada tellus. Ut sed hendrerit ipsum. Nulla sagittis diam nec
                            diam euismod, sit amet porttitor elit egestas. Pellentesque volutpat nisi nec quam feugiat egestas. Nulla ultrices auctor nisl.
                            In finibus lectus enim, in blandit nisi tincidunt at. Quisque et quam malesuada, fringilla ligula vel, bibendum risus.
                        </p>

                    </div>

                    <div class="barbero-right-content">

                        <img class="img-barber" src="imgs/barber2.png" alt="Alternate Text" />
                        <h3 class="barber-name-title">Alexis Reyes</h3>
                        <p class="paragraph">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque in nunc convallis, ultricies nibh id, pharetra enim.
                            Aenean eget auctor massa. Donec eleifend nisl sapien, ut vulputate ex pulvinar luctus. Suspendisse odio eros, convallis in augue ac,
                            lobortis tristique ipsum. Nulla dictum fringilla aliquam. Sed eget malesuada tellus. Ut sed hendrerit ipsum. Nulla sagittis diam nec
                            diam euismod, sit amet porttitor elit egestas. Pellentesque volutpat nisi nec quam feugiat egestas. Nulla ultrices auctor nisl.
                            In finibus lectus enim, in blandit nisi tincidunt at. Quisque et quam malesuada, fringilla ligula vel, bibendum risus.
                        </p>

                    </div>

                </div>

            </article>

        </div>

    </section>

    <section class="information-section">

        <div class="section-information-content">
            <header>
                <h2 class="information-section-title">NUESTRO LUGAR</h2>
            </header>

            <article>
                <p class="paragraph">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque in nunc convallis, ultricies nibh id, pharetra enim.
                Aenean eget auctor massa. Donec eleifend nisl sapien, ut vulputate ex pulvinar luctus. Suspendisse odio eros, convallis in augue ac,
                lobortis tristique ipsum. Nulla dictum fringilla aliquam. Sed eget malesuada tellus. Ut sed hendrerit ipsum. Nulla sagittis diam nec
                diam euismod, sit amet porttitor elit egestas. Pellentesque volutpat nisi nec quam feugiat egestas. Nulla ultrices auctor nisl.
                In finibus lectus enim, in blandit nisi tincidunt at. Quisque et quam malesuada, fringilla ligula vel, bibendum risus.
                </p>

                <div class="img-container">
                    <img class="img-local" src="/imgs/local.png" alt="Alternate Text" />
                </div>

            </article>
        </div>

    </section>

</asp:Content>
