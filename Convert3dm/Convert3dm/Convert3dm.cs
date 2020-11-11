using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert3dm
{
    static class Convert3dm
    {
        public static string Convert3dmToFbx(string uri) 
        {

            //var doc = Rhino.FileIO.File3dm.Read(uri);

            var doc = Rhino.RhinoDoc.Open(uri, out _);

            string filename = @"E:\data\test.fbx";
            string script = string.Format("_-SaveAs \"{0}\" _Enter _Enter", filename);

            var result = Rhino.RhinoApp.RunScript(script, false);

            return filename;
        }
    }
}
