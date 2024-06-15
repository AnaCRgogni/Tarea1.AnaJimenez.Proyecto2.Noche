namespace MVC.wwwroot.js.Pages
{
    public class song
    {
    //CODIGO DE REFERENCIA QUE HACE PETICION A API INTERMEDIA
    $(document).ready(function () {
        $('#button').click(function() {
                    var param = $('#input').val();
            $.ajax({
                    url: / api / data /${ param},
                method: 'GET',
                success: function(data) {
                    // Manejar la respuesta y actualizar la vista
                    $('#output').html(JSON.stringify(data));
                        },
                error: function(error) {
                            console.log(error);
                        }
                    });
                });
            });
    }
}
