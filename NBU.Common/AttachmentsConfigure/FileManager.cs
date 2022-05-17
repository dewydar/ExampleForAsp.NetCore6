using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.Common.AttachmentsConfigure
{
    public static class FileManager
    {
        public static bool CheckFilePath(string physicalPath)
        {
            try
            {

                if (Directory.Exists(physicalPath))
                    return true;

                Directory.CreateDirectory(physicalPath);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteFolder(string folder)
        {
            try
            {
                if (Directory.Exists(folder))
                {
                    var files = Directory.GetFiles(folder);
                    if (files.Length > 0)
                    {
                        foreach (var f in files)
                        {
                            File.Delete(f);
                        }
                    }

                    Directory.Delete(folder);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeleteSpecificFile(string specificFile)
        {
            try
            {
                if (File.Exists(specificFile))
                {
                    File.Delete(specificFile);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsSpecificFileExist(string specificFile)
        {
            try
            {
                if (File.Exists(specificFile))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool IsImage(string fileName)
        {
            var postedFileExtension = Path.GetExtension(fileName);

            if (string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".svg", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }


        public static bool IsVideo(string fileName)
        {
            var postedFileExtension = Path.GetExtension(fileName);

            if (string.Equals(postedFileExtension, ".mp4", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".mp3", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static bool IsImageOrPDF(string fileName)
        {
            var postedFileExtension = Path.GetExtension(fileName);

            if (string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".svg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }


        public static bool CheckIfImageOrVideo(string fileName)
        {
            var postedFileExtension = Path.GetExtension(fileName);

            if (string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".svg", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(postedFileExtension, ".mp4", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".AVI", StringComparison.OrdinalIgnoreCase)
                || string.Equals(postedFileExtension, ".wmv", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
