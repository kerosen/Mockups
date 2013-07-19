function initSubmitAction()
{
    $('input[data-submitAction]').each(function ()
    {
        var input = this;
        $(input).click(function ()
        {
            var actionName = $(input).data('submitaction');
            $('#submitAction').val(actionName);
        });
    });
}

$(document).ready(function ()
{
    initSubmitAction();
});