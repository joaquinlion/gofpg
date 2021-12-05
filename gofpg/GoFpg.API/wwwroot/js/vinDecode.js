
    $(document).ready(function(){
        $("#Vinnum").keyup(function () {
            var demaValue = $.trim($("#Vinnum").val());
            if (demaValue.length >= 17) {
                Rellenar();
            }

        });
});

    function Rellenar()
    {
	var demaValue = $.trim($("#Vinnum").val());
    var urlRequest = 'https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/' + demaValue + '?format=json';
    $.ajax({
        url: urlRequest,
    type: "GET",
    dataType: "json",
    success: function(result)
    {
        resultadoAjax = result;
    FillFields(result)
    },
    error: function(xhr, ajaxOption, thrownError)
    {
        console.log(xhr)
    }
    });
}
    function FillFields(objJson){
	if(!!objJson && !!objJson.Results && !!objJson.Results.length>0)
    {
    	var result=objJson.Results[0];
    $("#year").val(result.ModelYear);
    $("#Make").val(result.Make);
    $("#model").val(result.Model);
    $("#Doors").val(result.Doors);
    $("#BodyClass").val(result.BodyClass);
    $("#VehicleType").val(result.VehicleType);
    $("#LaneDeparture").val(result.LaneDepartureWarning);
    $("#LaneKeep").val(result.LaneKeepSystem);
    $("#ErrorCode").val(result.ErrorCode);
    }
}