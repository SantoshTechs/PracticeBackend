using CRUD.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.ServiceLayer
{
    public interface ICrudAppliactionSL
    {
        public Task<CreateInformationResponse> CreateInformation(CreateInformationRequest request);
    }
}
