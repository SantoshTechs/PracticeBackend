using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.CommonLayer.Models
{
    public class CreateInformationRequest
    {
        public int Id { get; set; }

        [Required]
        public string fullName { get; set; }

        [Required]
        public string company { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public string emailId { get; set; }

        [Required]
        public string mobileNumber { get; set; }

        [Required]
        public string note1 { get; set; }

        public string messageNote { get; set; }
    }

    public class CreateInformationResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
