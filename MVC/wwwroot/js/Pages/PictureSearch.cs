
//Maneja lógica del lado del cliente para enviar solicitudes al servidor y actualizar la página con los resultados
$(document).ready(function() {
    $('#search-button').click(function() {
        var query = $('#search-box').val();
        if (query)
        {
            $.ajax({
            url: '/api/pictures/search',
                type: 'GET',
                data: { query: query },
                success: function(data) {
                    $('.search-results').empty();
                    $.each(data, function(index, picture) {
                        $('.search-results').append(
                            '<div class="picture-card">' +
                                '<img class="picture-img" src="' + picture.url + '" alt="Picture">' +
                                '<div class="photographer-name">' + picture.photographer + '</div>' +
                            '</div>'
                        );
                    });
                },
                error: function() {
                    alert('Error al buscar imágenes.');
                }
            });
        }
        else
        {
            alert('Por favor ingresa un término de búsqueda.');
        }
    });
});
