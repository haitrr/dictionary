namespace Dictionary.Models
{
    using System;

    public class Term
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public string Meaning { get; set; }
        public string OriginalLanguage { get; set; }
        public string ToLanguage { get; set; }
    }
}