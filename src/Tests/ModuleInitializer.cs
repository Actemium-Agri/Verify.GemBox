public static class ModuleInitializer
{
    #region enable

    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyGemBox.Initialize();


        // Fixes https://forum.gemboxsoftware.com/t/png-from-a-pdf-differs-depending-on-the-machine/1484/8
        // Other options can be found on https://github.com/VerifyTests/Verify/blob/main/docs/comparer.md#pre-packaged-comparers
        // ImageMagick is preferred over ImageHash (which uses ImageSharp) because it is a stricter pixel-by-pixel comparison (in contrast to a perceptual comparison, which might ignore small differences)
        // Only register the ImageMagick comparers (no PDF converter, that's what VerifyGemBox is for)
        // Note: do NOT call VerifyImageMagick.Initialize() or VerifierSettings.InitializePlugins() here,
        // as both would call RegisterPdfToPngConverter() internally, overriding the VerifyGemBox PDF converter with Ghostscript.
        VerifyImageMagick.RegisterComparers();
    }

    #endregion
}