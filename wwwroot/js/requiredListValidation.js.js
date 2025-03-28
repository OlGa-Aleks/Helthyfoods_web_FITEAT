// Добавляем метод валидации для проверки списка чекбоксов
$.validator.addMethod("requiredlist", function (value, element, param) {
    // Находим все чекбоксы с тем же именем
    var checkboxes = $("input[name='" + element.name + "']");
    return checkboxes.filter(":checked").length > 0;
});

// Подключаем адаптер для Unobtrusive
$.validator.unobtrusive.adapters.addBool("requiredlist");
