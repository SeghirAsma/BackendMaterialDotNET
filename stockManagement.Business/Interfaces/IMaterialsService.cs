using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Business.Interfaces
{
    public interface IMaterialsService
    {
        List<Materials> ListMaterials();
        Materials AddMaterials(Materials Materials);
        Materials UpdateMaterials(Materials Materials);
        bool DeleteMaterials(int id);

        Materials GetMaterialByld(int id);
    }
}
