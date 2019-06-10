namespace SiggaBlog.UI.Model
{
    public class PostModel
    {
        #region Constantes

        private const int shortBodyLength = 30;
        private const string toBeContinued = "...";

        #endregion

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string ShortBody
        {
            get
            {
                if (!string.IsNullOrEmpty(Body) && Body.Length > shortBodyLength)
                {
                    return Body.Substring(0, shortBodyLength) + toBeContinued;
                }

                return Body;
            }
        }

        public int AlbumId { get; set; }

        public string AlbumTitle { get; set; }

    }
}
