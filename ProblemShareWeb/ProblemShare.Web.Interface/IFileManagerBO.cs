using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemShare.Web.Interface
{
    public interface IFileManagerBO
    {
        Stream GetWriteStream(string fileName, string directory = "");
        Stream GetReadStream(string fileName, string directory = "");
        bool DeleteFile(string fileName, string directory = "");
        bool FileExists(string fileName, string directory = "");
    }
}