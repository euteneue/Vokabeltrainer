namespace VokabelTrainerAPI.Models
{
    /// <summary>
    /// Provides the base data model to store vocabulary information, encapsulating one single word, its context, translation, etc.
    /// </summary>
    public class VokabelSimpel
    {
        public int Id { get; set; }

        public string Wort { get; set; }
        public string Tip { get; set; }
        public string Uebersetzung { get; set; }
        public string Abschnitt { get; set; }
        public string WortTyp { get; set; } 
        
        public string Sprache { get; set; }
    }

}
