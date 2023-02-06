using Microsoft.EntityFrameworkCore;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL
{
    public class SeedDb
    {
        public static void Seed()
        {
            var context = new DbContextSellCar();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Region.Count() == 0)
                {
                    for (int i = 0; i < region.Length; i++)
                    {
                        context.Region.Add(region[i]);
                    }
                    context.SaveChanges();
                }
                if (context.Car.Count() == 0)
                {
                    for (int i = 0; i < cars.Length; i++)
                    {
                        context.Car.Add(cars[i]);
                        context.SaveChanges();
                    }

                }
                if (context.Ads.Count() == 0)
                {
                    for (int i = 0; i < ads.Length; i++)
                    {
                        context.Ads.Add(ads[i]);
                    }
                    context.SaveChanges();
                }
                if (context.Picture.Count() == 0)
                {
                    for (int i = 0; i < picture.Length; i++)
                    {
                        context.Picture.Add(picture[i]);
                    }
                    context.SaveChanges();
                }

            }
        }
        private static Region[] region =
        {
            new Region(){Name="Brest"},
            new Region(){Name="Vitebsk"},
            new Region(){Name="Gomel"},
            new Region(){Name="Grodno"},
            new Region(){Name="Minsk region"},
            new Region(){Name="Minsk"},
            new Region(){Name="Mogilev"},


        };
        private static Car[] cars =
        {
            new Car(){Name="Alfa Romeo",Url="alfa-romeo"},
            new Car(){Name="Alpine",Url="alpine",},
            new Car(){Name="Anadol",Url="anadol"},
            new Car(){Name="Aston Martin",Url="aston-martin"},
            new Car(){Name="Audi",Url="audi"},
            new Car(){Name="Bentley",Url="bentley"},
            new Car(){Name="BMW",Url="bmw"},
            new Car(){Name="Bugatti",Url="bugatti"},
            new Car(){Name="Buick",Url="buic"},
            new Car(){Name="CNamellac",Url="cNamellac"},
            new Car(){Name="Caterham",Url="caterham"},
            new Car(){Name="Chery",Url="chery"},
            new Car(){Name="Chevrolet",Url="chevrolet"},
            new Car(){Name="Chrysler",Url="chrysler"},
            new Car(){Name="Citroen",Url="citroen"},
            new Car(){Name="Dacia",Url="dacia"},
            new Car(){Name="Daewoo",Url="daewoo"},
            new Car(){Name="Daihatsu",Url="daihatsu"},
            new Car(){Name="Dodge",Url="dodge"},
            new Car(){Name="Ferrari",Url="ferrari"},
            new Car(){Name="Fiat",Url="fiat"},
            new Car(){Name="Ford",Url="ford"},
            new Car(){Name="Geely",Url="geely"},
            new Car(){Name="Honda",Url="honda"},
            new Car(){Name="Hyundai",Url="hyundai"},
            new Car(){Name="Infiniti",Url="infiniti"},
            new Car(){Name="Isuzu",Url="ısuzu"},
            new Car(){Name="Jaguar",Url="jaguar"},
            new Car(){Name="Kia",Url="kia"},
            new Car(){Name="Lada",Url="lada"},
            new Car(){Name="Lamborghini",Url="lamborghini"},
            new Car(){Name="Lancia",Url="lancia"},
            new Car(){Name="Lexus",Url="lexus"},
            new Car(){Name="Lincoln",Url="lincoln"},
            new Car(){Name="Lotus",Url="lotus"},
            new Car(){Name="Marcos",Url="marcos"},
            new Car(){Name="Maserati",Url="maserati"},
            new Car(){Name="Mazda",Url="mazda"},
            new Car(){Name="McLaren",Url="mclaren"},
            new Car(){Name="Mercedes Benz",Url="mercedes-benz"},
            new Car(){Name="MG",Url="mg"},
            new Car(){Name="Mini",Url="mini"},
            new Car(){Name="Mitsubishi",Url="mitsubishi"},
            new Car(){Name="Nissan",Url="nissan"},
            new Car(){Name="Oldsmobile",Url="oldsmobile"},
            new Car(){Name="Opel",Url="opel"},
            new Car(){Name="Peugeot",Url="peugot"},
            new Car(){Name="Plymouth",Url="plymouth"},
            new Car(){Name="Pontiac",Url="pontiac"},
            new Car(){Name="Porsche",Url="porsche"},
            new Car(){Name="Proton",Url="proton"},
            new Car(){Name="Renault",Url="renault"},
            new Car(){Name="Rolls Royce",Url="rolls-royce"},
            new Car(){Name="Rover",Url="rover"},
            new Car(){Name="Saab",Url="saab"},
            new Car(){Name="Seat",Url="seat"},
            new Car(){Name="Skoda",Url="skoda"},
            new Car(){Name="Smart",Url="smart"},
            new Car(){Name="Subaru",Url="subaru"},
            new Car(){Name="Suzuki",Url="suzuki"},
            new Car(){Name="Tesla",Url="tesla"},
            new Car(){Name="Toyota",Url="toyota"},
            new Car(){Name="Volkswagen",Url="volkswagen"},
            new Car(){Name="Volvo",Url="volvo"},

        };
        private static Ads[] ads =
         {
            new Ads(){title="Tesla Plaid",Detail="Model X PLAID 1020.",DateCreate=DateTime.Now,Brand="Tesla",Model="Plaid",year=2022,FuelType="Electro",GearType="automatic",NumberOfGear=3,Mileage=168368,BodyType="Coupe",NumberOfDoors=5,MotorPower=1020,EngineСapacity=2198 ,MaxSpeed=222 ,Acceleration=8.6,TractionType="Rear Drive",ConsumptionСity=13,OutofCityConsumption=7.3,AverageConsumption=9.4,FuelTankVolume=70,Color="Red",FromWho="Сar showroom",Swap="No",Status="Second owner",HomePage=false,CarId=61,AdsId=1,RegionId=6,Price=50000,UserId="1"},
            new Ads(){title="2003 BMW Z4",Detail="Selling Stance-project based on BMW Z4.Candy red color (repainted 5000km ago);",DateCreate=DateTime.Now,RegionId=1,Brand="BMW",Model="Z4 ",year=2003,FuelType="Gas",GearType="automatic",NumberOfGear=3,Mileage=77250,BodyType="Cabrio",NumberOfDoors=2,MotorPower=184,EngineСapacity=1997 ,MaxSpeed=232 ,Acceleration=7.2,TractionType="Rear Drive",ConsumptionСity=9.1,OutofCityConsumption=5.5,AverageConsumption=6.8,FuelTankVolume=55,Color="Red",FromWho="Dealer",Swap="Yes",Status="First owner",HomePage=true,CarId=7,AdsId=2,Price=20000,UserId="1"},
            new Ads(){title="Toyota GT 86",Detail="The car is in excellent condition. No problem, no run across the CIS.",DateCreate=DateTime.Now,RegionId=5,Brand="Toyota",Model="GT",year=2018,FuelType="Gas",GearType="Mechanical",NumberOfGear=5,Mileage=149,BodyType="Coupe",NumberOfDoors=3,MotorPower=200,EngineСapacity=3982 ,MaxSpeed=318 ,Acceleration=3.6,TractionType="Rear Drive",ConsumptionСity=15.1,OutofCityConsumption=9.0,AverageConsumption=11.4,FuelTankVolume=65,Color="Grey",FromWho="Person",Swap="Yes",Status="Third owner",HomePage=true,CarId=62,AdsId=3,Price=25000,UserId="1"},
            new Ads(){title="AUDI 2019 A7",Detail="50 TDI 3.0 diesel 286 hp Trouble-free!",DateCreate=DateTime.Now,RegionId=7,Brand="Audi",Model="3.0 TDI",year=2019,FuelType="Dizel",GearType="Mechanical",NumberOfGear=6,Mileage=16747,BodyType="Sedan",NumberOfDoors=5,MotorPower=400,EngineСapacity=3001 ,MaxSpeed=256 ,Acceleration=7.2,TractionType="Rear Drive",ConsumptionСity=9.1,OutofCityConsumption=5.5,AverageConsumption=6.8,FuelTankVolume=65,Color="Purple",FromWho="Person",Swap="No",Status="First owner",HomePage=true,CarId=5,AdsId=4,Price=30000,UserId="1"},
            new Ads(){title="Ford Mustang GT",Detail="Ford Mustang GT Supercharger in almost the maximum configuration PP1 (performance package 1).",DateCreate=DateTime.Now,RegionId=6,Brand="Mustang",Model="4.0",year=2018,FuelType="Gas",GearType="Mechanical",NumberOfGear=8,Mileage=118000,BodyType="Coupe",NumberOfDoors=3,MotorPower=540,EngineСapacity=4000 ,MaxSpeed=247 ,Acceleration=6.2,TractionType="Rear Drive",ConsumptionСity=9.1,OutofCityConsumption=5.5,AverageConsumption=6.8,FuelTankVolume=60,Color="Black",FromWho="Person",Swap="Yes",Status="First owner",HomePage=true,CarId=22,AdsId=5,Price=40000,UserId="1"},

        };

        private static Picture[] picture =
        {
            new Picture() { Url = "1.jpg", AdsId = 1 },
            new Picture() { Url = "2.jpg", AdsId = 1 },
            new Picture() { Url = "3.jpg", AdsId = 1 },
            new Picture() { Url = "4.jpg", AdsId = 1 },
            new Picture() { Url = "5.jpg", AdsId = 1 },

            new Picture() { Url = "6.jpg", AdsId = 2 },
            new Picture() { Url = "7.jpg", AdsId = 2 },
            new Picture() { Url = "8.jpg", AdsId = 2 },
            new Picture() { Url = "9.jpg", AdsId = 2 },
            new Picture() { Url = "10.jpg", AdsId = 2 },

            new Picture() { Url = "11.jpg", AdsId = 3 },
            new Picture() { Url = "12.jpg", AdsId = 3 },
            new Picture() { Url = "13.jpg", AdsId = 3 },
            new Picture() { Url = "14.jpg", AdsId = 3 },
            new Picture() { Url = "15.jpg", AdsId = 3 },

            new Picture() { Url = "16.jpg", AdsId = 4 },
            new Picture() { Url = "17.jpg", AdsId = 4 },
            new Picture() { Url = "18.jpg", AdsId = 4 },
            new Picture() { Url = "19.jpg", AdsId = 4 },
            new Picture() { Url = "20.jpg", AdsId = 4 },

            new Picture() { Url = "21.jpg", AdsId = 5 },
            new Picture() { Url = "22.jpg", AdsId = 5 },
            new Picture() { Url = "23.jpg", AdsId = 5 },
            new Picture() { Url = "24.jpg", AdsId = 5 },
            new Picture() { Url = "25.jpg", AdsId = 5 },
        };
    }
}

