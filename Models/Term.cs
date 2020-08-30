namespace Dictionary.Models
{
    using System;

    public class Term
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public string OriginalLanguage { get; set; }
        public string ToLanguage { get; set; }
    }
}