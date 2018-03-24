# ImageHelper

A small netcore2.0 console application to auto-rotate all jpeg/jpg images from a directory to it's correct orientation based on the EXIF orientation flag, which was supposed to be written by the camera the images have been taken with.

While most modern image viewers will rotate images directly when showing them (based on the mentioned EXIF orientation flag), they won't manipulate the image file at all. 

My private web gallery (created with https://github.com/blueimp/Gallery) won't rotate portrait images. This small tool checks for the EXIF orientation flag, rotates and saves the file with the correct orientation.

This tool is not even more than a console wrapper for two functions from https://github.com/SixLabors/ImageSharp.

## Usage

The console app takes the image directory as first argument.

```
ImageHelper.exe [Path\To\ImageFiles]
```
* For now only image files with the extension *.jpg are supported (feel free to change the code)
* Images are overwritten, so always keep a copy of your orignial images (!)

## Build for .NET 4.6.1

In a console window from within project directory run:

```
dotnet -f net461
```
