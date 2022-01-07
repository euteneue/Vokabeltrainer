using VokabelTrainerAPI.Models;

namespace VokabelTrainerAPI.Data{
    public static class DbInitializer
    {
        public static void Initialize(VokabelTrainerAPIContext context)
        {
            if (context.Vokabel.Any()) return;


            var sprachen = new Sprache[]
            {
                new Sprache {Name = "Englisch" },
                new Sprache {Name = "Latein" }
            };

            context.Sprache.AddRange(sprachen);
            context.SaveChanges();

            var worttypen = new WortTyp[]
            {
                new WortTyp {Typ ="Anderer"},
                new WortTyp {Typ ="Nomen"},
                new WortTyp {Typ ="Adjektiv"},
                new WortTyp {Typ="Adverb"},
                new WortTyp {Typ ="Verb"}
            };

            context.WortTyp.AddRange(worttypen);
            context.SaveChanges();

            var vokabeln = new Vokabel[]
            {
                new Vokabel {Wort="test", Tip="N/A", Uebersetzung="Test", SpracheId=1, TypId=2, Abschnitt="N/A"},
                new Vokabel {Wort="morning", Tip="N/A", Uebersetzung="Morgen", SpracheId=1, TypId=2, Abschnitt="N/A"}
            };

            context.Vokabel.AddRange(vokabeln);
            context.SaveChanges();
        }
    }
}
