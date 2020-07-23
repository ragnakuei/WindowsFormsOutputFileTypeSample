using System;
using System.Collections.Generic;

namespace WindowsFormsApp.GenerateFile
{
    public class GenerateFileFactory
    {
        private Dictionary<FileType, Func<IGenerateFile>> _fileTypeMapping
            = new Dictionary<FileType, Func<IGenerateFile>>
              {
                  [FileType.Txt]  = () => new GenerateTxtFile(),
                  [FileType.Csv]  = () => new GenerateCsvFile(),
                  [FileType.Xml]  = () => new GenerateXmlFile(),
                  [FileType.Json] = () => new GenerateJsonFile(),
              };

        public IGenerateFile Create(FileType fileType)
        {
            return _fileTypeMapping.GetValue(fileType).Invoke();
        }
    }
}