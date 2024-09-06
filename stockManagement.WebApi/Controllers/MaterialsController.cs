using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockManagement.Business.Interfaces;
using stockManagement.Data.Models;
using System.Collections.Generic;

namespace stockManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialsService _MaterialsService;
        public MaterialsController(IMaterialsService MaterialsService)
        {
            _MaterialsService = MaterialsService;
        }

        [HttpGet("getListMaterials")]
        public List<Materials> GetListMaterials()
        {
            List<Materials> materials = new List<Materials>();
            materials = _MaterialsService.ListMaterials();
            return materials;
        }

        [HttpPost("addMaterials")]
        public Materials AddMaterials([FromBody] Materials materials)
        {
            materials = _MaterialsService.AddMaterials(materials);
            return (materials);
        }

        [HttpDelete("deleteMaterials/{id}")]
        public IActionResult DeleteMaterials(int id)
        {
            bool result = this._MaterialsService.DeleteMaterials(id);
            return Ok(result);
        }

        [HttpPut("updateMaterials")]
        public Materials UpdateMaterials([FromBody] Materials materials)
        {
            materials = _MaterialsService.UpdateMaterials(materials);
            return (materials);
        }
        [HttpGet("MaterialById/{id}")]
        public Materials GetMaterailByld(int id)
        {
            Materials materials = this._MaterialsService.GetMaterialByld(id);
            return materials;
        }

    }
}
