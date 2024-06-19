$(document).ready(function () {
    $("#tblItens").DataTable({
        language: {
            //url: '../Scripts/DataTables-1.10.10/Plugins-master/i18n/Portuguese-Brasil.lang',
            //url: "https://cdn.datatables.net/plug-ins/1.10.10/i18n/Portuguese-Brasil.json",
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "resultados por página_MENU_",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        },
        "pageLength": 5,
        "lengthMenu": [5, 10, 15, 20, 25],
        "pagingType": "full_numbers",
        "dom": '<"top"fl>rt<"bottom"ip><"clear">',
        "destroy": true
    });

    $(".paginate_button").click(function () {
        $('.fixed-action-btn').floatingActionButton({
            hoverEnabled: false,
            direction: 'right'
        });

    });
});
