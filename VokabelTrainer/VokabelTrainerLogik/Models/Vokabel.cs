namespace VokabelTrainerAPI.Models
{
    /// <summary>
    /// Provides the base data model to store vocabulary information, encapsulating one single word, its context, translation, etc.
    /// </summary>
    public class Vokabel
    {
        public int Id { get; set; }

        public string Wort { get; set; }
        public string Tip { get; set; }
        public string Uebersetzung { get; set; }
        public string Abschnitt { get; set; }
        public int TypId { get; set; }
        public virtual WortTyp Typ { get; set; }
        
        public int SpracheId { get; set; }
        public virtual Sprache Sprache { get; set; }
    }

}
