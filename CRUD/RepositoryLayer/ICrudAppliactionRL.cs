using CRUD.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.RepositoryLayer
{
    public interface ICrudAppliactionRL
    {
        public Task<CreateInformationResponse> CreateInformation(CreateInformationRequest request);
       

    }
}
