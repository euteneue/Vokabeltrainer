namespace VokabelTrainerAPI.Models
{
    /// <summary>
    /// Provides information about the type of word that is being stored, e.g. noun, verb, adjective...
    /// In order to simplify things, the word type is not restricted to a given list but can be stored and managed
    /// by itself.
    /// </summary>
    public class WortTyp
    {
        public int Id { get; set; }
        public string Typ { get; set; }

    }
}
