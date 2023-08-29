namespace Web.UserServices
{
    public interface ISaveFile
    {
        public Task<string> Save(IFormFile file);
    }
}
