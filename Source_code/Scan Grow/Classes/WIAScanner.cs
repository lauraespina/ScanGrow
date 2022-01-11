using DNTScanner.Core;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace ScanGrow
{
    public static class WIAScanner {

        public static void Scan(string ScannerId, int Resolution, string imageFileName) {
            try
            {
                var scanners = SystemDevices.GetScannerDevices();
                var selected = scanners.Single(t=> t.Id == ScannerId);
              
                using (var scannerDevice = new ScannerDevice(selected))
                {
                    scannerDevice.ScannerPictureSettings(config =>
                    {
                        config.ColorFormat(ColorType.Color)
                              // Optional settings
                              .Resolution(Resolution)
                              .Brightness(1)
                              .Contrast(1)
                              .StartPosition(left: 0, top: 0)
                              ;
                    });

                    scannerDevice.ScannerDeviceSettings(config => {});
                    scannerDevice.PerformScan(WiaImageFormat.Tiff);
                    var fileName = imageFileName;
                    foreach (var file in scannerDevice.SaveScannedImageFiles(fileName))
                    {
                        Console.WriteLine($"Saved image file to: {file}");
                    }


                }
            }
            catch (COMException ex)
            {
                var friendlyErrorMessage = ex.GetComErrorMessage(); 
                Console.WriteLine(friendlyErrorMessage);
                Console.WriteLine(ex);
            }
        }
    }
    }
