namespace GameLauncher
{
    public class RestorableError : Exception
    {
        public RestorableError(string desc) : base(desc) { }
    }
}
