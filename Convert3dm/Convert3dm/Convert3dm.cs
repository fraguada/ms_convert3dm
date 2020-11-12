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
        public static string Convert3dmToFbx(string data) 
        {
            var decodedData = Convert.FromBase64String(data);
            var file3dm = Rhino.FileIO.File3dm.FromByteArray(decodedData);
            var doc = Rhino.RhinoDoc.CreateHeadless(null);

            foreach (var obj in file3dm.Objects) 
                doc.Objects.Add(obj.Geometry, obj.Attributes);

            var id = Guid.NewGuid();
            string filename = @"E:\data\test"+ id + ".fbx";
            doc.Export(filename);

            if (File.Exists(filename))
            {

                // here we would push the file to DS
                // read fbx and convert to ByteArray, encode ... return

                byte[] fbxArr = System.IO.File.ReadAllBytes(filename);
                return Convert.ToBase64String(fbxArr);
            }
            else
                return "";
        }
    }
}
