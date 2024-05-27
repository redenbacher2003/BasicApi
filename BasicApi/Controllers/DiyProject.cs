using BackendPw;
using BackendPw.CustomObject;
using BasicApi.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiyProjectController : ControllerBase
    {
        private readonly DiyProjectDbContext _pwdb;
        private static BackEndDiyManager _manager = new();

        public DiyProjectController(DiyProjectDbContext pwdb)
        {
            _pwdb = pwdb;
        }

        // GET: api/<ValuesController>
        [HttpGet("GetProjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetProjects_Async()
        {
            return await _manager.getProjects_Async();

        }

        [HttpGet("GetMaterialsByProjectId_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetMaterialsByProjectId_Async(int diyProjectId)   
        {
        
            return await _manager.getMaterialsByProjectId_Async(diyProjectId);

        }

        [HttpPost("createProject_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<IActionResult> createProject_Async([FromBody] BackendPw.CustomObject.DiyProject diyProject)
        {
            return Ok(await _manager.addProject_Async(diyProject.Name,
                                                      diyProject.startDate, 
                                                      diyProject.finishDate, 
                                                      diyProject.thumbNail, 
                                                      diyProject.addedBy, 
                                                      diyProject.addedDate));

        }

        [HttpGet("GetMaterialByProjectMaterialId_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetMaterialByProjectMaterialId_async(int materialId)
        {
            return await _manager.getDiyProjectMaterialById_Async(materialId);

        }

        [HttpPost("AddProjectMaterial_async")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<IActionResult> AddProjectMaterial_async([FromBody] BackendPw.CustomObject.DiyProjectMaterial diyProjectMaterial)
        {
                
                var result = await _manager.addMaterialBydiyProjectId_Async(diyProjectMaterial.diyProjectId, 
                                                                     diyProjectMaterial.storeName,
                                                                     diyProjectMaterial.materialName, 
                                                                     (int)diyProjectMaterial.quantity,
                                                                     (decimal)diyProjectMaterial.amount,
                                                                     (DateTime)diyProjectMaterial.purchaseDate,
                                                                     "Reden");

            return Created("api/AddProjectMaterial_async", result);

        }

        [HttpPut("UpdateProjectMaterial_async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<IActionResult> UpdateProjectMaterial_async([FromBody] BackendPw.CustomObject.DiyProjectMaterial diyProjectMaterial)
        {

            return Ok(await _manager.UpdateProjectMaterial_Async(diyProjectMaterial.id,
                                                                 diyProjectMaterial.materialName,
                                                                 (int)diyProjectMaterial.quantity,
                                                                 (decimal)diyProjectMaterial.amount,
                                                                 diyProjectMaterial.storeName,
                                                                 (DateTime)diyProjectMaterial.purchaseDate));
        }
        
        [HttpPut("UpdateProject_async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<IActionResult> UpdateProject_async([FromBody] BackendPw.CustomObject.DiyProject diyProject)
        {

            return Ok(await _manager.UpdateProject_Async (diyProject.Id,
                                                          diyProject.Name,
                                                          diyProject.startDate,
                                                          diyProject.finishDate,
                                                          diyProject.thumbNail));



        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<IActionResult> DeleteProjectMaterial_Async(int id, string user)
        {
            try { 
                await _manager.deleteMaterial_Async(id, user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProjectThumbnails_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetProjectThumbnails_Async()
        {
            return await _manager.projectThumbnailGet_Async();

        }

        [HttpGet("GetProjectGalleryImagesByProjectId_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableCors("OpenCORSPolicy")]
        public async Task<string> GetProjectGalleryImagesByProjectId_Async(int projectId)
        {
            return await _manager.projectGalleriesGetByProjectId_Async (projectId);

        }

    }
}

