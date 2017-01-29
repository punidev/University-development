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
        //    Name = "�������",
        //    Ingredients = Otvertka,
        //    Quantity = 200,
        //    Cost = 30
        //};

        public static Coctails GrMexicanCoctails = new Coctails
        {
            Name = "������ ����������",
            Ingredients = GreenMexican,
            Quantity = 60,
            Cost = 35
        };
        public static Coctails GlMexicanCoctails = new Coctails
        {
            Name = "������� ����������",
            Ingredients = GoldMexican,
            Quantity = 60,
            Cost = 35
        };
        public static Coctails HirosimaCoctails = new Coctails
        {
            Name = "��������",
            Ingredients = Hirosima,
            Quantity = 55,
            Cost = 35
        };
        public static Coctails GoldmilkCoctails = new Coctails
        {
            Name = "���� ����",
            Ingredients = GoldMilk,
            Quantity = 55,
            Cost = 45
        };

        public static Coctails LobotomiyaCoctails = new Coctails
        {
            Name = "���������",
            Ingredients = Lobotomiya,
            Quantity = 50,
            Cost = 40
        };

        public static Coctails ReddogCoctails = new Coctails
        {
            Name = "����� ������",
            Ingredients = RedDog,
            Quantity = 50,
            Cost = 40
        };

        public static Coctails TequilahotCoctails = new Coctails
        {
            Name = "������ ���",
            Ingredients = TequilaHot,
            Quantity = 50,
            Cost = 40
        };

        public static Coctails ChihuahuaCoctails = new Coctails
        {
            Name = "�����-���",
            Ingredients = Chihuahua,
            Quantity = 55,
            Cost = 40
        };

        public static Coctails B53Coctails = new Coctails
        {
            Name = "�-53",
            Ingredients = B53,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails B52Coctails = new Coctails
        {
            Name = "�-52",
            Ingredients = B52,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails DirtyMamaCoctails = new Coctails
        {
            Name = "������� ����",
            Ingredients = DirtyMama,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails MadBecherCoctails = new Coctails
        {
            Name = "������� �����",
            Ingredients = MadBecher,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails NeboIrakaCoctails = new Coctails
        {
            Name = "���� �����",
            Ingredients = NeboIraka,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails ElectronachosCoctails = new Coctails
        {
            Name = "������������",
            Ingredients = ElectroNachos,
            Quantity = 50,
            Cost = 35
        };
        public static Coctails BMWCoctails = new Coctails
        {
            Name = "���",
            Ingredients = Bmw,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails SpermbankCoctails = new Coctails
        {
            Name = "���� ������",
            Ingredients = SpermBank,
            Quantity = 50,
            Cost = 35
        };

        public static Coctails MolotovCoctails = new Coctails
        {
            Name = "�������",
            Ingredients = Molotov,
            Quantity = 50,
            Cost = 35
        };
        public static Coctails KomaCoctails = new Coctails
        {
            Name = "����",
            Ingredients = Koma,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails HeyJhoeCoctails = new Coctails
        {
            Name = "�� ���",
            Ingredients = HeyJhoe,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails StelsCoctails = new Coctails
        {
            Name = "�����",
            Ingredients = Stels,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails MedusaCoctails = new Coctails
        {
            Name = "������",
            Ingredients = Medusa,
            Quantity = 60,
            Cost = 30
        };
        public static Coctails DoubleradaCoctails = new Coctails
        {
            Name = "���� ����",
            Ingredients = DoubleRada,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails AudiCoctails = new Coctails
        {
            Name = "����",
            Ingredients = Audi,
            Quantity = 60,
            Cost = 30
        }; public static Coctails ChikaCoctails = new Coctails
        {
            Name = "����",
            Ingredients = Chika,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails DyadyavanyaCoctails = new Coctails
        {
            Name = "���� ����",
            Ingredients = DyadyaVanya,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails SvalaUkraineCoctails = new Coctails
        {
            Name = "����� �������",
            Ingredients = SlavaUkraine,
            Quantity = 50,
            Cost = 30
        };
        public static Coctails PrecursorCoctails = new Coctails
        {
            Name = "���������",
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