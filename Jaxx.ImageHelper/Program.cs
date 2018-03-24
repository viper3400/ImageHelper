using System;
using System.IO;
using SixLabors.ImageSharp;

namespace Jaxx.ImageHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started ImageHelper");
            Console.WriteLine(@"USAGE: ImageHelper.exe [PATH\TO\JPEG\ImageFiles]");
            try
            {
                if (args.Length == 0 || String.IsNullOrWhiteSpace(args[0]))
                {
                    throw new ArgumentNullException("args", "ERROR: Argument must not be empty or null.");
                }

                var imageDir = args[0];
                if (!Directory.Exists(imageDir))
                {
                    throw new DirectoryNotFoundException($"Directory {imageDir} not found.");
                }

                Console.WriteLine($"Using direcotry {imageDir}.");
                foreach (var image in Directory.EnumerateFiles(imageDir, "*.jpg"))
                {
                    Console.WriteLine($"Processing file {image}.");
                    using (Image<Rgba32> img = Image.Load(image))
                    {
                        try
                        {
                            var orientation = img.MetaData.ExifProfile.GetValue(SixLabors.ImageSharp.MetaData.Profiles.Exif.ExifTag.Orientation);
                            Console.WriteLine(orientation.Value.ToString());
                            img.Mutate(x => x.AutoOrient());
                            img.Save(image);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No orientation tag found for image.");
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("ImageHelper finished. Press a key to continue ....");
                Console.ReadKey();
            }
        }
    }
}
