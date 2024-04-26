using CRUD.CommonLayer.Models;
using CRUD.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {
        public readonly ICrudAppliactionSL _crudApplicationSL;

        public CrudApplicationController(ICrudAppliactionSL crudAppliactionSL)
        {
            _crudApplicationSL = crudAppliactionSL;
        }

        [HttpPost]
        [Route("CreateInformation")]
        public async Task<IActionResult> CreateInformation(CreateInformationRequest request)
        {
            CreateInformationResponse response = null;
            try
            {

                response = await _crudApplicationSL.CreateInformation(request);

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

       
           
        
    }
}
