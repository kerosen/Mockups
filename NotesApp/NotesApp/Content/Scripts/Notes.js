function addRandomNote()
{
    $.ajax({
        url: 'Home/Notes',
        type: 'POST',
        //data: { id: id },
        success: function (result)
        {
            $('#notesContainer').html(result);
        }
    });
}

function addNote()
{
    $.ajax({
        url: 'Home/Note',
        type: 'PUT',
        //data: { Title: '', Description: '' },
        success: function (result)
        {
            $('#noteContainer').html(result);

            $('#noteContainer').dialog('open');
        },
    });
}

function handleModalSubmit(data, containerNameTrue, containerNameFalse )
{
    var response = data.responseText;

    var isValid = $(response).find(".field-validation-error").length == 0;

    if (isValid == false)
    {
        $('#' + containerNameFalse).html(response); //+ containerNameFalse).html(response);
    }
    else
    {
        $('#' + containerNameTrue).html(response);
        ClosePopup();
    }
}

function ShowPopup() { $('#noteContainer').dialog('open'); }
function ClosePopup() { $('#noteContainer').dialog('close'); }