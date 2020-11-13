using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace Convert3dm
{
    [Rhino.Commands.CommandStyle(Rhino.Commands.Style.ScriptRunner)]
    public class Convert3dmCommand : Command
    {
        public Convert3dmCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static Convert3dmCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "Convert3dmCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {

            // select 3dm file

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "3dm files (*.3dm)|*.3dm;";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            string selectedFileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = openFileDialog1.FileName;
            }
            else 
            {
                return Result.Failure;
            }

            var file = Rhino.FileIO.File3dm.Read(selectedFileName);
            var arr = file.ToByteArray();
            var b64 = Convert.ToBase64String(arr);
            var result = Convert3dm.Convert3dmToFbx(b64);

            RhinoApp.WriteLine("Converted file: " + result);

            return Result.Success;
        }
    }
}
