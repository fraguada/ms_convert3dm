using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert3dm
{
    static class Convert3dm
    {
        public static string Convert3dmToFbx(string uri) 
        {
            // Here we would download the file from DS

            var doc = Rhino.RhinoDoc.CreateHeadless(null);
            doc.Import(uri);

            var id = Guid.NewGuid();
            string filename = @"E:\data\test"+ id + ".fbx";
            doc.Export(filename);

            if ( File.Exists(filename) )

                // here we would push the file to DS

                return filename;
            else
                return "";
        }
    }
}
