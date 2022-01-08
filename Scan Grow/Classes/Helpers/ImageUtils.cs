using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ScanGrow
{
    public static class ImageUtils
    {

        public static Bitmap CropImage(Image source, int x, int y, int width, int height)
        {
            Rectangle crop = new Rectangle(x, y, width, height);
            var bmp = new Bitmap(crop.Width, crop.Height);
            bmp.SetResolution(300.0F, 300.0F);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            
            return bmp;
        }


        public static void FlipImage(string path)
        {
            Image Source = Image.FromFile(path);
            Source.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Source.Save(path);
        }

        public static void TagImage (string path, string tag)
        {

            string ParentFileName = Path.GetFileNameWithoutExtension(path);
            string ParentFileDirectory = Path.GetDirectoryName(path);
            tag = tag.Replace(".", "^");
            string Dest = ParentFileDirectory+"\\"+ParentFileName +"_%_" + tag+".png";
            if (File.Exists(Dest))
            {
                File.Delete(Dest);
            }
            System.IO.File.Move(path, Dest);
            ProcessWells.AddSampleData(ParentFileDirectory , ParentFileDirectory + "\\" + ParentFileName + "_%_" + tag + ".png");

        }



        public static List<string> GetImageFilesFromDirectory(string Directory)
        {
            List<Well> wells = new List<Well>();
            if (File.Exists(Directory + "\\" + "samples.json"))
            {
                string Samples = System.IO.File.ReadAllText(Directory + "\\" + "samples.json");

                wells = JsonConvert.DeserializeObject<List<Well>>(Samples);
            }

            List<string> Files = new List<string>();
           
            foreach (var f in wells)
            {
                 Files.Add(f.SourceImagePath); 
            }

            return Files;
        }


    }
}