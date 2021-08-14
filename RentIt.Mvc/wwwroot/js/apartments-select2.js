$(document).ready(function () {
    $("#apartmentList").select2({
        placeholder: "Select apartment",
        allowClear: true,
        ajax: {
            url: "/Apartment/SearchByFullName",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query =
                {
                    searchTerm: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.address
                        };
                    }),
                };
            }
        }
    });
});
