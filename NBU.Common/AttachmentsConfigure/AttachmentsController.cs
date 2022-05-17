using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace NBU.Common.AttachmentsConfigure
{
    public class AttachmentsController
    {
        const string _prePath = "/Attachments";
        public static string GetLocatedPath(string serverPath, long PageContentId,string FolderName)
        {
            string path = $"{serverPath}/wwwroot/{_prePath}/{FolderName}/{PageContentId}";

            FileManager.CheckFilePath(path);

            return path;
        }
        public static string CreateDocumentPath(string FolderName,string EntityID,string DocumentId,string Extension)
        {
            //FiePath = (z.DocumentInfo != null) ? "../Attachments/Employees/"+ z.Id +"/" + z.DocumentInfo?.Id + "." + z.DocumentInfo?.FileType : ""
            string path = $"../Attachments/{FolderName}/{EntityID}/{DocumentId}.{Extension}";
            FileManager.CheckFilePath(path);

            return path;
        }
    }
}
