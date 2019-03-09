using System.Collections.Generic;
using System.IO;

namespace TestOrangeHRM.Helpers
{
    public class FileHelper
    {
        private readonly string _path;

        public FileHelper()
        {

        }

        public FileHelper(string filePath)
        {
            _path = filePath;
        }


        public bool IsFileExists()
        {
            if (File.Exists(_path))
                return true;
            return false;
        }

        public string GetAllText()
        {
            if (IsFileExists())
                return File.ReadAllText(_path);
            return string.Empty;
        }

        public List<string> GetListOfFilePath(string fileExtension)
        {
            var fileList = new List<string>();
            string[] filePaths = Directory.GetFiles(_path, fileExtension);
            foreach (var file in filePaths)
            {
                fileList.Add(file);
            }
            return fileList;
        }

        public void WriteToFile(string message)
        {
            if (!IsFileExists())
            {
                File.Create(_path);
                TextWriter tw = new StreamWriter(_path);
                tw.WriteLine(message);
                tw.Close();
            }
            else if (IsFileExists())
            {
                using (var tw = new StreamWriter(_path, true))
                {
                    tw.WriteLine(message);
                }
            }

        }

    }
}
