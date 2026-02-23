using GemBox.Document;
using GemBox.Presentation;

namespace VerifyTests;

public static partial class VerifyGemBox
{
   public static bool Initialized { get; set; }

    public static void Initialize()
    {
        if (Initialized)
        {
            return;
        }

        Initialized = true;

        VerifierSettings.RegisterStreamConverter("xlsx", ConvertExcel);
        VerifierSettings.RegisterStreamConverter("xls", ConvertExcel);
        VerifierSettings.RegisterFileConverter<ExcelFile>(ConvertExcel);

        VerifierSettings.RegisterStreamConverter("pdf", ConvertPdf);
        VerifierSettings.RegisterFileConverter<PdfDocument>(ConvertPdf);

        VerifierSettings.RegisterStreamConverter("docx", ConvertDocx);
        VerifierSettings.RegisterStreamConverter("doc", ConvertDoc);
        VerifierSettings.RegisterFileConverter<DocumentModel>(ConvertWord);

        VerifierSettings.RegisterStreamConverter("pptx", ConvertPptx);
        VerifierSettings.RegisterStreamConverter("ppt", ConvertPpt);
        VerifierSettings.RegisterFileConverter<PresentationDocument>(ConvertPowerPoint);
    }
}