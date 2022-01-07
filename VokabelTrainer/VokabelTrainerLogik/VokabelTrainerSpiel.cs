using VokabelTrainerAPI.Models;
using VokabelTrainerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace VokabelTrainerLogik
{
    public enum SpielModus { Linear, Zufall };

    /**
     * Implements functionality to execute a vocabulary training "game". 
     * 
     * Ensures that state of play as well as other state information is kept, so that the UI can
     * initiate and query and instance of this class to stepwise run through the game.
     */
    public class VokabelTrainerSpiel
    {
        private DbContextOptions<VokabelTrainerAPIContext> _options;

        public List<Vokabel> Vokabeln 
        { get
            {
                using var context = new VokabelTrainerAPIContext(_options);
                return context.Vokabel
                    .Include(vokabel => vokabel.Sprache)
                    .Include(vokabel => vokabel.Typ)
                    .ToList();
            }
        } 

        public SpielModus SpielModus { get; set;}

        public Sprache? Sprache { get; set; }    

        public bool Active { get;  }

        public int Score { get;  }  

        /**
         * Initialises the VokabelTrainerSpiel class.
         * @context - The data needed to conduct the game.
         * @modus - The desired mode of play
         * @sprache - The desired language
         */
        public VokabelTrainerSpiel(DbContextOptions<VokabelTrainerAPIContext> options, SpielModus modus = SpielModus.Linear, Sprache? sprache=null)
        {
            this._options = options;

            SpielModus = modus;
            if (sprache != null) Sprache = sprache;

            Active = false;
            Score = 0;
        }

        /**
         * Returns a list of all distinct languages present in a set of vocabulary.
         */
        public List<Sprache> GetAllLanguages()
        {
            List<Sprache> result = Vokabeln.Select(v => v.Sprache).Distinct().ToList();
            
            return result;
        }

        /**
         * Returns a list of all distinct word types present in a set of vocabulary.
         */
        public List<WortTyp> GetAllWordTypes()
        {
            List<WortTyp> result = Vokabeln.Select(v => v.Typ).Distinct().ToList();

            return result;
        }


        /**
         * Returns a list of all distinct sections present in a set of vocabulary.
         */
        public List<string> GetAllSections()
        {
            List<string> result = Vokabeln.Select(v => v.Abschnitt).Distinct().ToList();

            return result;
        }
    }
}