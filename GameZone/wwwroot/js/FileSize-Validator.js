﻿// إضافة ميثود جديدة للتحقق من حجم الملف 
$.validator.addMethod('filesize', function (value, element, param) {
    return this.optional(element) || (element.files[0] && element.files[0].size <= param);
});