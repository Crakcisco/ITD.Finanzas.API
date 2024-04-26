using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Finanzas.Domain.DTO.DATA
{
    public class ErrorData
    {
        public string code {  get; set; }
        public string tittle { get; set; }
        public string detail { get; set; }
        public int status { get; set; }

    }
}
