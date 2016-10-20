namespace MvcTemplate.Services.Web
{
    public class IdentifierProvider : IIdentifierProvider
    {
        private const string Salt = ".12312313123";

        public int DecodeId(string urlId)
        {
            var result = urlId.Split('-');
            int id = int.Parse(result[0]);

            return id;
        }

        public string EncodeId(int id, string title)
        {
            var editedTitle = title.Replace(" ", "-");
            var plainTextBytes = id + "-" + editedTitle;

            return plainTextBytes;
        }
    }
}
