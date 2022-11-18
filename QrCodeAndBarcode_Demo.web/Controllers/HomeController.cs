using BarcodeLib;
using Microsoft.AspNetCore.Mvc;
using QrCodeAndBarcode_Demo.web.Models;
using QRCoder;

namespace QrCodeAndBarcode_Demo.web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GenerateQrCode")]
        public IActionResult GenerateQrCode()
        {
            return View();
        }

        [HttpPost("GenerateQrCode")]
        public IActionResult GenerateQrCode(GenerateQrCodeModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                using MemoryStream memoryStream = new MemoryStream();
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(model.QrCodeText, QRCodeGenerator.ECCLevel.Q);

                PngByteQRCode qRCode = new PngByteQRCode(qRCodeData);
                byte[] qRCodeByte = qRCode.GetGraphic(20);

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/QrCodes");
                if (Directory.Exists(path) == false)
                    Directory.CreateDirectory(path);

                var fileName = $"{Guid.NewGuid()}.png";
                string filePath = Path.Combine(path, fileName);

                using Stream stream = System.IO.File.Create(filePath);
                stream.Write(qRCodeByte);

                ViewBag.QrCode = fileName;

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GenerateBarcode")]
        public IActionResult GenerateBarcode()
        {
            return View();
        }

        [HttpPost("GenerateBarcode")]
        public IActionResult GenerateBarcode(GenerateBarcodeModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                Barcode barcode = new Barcode();
                barcode.IncludeLabel = true;
                barcode.LabelPosition = LabelPositions.BOTTOMCENTER;
                barcode.Encode(TYPE.CODE39, model.BarcodeText);

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Barcodes");
                if (Directory.Exists(path) == false)
                    Directory.CreateDirectory(path);

                var fileName = $"{Guid.NewGuid()}.png";
                string filePath = Path.Combine(path, fileName);

                using Stream stream = System.IO.File.Create(filePath);

                barcode.SaveImage(stream, SaveTypes.PNG);

                ViewBag.Barcode = fileName;

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}