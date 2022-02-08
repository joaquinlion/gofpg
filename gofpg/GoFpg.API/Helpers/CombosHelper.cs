using GoFpg.API.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GoFpg.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        //public IEnumerable<SelectListItem> GetComboBrands()
        //{
        //    List<SelectListItem> list = _context.Brands.Select(x => new SelectListItem
        //    {
        //        Text = x.Description,
        //        Value = $"{x.Id}"
        //    })
        //        .OrderBy(x => x.Text)
        //        .ToList();

        //    list.Insert(0, new SelectListItem
        //    {
        //        Text = "[Seleccione una marca...]",
        //        Value = "0"
        //    });

        //    return list;
        //}

        public IEnumerable<SelectListItem> GetComboProcedures()
        {
            List<SelectListItem> list = _context.Procedures.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un procedimiento...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboGlassTypes()
        {
            List<SelectListItem> list = _context.GlassTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select the Glass you need Replaced...]",
                Value = "0"
            });

            return list;
        }

        //public IEnumerable<SelectListItem> GetComboDocumentTypes()
        //{
        //    List<SelectListItem> list = _context.DocumentTypes.Select(x => new SelectListItem
        //    {
        //        Text = x.Description,
        //        Value = $"{x.Id}"
        //    })
        //        .OrderBy(x => x.Text)
        //        .ToList();

        //    list.Insert(0, new SelectListItem
        //    {
        //        Text = "[Selet Id. type...]",
        //        Value = "0"
        //    });

        //    return list;
        //}



        //public IEnumerable<SelectListItem> GetComboVehicleTypes()
        //{
        //    //List<SelectListItem> list = _context.VehicleTypes.Select(x => new SelectListItem
        //    //{
        //    //    Text = x.Description,
        //    //    Value = $"{x.Id}"
        //    //})
        //    //    .OrderBy(x => x.Text)
        //    //    .ToList();

        //    //list.Insert(0, new SelectListItem
        //    //{
        //    //    Text = "[Seleccione un tipo de vehículo...]",
        //    //    Value = "0"
        //    //});

        //    //return list;
        //}
    }
}
