$(function () {
    $("ul#menu a").click(function () {

        pagina = $(this).attr('href')

        $("#content").load(pagina)
        return false;

    });
})