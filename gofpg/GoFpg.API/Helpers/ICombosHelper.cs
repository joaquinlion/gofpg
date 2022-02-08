﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GoFpg.API.Helpers
{
    public interface ICombosHelper
    {
        //IEnumerable<SelectListItem> GetComboDocumentTypes();

        IEnumerable<SelectListItem> GetComboProcedures();

        IEnumerable<SelectListItem> GetComboGlassTypes();

        //IEnumerable<SelectListItem> GetComboVehicleTypes();

        //IEnumerable<SelectListItem> GetComboBrands();

    }
}
