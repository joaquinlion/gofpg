$(document).ready(function () {
    $("#Vinnum").keyup(function () {
        var vinValue = $.trim($("#Vinnum").val());
        if (vinValue.length >= 17) {
            Rellenar();
        }
    });
});

function Rellenar() {
    var vinValue = $.trim($("#Vinnum").val());
    var urlRequest = 'https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/' + vinValue + '?format=json';
    $.ajax({
        url: urlRequest,
        type: "GET",
        dataType: "json",
        success: function (result) {
            var resultf = result.Results[0];
            $("#Year").val(resultf.ModelYear);
            $("#Make").val(resultf.Make);
            $("#Model").val(resultf.Model);
            $("#Doors").val(resultf.Doors);
            $("#BodyClass").val(resultf.BodyClass);
            $("#VehicleType").val(resultf.VehicleType);
            $("#LaneDeparture").val(resultf.LaneDepartureWarning);
            $("#LaneKeep").val(resultf.LaneKeepSystem);
            $("#ErrorCode").val(resultf.ErrorCode);
            //var objJson = result,
            //FillFields(objJson)

        },
        error: function (xhr, ajaxOption, thrownError) {
            console.log(xhr)
        }
    });
}