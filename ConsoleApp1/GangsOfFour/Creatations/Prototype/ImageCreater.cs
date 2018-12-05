namespace ConsoleApp1.GangsOfFour.Creatations.Prototype
{
    public class ImageCreater : IImageCreater
    {
        public void createImage(IImage image)
        {
            image.Clone();
        }
    }
}
