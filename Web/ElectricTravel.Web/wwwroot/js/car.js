//Insert default item "Select" in dropdownlist on load
$(document).ready(function () {
    var items = "<option value='0'>Select</option>";
    $("#modelslist").html(items);
});

//Bind City dropdownlist
$("#makeslist").change(function () {
    var makeId = $("#makeslist").val();
    var url = "/ElectricCars/GetModelsList";

    $.getJSON(url, { MakeId: makeId }, function (data) {
        var item = "";
        $("#modelslist").empty();
        $.each(data, function (i, model) {
            item += '<option value="' + model.value + '">' + model.text + '</option>'
        });
        $("#modelslist").html(item);
    });
});
