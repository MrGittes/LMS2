$(function () {
    $("#KlassId").on("change", function () {
        // You're referring to the object itself, so you can use $(this).
        alert(this.value);
        UpdateRecords();
    });
}());