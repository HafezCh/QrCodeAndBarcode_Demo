using System.ComponentModel.DataAnnotations;

namespace QrCodeAndBarcode_Demo.web.Models;

public class GenerateBarcodeModel
{
    [Display(Name = "Please Enter Barcode Text")]
    public string BarcodeText { get; set; }
}