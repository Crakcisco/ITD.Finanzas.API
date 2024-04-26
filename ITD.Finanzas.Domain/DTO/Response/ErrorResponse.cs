using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Finanzas.Domain.DTO.DATA;

namespace ITD.Finanzas.Domain.DTO.Response
{
    public class ErrorResponse
    {
        public ErrorResponse _errorResponse { get; set; }
        public ErrorResponse _errors { get; set; }
        public List<ErrorData> errors;

    }
}
