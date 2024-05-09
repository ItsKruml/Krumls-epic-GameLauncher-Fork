namespace GameLauncher.Utils;

public class ResourceStore
{
    private static System.ComponentModel.ComponentResourceManager resources = new(typeof(GamePanelControl));

    public static Image ErrorImage = (Image)resources.GetObject("CoverImageBox.Image")!;

}