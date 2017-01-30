using System.Collections.Generic;

namespace AlcoholCalculator
{
    internal class Ingredient : Alcohol
    {
        #region Non-alcoholic
        public static Alcohol Juice = new Alcohol("Сок", 0.0, 1);
        public static Alcohol Limefresh = new Alcohol("Лимонный фреш", 0.0, 1);
        public static Alcohol LimeJuice = new Alcohol("Лайм джус", 0.0, 1);
        public static Alcohol Grenadine = new Alcohol("Гренадин", 0.0, 1);
        public static Alcohol Espresso = new Alcohol("Эспрессо кофе", 0.0, 1);
        public static Alcohol Tobasco = new Alcohol("Тобаско", 0.0, 1);
        public static Alcohol Mint = new Alcohol("Мятный ликер", 0.0, 1);
        public static Alcohol OrangeJuice = new Alcohol("Апельсиновый сок", 0.0, 1);
        #endregion
        #region Alcoholic
        public static Alcohol Vodka = new Alcohol("Водка", 0.4, 1);
        public static Alcohol PisangAmbon = new Alcohol("Пизан Амбон", 0.21, 1);
        public static Alcohol Tequila = new Alcohol("Текила", 0.38, 1);
        public static Alcohol Absinthe = new Alcohol("Абсент", 0.6, 1);
        public static Alcohol Baylis = new Alcohol("Бейлиз", 0.17, 1);
        public static Alcohol Sambuca = new Alcohol("Самбука", 0.41, 1);
        public static Alcohol Goldstrike = new Alcohol("Голд страйк", 0.5, 1);
        public static Alcohol Tripplesec = new Alcohol("Трипл сек", 0.4, 1);
        public static Alcohol Kahlua = new Alcohol("Калуа", 0.2, 1);
        public static Alcohol Becherovka = new Alcohol("Бехеровка", 0.38, 1);
        public static Alcohol Jamesson = new Alcohol("Джемиссон", 0.4, 1);
        public static Alcohol Malibu = new Alcohol("Малибу", 0.21, 1);
        public static Alcohol Rum = new Alcohol("Ром", 0.4, 1);
        public static Alcohol BlueCurasao = new Alcohol("Блю Курасао", 0.2, 1);
        public static Alcohol Gin = new Alcohol("Джин", 0.45, 1);
        public static Alcohol Aperol = new Alcohol("Апероль", 0.11, 1);
        #endregion
        public static List<Alcohol> Otvertka = new List<Alcohol>
        {
            Vodka.OfPart(0.25),
            Juice.OfPart(0.75)
        };

        public static List<Alcohol> GreenMexican = new List<Alcohol>
        {
            Tequila.OfPart(0.5),
            PisangAmbon.OfPart(0.3),
            Limefresh.OfPart(0.2)
        };
        public static List<Alcohol> GoldMexican = new List<Alcohol>
        {
            Tequila.OfPart(0.5),
            PisangAmbon.OfPart(0.3),
            OrangeJuice.OfPart(0.2)
        };
        public static List<Alcohol> Hirosima = new List<Alcohol>
        {
            Absinthe.OfPart(0.35),
            Baylis.OfPart(0.35),
            Sambuca.OfPart(0.2),
            Grenadine.OfPart(0.1)
        };

        public static List<Alcohol> GoldMilk = new List<Alcohol>
        {
            Sambuca.OfPart(0.6),
            Goldstrike.OfPart(0.4)  
        };

        public static List<Alcohol> Lobotomiya = new List<Alcohol>
        {
            Espresso.OfPart(0.3),
            Tripplesec.OfPart(0.2),
            Baylis.OfPart(0.3),
            Tobasco.OfPart(0.1),
            Tequila.OfPart(0.2)
        };

        public static List<Alcohol> RedDog = new List<Alcohol>
        {
            Sambuca.OfPart(0.47),
            Tequila.OfPart(0.47),
            Tobasco.OfPart(0.06)
        };

        public static List<Alcohol> TequilaHot = new List<Alcohol>
        {
            Tequila.OfPart(0.47),
            Tobasco.OfPart(0.06),
            Espresso.OfPart(0.47)
        };

        public static List<Alcohol> Chihuahua = new List<Alcohol>
        {
            Tripplesec.OfPart(0.5),
            Tequila.OfPart(0.5)
        };
        public static List<Alcohol> B53 = new List<Alcohol>
        {
            Kahlua.OfPart(0.3),
            Baylis.OfPart(0.3),
            Absinthe.OfPart(0.4)
        };

        public static List<Alcohol> B52 = new List<Alcohol>
        {
            Baylis.OfPart(0.3),
            Tripplesec.OfPart(0.4),
            Espresso.OfPart(0.3)
        };
        public static List<Alcohol> DirtyMama = new List<Alcohol>
        {
            Absinthe.OfPart(0.3),
            Limefresh.OfPart(0.4),
            Espresso.OfPart(0.3)
        };
        public static List<Alcohol> MadBecher = new List<Alcohol>
        {
           Absinthe.OfPart(0.5),
           Becherovka.OfPart(0.5)
        };
        public static List<Alcohol> NeboIraka = new List<Alcohol>
        {
            Absinthe.OfPart(0.3),
            Espresso.OfPart(0.7)
        };
        public static List<Alcohol> ElectroNachos = new List<Alcohol>
        {
            Absinthe.OfPart(0.2),
            LimeJuice.OfPart(0.4),
            Mint.OfPart(0.4)
        };
        public static List<Alcohol> Bmw = new List<Alcohol>
        {
            Jamesson.OfPart(0.3),
            Malibu.OfPart(0.4),
            Baylis.OfPart(0.3)
        };
        public static List<Alcohol> SpermBank = new List<Alcohol>
        {
            Tripplesec.OfPart(0.5),
            Baylis.OfPart(0.5)
        };
        public static List<Alcohol> Molotov = new List<Alcohol>
        {
            Mint.OfPart(0.3),
            Tequila.OfPart(0.3),
            Grenadine.OfPart(0.2),
            Tripplesec.OfPart(0.2)
        };
        public static List<Alcohol> Koma = new List<Alcohol>
        {
            Sambuca.OfPart(0.4),
            Kahlua.OfPart(0.3),
            Tripplesec.OfPart(0.3)
        };
        public static List<Alcohol> HeyJhoe = new List<Alcohol>
        {
            Rum.OfPart(0.4),
            Malibu.OfPart(0.5),
            Tobasco.OfPart(0.1)
        };
        public static List<Alcohol> Stels = new List<Alcohol>
        {
            Rum.OfPart(0.2),
            Kahlua.OfPart(0.3),
            Tripplesec.OfPart(0.2),
            Baylis.OfPart(0.3)
        };
        public static List<Alcohol> Medusa = new List<Alcohol>
        {
            Rum.OfPart(0.15),
            Malibu.OfPart(0.3),
            Tripplesec.OfPart(0.3),
            Baylis.OfPart(0.15),
            BlueCurasao.OfPart(0.1)
        };
        public static List<Alcohol> DoubleRada = new List<Alcohol>
        {
            Vodka.OfPart(0.5),
            Espresso.OfPart(0.3),
            Tobasco.OfPart(0.1),
            Limefresh.OfPart(0.3)
        };
        public static List<Alcohol> Audi = new List<Alcohol>
        {
            Sambuca.OfPart(0.25),
            Tequila.OfPart(0.25),
            Tripplesec.OfPart(0.25),
            Malibu.OfPart(0.25)
        };
        public static List<Alcohol> Chika = new List<Alcohol>
        {
            Vodka.OfPart(0.4),
            Limefresh.OfPart(0.3),

            Malibu.OfPart(0.3)
        };
        public static List<Alcohol> DyadyaVanya = new List<Alcohol>
        {
            Vodka.OfPart(0.45),
            Limefresh.OfPart(0.25),
            Grenadine.OfPart(0.3)
        };

        public static List<Alcohol> SlavaUkraine = new List<Alcohol>
        {
            Vodka.OfPart(0.45),
            OrangeJuice.OfPart(0.25),
            BlueCurasao.OfPart(0.3)
        };

        public static List<Alcohol> Precursor = new List<Alcohol>
        {
            Aperol.OfPart(0.35),
            Gin.OfPart(0.15),
            Tripplesec.OfPart(0.2),
            Limefresh.OfPart(0.3)
        };

        public Ingredient(string name, double alco, double part)
            : base(name, alco, part) { }
    }
}