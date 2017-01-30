using System.Collections.Generic;

namespace AlcoholCalculator
{
    internal class Coctails : Ingredient
    {
        public new string Name { get; set; }
        public List<Alcohol> Ingredients { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }

        //public static Coctails OtvertkaCoctails = new Coctails
        //{
        //    Name = "Отвёртка",
        //    Ingredients = Otvertka,
        //    Quantity = 200,
        //    Cost = 30
        //};

        public static Coctails GrMexicanCoctails = new Coctails
        {
            Name = "Зелёный мексиканец",
            Ingredients = GreenMexican,
            Quantity = 60,
            Cost = 35
        };
        public static Coctails GlMexicanCoctails = new Coctails
        {
            Name = "Золотой мексиканец",
            Ingredients = GoldMexican,
            Quantity = 60,
            Cost = 35
        };
        public static Coctails HirosimaCoctails = new Coctails
        {
            Name = "Хиросима",
            Ingredients = Hirosima,
            Quantity = 55,
            Cost = 35
        };
        public static Coctails GoldmilkCoctails = new Coctails
        {
            Name = "Голд милк",
            Ingredients = GoldMilk,
            Quantity = 55,
            Cost = 45
        };

        public static Coctails LobotomiyaCoctails = new Coctails
        {
            Name = "Лоботомия",
            Ingredients = Lobotomiya,
            Quantity = 50,
            Cost = 40
        };

        public static Coctails ReddogCoctails = new Coctails
        {
            Name = "Рыжая собака",
            Ingredients = RedDog,
            Quantity = 50,
            Cost = 40
        };

        public static Coctails TequilahotCoctails = new Coctails
        {
            Name = "Текила Хот",
            Ingredients = TequilaHot,
            Quantity = 50,
            Cost = 40
        };

        public static Coctails ChihuahuaCoctails = new Coctails
        {
            Name = "Чихуа-хуа",
            Ingredients = Chihuahua,
            Quantity = 55,
            Cost = 40
        };

        public static Coctails B53Coctails = new Coctails
        {
            Name = "Б-53",
            Ingredients = B53,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails B52Coctails = new Coctails
        {
            Name = "Б-52",
            Ingredients = B52,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails DirtyMamaCoctails = new Coctails
        {
            Name = "Грязная мама",
            Ingredients = DirtyMama,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails MadBecherCoctails = new Coctails
        {
            Name = "Бешеный бехер",
            Ingredients = MadBecher,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails NeboIrakaCoctails = new Coctails
        {
            Name = "Небо Ирака",
            Ingredients = NeboIraka,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails ElectronachosCoctails = new Coctails
        {
            Name = "Электроначос",
            Ingredients = ElectroNachos,
            Quantity = 50,
            Cost = 35
        };
        public static Coctails BMWCoctails = new Coctails
        {
            Name = "БМВ",
            Ingredients = Bmw,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails SpermbankCoctails = new Coctails
        {
            Name = "Банк спермы",
            Ingredients = SpermBank,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails MolotovCoctails = new Coctails
        {
            Name = "Молотов",
            Ingredients = Molotov,
            Quantity = 50,
            Cost = 35
        };
        public static Coctails KomaCoctails = new Coctails
        {
            Name = "Кома",
            Ingredients = Koma,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails HeyJhoeCoctails = new Coctails
        {
            Name = "Эй Джо",
            Ingredients = HeyJhoe,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails StelsCoctails = new Coctails
        {
            Name = "Стелс",
            Ingredients = Stels,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails MedusaCoctails = new Coctails
        {
            Name = "Медуза",
            Ingredients = Medusa,
            Quantity = 60,
            Cost = 30
        };
        public static Coctails DoubleradaCoctails = new Coctails
        {
            Name = "Дабл Рада",
            Ingredients = DoubleRada,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails AudiCoctails = new Coctails
        {
            Name = "Ауди",
            Ingredients = Audi,
            Quantity = 60,
            Cost = 30
        }; public static Coctails ChikaCoctails = new Coctails
        {
            Name = "Чика",
            Ingredients = Chika,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails DyadyavanyaCoctails = new Coctails
        {
            Name = "Дядя Ваня",
            Ingredients = DyadyaVanya,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails SvalaUkraineCoctails = new Coctails
        {
            Name = "Слава Украине",
            Ingredients = SlavaUkraine,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails PrecursorCoctails = new Coctails
        {
            Name = "Прекурсор",
            Ingredients = Precursor,
            Quantity = 50,
            Cost = 30
        };

        public static List<Coctails> list = new List<Coctails>
        {
            GrMexicanCoctails,
            GlMexicanCoctails,
            HirosimaCoctails,
            GoldmilkCoctails,
            LobotomiyaCoctails,
            ReddogCoctails,
            TequilahotCoctails,
            ChihuahuaCoctails,
            B53Coctails,
            B52Coctails,
            DirtyMamaCoctails,
            MadBecherCoctails,
            NeboIrakaCoctails,
            ElectronachosCoctails,
            BMWCoctails,
            SpermbankCoctails,
            MolotovCoctails,
            KomaCoctails,
            HeyJhoeCoctails,
            AudiCoctails,
            DoubleradaCoctails,
            MedusaCoctails,
            StelsCoctails,
            ChikaCoctails,
            DyadyavanyaCoctails,
            SvalaUkraineCoctails,
            PrecursorCoctails
        };

        public Coctails(string name, double alco, double part)
            : base(name, alco, part) {}
        public Coctails()
            : base("", 0, 0) {}
    }
}