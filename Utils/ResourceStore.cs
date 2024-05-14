namespace GameLauncher.Utils;

public class ResourceStore
{
    private static System.ComponentModel.ComponentResourceManager resources = new(typeof(GameItemControl));

    public static Image ErrorImage = (Image)resources.GetObject("CoverImageBox.Image")!;

}