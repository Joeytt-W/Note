using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility
{
    public class Document
    {
        public string Title { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool ApprovedByLitigation { get; set; }
        public bool ApprovedByManagement { get; set; }

        public Document(
            string title,
            DateTimeOffset lastModified,
            bool approvedByLitigation,
            bool approvedByManagement)
        {
            Title = title;
            LastModified = lastModified;
            ApprovedByLitigation = approvedByLitigation;
            ApprovedByManagement = approvedByManagement;
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public interface IHandle<T> where T : class
    {
        IHandle<T> SetSuccessor(IHandle<T> successor);

        void Handle(T request);
    }

    public class DocumentTitleHandler : IHandle<Document>
    {
        private IHandle<Document>? _successor;

        public IHandle<Document> SetSuccessor(IHandle<Document> successor)
        {
            _successor = successor;
            return successor;
        }

        public void Handle(Document document)
        {
            if (document.Title == string.Empty)
            {
                throw new ValidationException(new ValidationResult("Title must be filled out",
                    new List<string>() { "Title" }), null, null);
            }

            _successor?.Handle(document);
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public class DocumentLastModifiedHandler : IHandle<Document>
    {
        private IHandle<Document>? _successor;

        public IHandle<Document> SetSuccessor(IHandle<Document> successor)
        {
            _successor = successor;
            return successor;
        }

        public void Handle(Document document)
        {
            if (document.LastModified < DateTime.Now.AddDays(-30))
            {
                throw new ValidationException(
                    new ValidationResult("Document must be modified in the last 30 days",
                        new List<string>() { "LastModified" }), null, null);
            }

            _successor?.Handle(document);
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public class DocumentApprovedByLitigationHandler : IHandle<Document>
    {
        private IHandle<Document>? _successor;

        public IHandle<Document> SetSuccessor(IHandle<Document> successor)
        {
            _successor = successor;
            return successor;
        }

        public void Handle(Document document)
        {
            if (!document.ApprovedByLitigation)
            {
                throw new ValidationException(
                    new ValidationResult("Document must be approved by litigation",
                        new List<string>() { "ApprovedByLitigation" }), null, null);
            }

            _successor?.Handle(document);
        }
    }

    /// <summary>
    /// ConcreteHandler
    /// </summary>
    public class DocumentApprovedByManagementHandler : IHandle<Document>
    {
        private IHandle<Document>? _successor;

        public IHandle<Document> SetSuccessor(IHandle<Document> successor)
        {
            _successor = successor;
            return successor;
        }

        public void Handle(Document document)
        {
            if (!document.ApprovedByManagement)
            {
                throw new ValidationException(
                    new ValidationResult("Document must be approved by management",
                        new List<string>() { "ApprovedByManagement" }), null, null);
            }

            _successor?.Handle(document);
        }
    }
}
