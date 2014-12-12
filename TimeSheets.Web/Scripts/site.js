$(function ()
{
    $('.datetimepicker').datetimepicker();
    $('Shift_StartDateTime').datetimepicker();
});

$(function() {
    try {
        $(".datetimepicker input[type='text']").each(function() {
            $(this).attr("autocomplete", "off");
        });
    } catch (e) {
    }
});

function ClearResults(s, f, b)
{
    $(s).replaceWith("<td class='col-md-2'><img src='Images/loader.gif' /></td>");
    $(f).replaceWith("<td class='col-md-2'><img src='Images/loader.gif' /></td>");
};

