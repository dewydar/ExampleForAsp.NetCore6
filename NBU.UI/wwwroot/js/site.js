// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var disableInputs = function () {

    $('#modal-trigger input').attr('disabled', true);
    $('#modal-trigger textarea').attr('disabled', true);
    $('#modal-trigger select').attr('disabled', true);
}
var EmptyInputs = function () {
    $('#form input').val('');
    $('#form textarea').val('');
    $('#form select').val('');
    $('#modal-trigger input').val('');
    $('#modal-trigger textarea').val('');
    $('#modal-trigger select').val('');
}
