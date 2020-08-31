$(document).ready(function () {
    $("#countries").DataTable({
        ajax: {
            url: "api/countries",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, string, country) {
                    return "<a href='/Countries/Details?Name=" + data + "'>" + data + "</a>";
                }
            },
            {
                data: "region",
                render: function (data, string, region) {
                    return "<a href='/Regions/RegionDetails?regionName=" + data + "'>" + data + "</a>";
                }
            },
            {
                data: "subregion",
                render: function (data, string, subregion) {
                    return "<a href='/Subregions/SubregionDetails?subregionName=" + data + "'>" + data + "</a>";
                }
            }
        ]

    });

});