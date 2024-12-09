$(document).ready(function () {
    // تطبيق Select2 على الحقول
    $('.form-select').select2({
        placeholder: "Select an option",
        allowClear: true,
        theme: "default"
    });
});