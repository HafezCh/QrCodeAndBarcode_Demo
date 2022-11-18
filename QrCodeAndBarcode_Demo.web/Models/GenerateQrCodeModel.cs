using System.ComponentModel.DataAnnotations;

namespace QrCodeAndBarcode_Demo.web.Models;

public class GenerateQrCodeModel
{
    [Display(Name = "Enter Qr Code Text")]
    public string QrCodeText { get; set; }
}