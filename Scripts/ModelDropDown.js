$(document).ready(function () {
    $('#MakeList').change(function () {
        $.ajaxSetup({ cache: false });
        var selectedItem = $(this).val();
        if (selectedItem == "" || selectedItem == 0) {
            //Do nothing or hide...?
        } else {
            $.post('<%: ResolveUrl("~/Sell/GetModelsByMake/")%>' + $("#MakeList > option:selected").attr("value"), function (data) {
                var items = "";
                $.each(data, function (i, data) {
                    items += "<option value='" + data.ID + "'>" + data.Name + "</option>";
                });
                $("#ModelID").html(items);
                $("#ModelID").removeAttr('disabled');
            });
        }
    });
})