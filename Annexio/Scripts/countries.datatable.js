$(document).ready(function () {
    $("#countries").DataTable({
        ajax: {
            url: "countries/getcountries/",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, string, country) {
                    return "<a href='/Countries/Details?Name=" + country.Name + "'>" + country.Name + "</a>";
                }
            },
            {
                data: "region",
                render: function (data, string, region) {
                    return "<a href='/Regions/RegionDetails?regionName=" + region.Region + "'>" + region.Region + "</a>";
                }
            },
            {
                data: "subregion",
                render: function (data, string, subregion) {
                    return "<a href='/Subregions/SubregionDetails?subregionName=" + subregion.Subregion + "'>" + subregion.Subregion + "</a>";
                }
            }
        ]

    });

});