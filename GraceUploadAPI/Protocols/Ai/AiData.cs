using GraceUploadAPI.APIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Protocols.Ai
{
    public abstract class AiData:AbsProtocol
    {
        public AI64Module AI64Module { get; set; } = new AI64Module();
    }
}
