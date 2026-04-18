namespace Proxy
{
    public interface IDocument
    {
        void DisplayDocument();
    }

    /// <summary>
    /// RealSubject
    /// </summary>
    public class Document: IDocument
    {
        public string? Title { get; set; }

        public string? Content { get; set; }

        public int AuthorId { get; set; }

        public DateTimeOffset LastAccessed { get; set; }

        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadFileName(fileName);
        }

        private void LoadFileName(string fileName)
        {
            Console.WriteLine("Executing expensive action: Loading a file from disk");
            Thread.Sleep(1000);

            Title = "An expensive document";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }


        public void DisplayDocument()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }


    public class DocumentProxy : IDocument
    {
        private Lazy<Document> _document;
        private string _fileName;

        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }

        public void DisplayDocument()
        {
            //if(_document == null)
            //{
            //    _document = new Document(_fileName);
            //}

            _document.Value.DisplayDocument();
        }
    }


    public class ProtectedDocumentProxy : IDocument
    {
        private string _fileName;
        private string _userRole;
        private DocumentProxy _documentProxy;

        public ProtectedDocumentProxy(string fileName, string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(_fileName);
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Entering DisplayDocument in {nameof(ProtectedDocumentProxy)}");

            if(_userRole != "Viewer")
            {
                throw new UnauthorizedAccessException();
            }

            _documentProxy.DisplayDocument();

            Console.WriteLine($"Existing DisplayDocument in {nameof(ProtectedDocumentProxy)}");
        }
    }
}
