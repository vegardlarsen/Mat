namespace Mat.Sources.Flickr
{
    /// <summary>
    /// A small set of available image sizes from Flickr, used for configuration.
    /// 
    /// Not all sizes are supported yet because of the underlying library not supporting all the sizes.
    /// </summary>
    public enum FlickrSize
    {
        Medium = 500,
        Large = 1024,
        //Large1600 = 1600,
        //Large2048 = 2048,
        Original = int.MaxValue
    }
}