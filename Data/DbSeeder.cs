using System;
using System.IO;
using System.Linq;
using TouristGuide.Models;

namespace TouristGuide.Data;

public static class DbSeeder
{
    private static string ImgPath(string name) =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", name);

    public static void Seed()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        if (db.Cities.Any()) return;

        var moscow = new City
        {
            Name = "Москва",
            Region = "Московская область",
            Population = 13274285,
            History = "Москва — столица России, основана в 1147 году князем Юрием Долгоруким. Крупнейший город страны.",
            CoatOfArms = ImgPath("coat-moscow.jpg"),
            Photo = ImgPath("moscow.jpg")
        };
        moscow.Attractions.Add(new Attraction
        {
            Name = "Красная площадь",
            Description = "Главная площадь Москвы и России.",
            History = "Известна с XV века. Расположены Кремль, храм Василия Блаженного, мавзолей Ленина и ГУМ.",
            Photo = ImgPath("red-square.jpg"),
            WorkingHours = "Круглосуточно",
            Price = "Бесплатно"
        });
        moscow.Attractions.Add(new Attraction
        {
            Name = "Третьяковская галерея",
            Description = "Крупнейший музей русского изобразительного искусства.",
            History = "Основана в 1856 году купцом Павлом Третьяковым. Более 200 000 произведений.",
            Photo = ImgPath("tretyakov.jpg"),
            WorkingHours = "Вт-Вс 10:00-18:00, Чт 10:00-21:00",
            Price = "500 руб."
        });

        var spb = new City
        {
            Name = "Санкт-Петербург",
            Region = "Ленинградская область",
            Population = 5652922,
            History = "Основан Петром I в 1703 году. Был столицей Российской империи более двухсот лет.",
            CoatOfArms = ImgPath("coat-spb.jpg"),
            Photo = ImgPath("spb.jpg")
        };
        spb.Attractions.Add(new Attraction
        {
            Name = "Эрмитаж",
            Description = "Один из крупнейших музеев мира.",
            History = "Основан в 1764 году Екатериной II. Около 3 миллионов экспонатов.",
            Photo = ImgPath("hermitage.jpg"),
            WorkingHours = "Вт-Вс 10:30-18:00, Ср 10:30-21:00",
            Price = "500 руб."
        });
        spb.Attractions.Add(new Attraction
        {
            Name = "Петропавловская крепость",
            Description = "Историческое ядро Санкт-Петербурга.",
            History = "Заложена 27 мая 1703 года. Старейшее сооружение города.",
            Photo = ImgPath("peter-paul.jpg"),
            WorkingHours = "Ежедневно 10:00-18:00",
            Price = "350 руб."
        });

        var kazan = new City
        {
            Name = "Казань",
            Region = "Республика Татарстан",
            Population = 1329825,
            History = "Столица Республики Татарстан, основана в 1005 году. Крупный культурный центр России.",
            CoatOfArms = ImgPath("coat-kazan.jpg"),
            Photo = ImgPath("kazan.jpg")
        };
        kazan.Attractions.Add(new Attraction
        {
            Name = "Казанский Кремль",
            Description = "Древнейшая часть Казани, объект ЮНЕСКО.",
            History = "Построен в X-XVI веках. Включает мечеть Кул-Шариф и Благовещенский собор.",
            Photo = ImgPath("kazan-kremlin.jpg"),
            WorkingHours = "Ежедневно 8:00-18:00",
            Price = "Бесплатно"
        });

        db.Cities.AddRange(moscow, spb, kazan);
        db.SaveChanges();
    }
}
