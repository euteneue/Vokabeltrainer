namespace VokabelTrainerAPI.Models
{
    /// <summary>
    /// Stores the language to which a word belongs, so that vocabulary of multiple 
    /// languages can be managed in the same database 
    /// </summary>
    public class Sprache
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
