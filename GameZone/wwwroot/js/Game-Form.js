// ضبط الصورة عند اختيار ملف 
$(document).ready(function () {
    $('#Cover').on('change', function () {
        const file = this.files[0];
        if (file) {
            $('.Cover-Preview')
                .attr('src', window.URL.createObjectURL(file)) // إنشاء رابط للصورة المرفوعة 
                .removeClass('d-none'); // عرض الصورة بإزالة الكلاس 
        }
    });
});