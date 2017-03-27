using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemShare.Web.Interface;

namespace ProblemShare.Web.Business
{
    public class LocalFileManagerBO : IFileManagerBO
    {
        private const string FILE_PATH = @"C:\Users\Micah Switzer\Documents\ProblemShare\Uploads";

        public bool DeleteFile(string fileName, string directory = "")
        {
            try
            {
                File.Delete(getPath(fileName, directory));
            }
            catch (Exception)
            {
                return false; 
            }
            return true;
        }

        public bool FileExists(string fileName, string directory = "")
        {
            return File.Exists(getPath(fileName, directory));
        }

        public Stream GetReadStream(string fileName, string directory = "")
        {
            return File.OpenRead(getPath(fileName, directory));
        }

        public Stream GetWriteStream(string fileName, string directory = "")
        {
            return File.OpenWrite(getPath(fileName, directory));
        }

        private static string getPath(string fName, string fDir)
        {
            if (fDir.Contains(Path.DirectorySeparatorChar)) throw new InvalidDataException("Parameter 'directory' must only be a single directory name");
            return Path.Combine(FILE_PATH, fDir, fName);
        }
    }
}