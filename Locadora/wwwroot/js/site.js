// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<form asp-action="Create" onsubmit="return validarDataNascimento()">
    <div asp-validation-summary="ModelOnly" class="text-danger mb-3"></div>
    <input type="hidden" asp-for="Id" />

    <!-- Nome -->
    <div class="form-group mb-3">
        <label asp-for="Name" class="control-label text-white"></label>
        <input asp-for="Name" class="form-control" placeholder="Digite o nome" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>

    <!-- Data de Nascimento -->
    <div class="form-group mb-3">
        <label asp-for="DataNascimento" class="control-label text-white"></label>
        <input asp-for="DataNascimento" class="form-control" placeholder="Digite a data de nascimento" />
        <span asp-validation-for="DataNascimento" class="text-danger"></span>
    </div>

    <!-- Nacionalidade -->
    <div class="form-group mb-3">
        <label asp-for="Nacionalidade" class="control-label text-white"></label>
        <input asp-for="Nacionalidade" class="form-control" placeholder="Digite a nacionalidade" />
        <span asp-validation-for="Nacionalidade" class="text-danger"></span>
    </div>

    <!-- Botões Salvar e Voltar -->
    <div class="d-flex justify-content-between mt-4">
        <!-- Botão Salvar -->
        <input type="submit" value="Salvar" class="btn btn-success btn-sm w-48" />

        <!-- Botão Voltar -->
        <a asp-action="Index" class="btn btn-secondary btn-sm w-48">Voltar para a Lista</a>
    </div>
</form>
