using System.Linq;
using TouristGuide.Models;

namespace TouristGuide.Data;

public static class DbSeeder
{
    public static void Seed()
    {
        using var db = new AppDbContext();
        db.Database.EnsureCreated();

        if (db.Cities.Any()) return;

        var moscow = new City
        {
            Name = "Москва",
            Region = "Московская область",
            Population = 13100000,
            History = "Москва — столица России, основана в 1147 году.",
            CoatOfArms = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Coat_of_Arms_of_Moscow.svg/200px-Coat_of_Arms_of_Moscow.svg.png",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Moscow_Kremlin_from_Bolshoy_Kamenny_bridge_%28cropped%29.jpg/800px-Moscow_Kremlin_from_Bolshoy_Kamenny_bridge_%28cropped%29.jpg"
        };
        moscow.Attractions.Add(new Attraction
        {
            Name = "Красная площадь",
            Description = "Главная площадь Москвы и России.",
            History = "Известна с XV века, название закрепилось в XVII веке.",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f7/Red_Square_Moscow.jpg/800px-Red_Square_Moscow.jpg",
            WorkingHours = "Круглосуточно",
            Price = "Бесплатно"
        });
        moscow.Attractions.Add(new Attraction
        {
            Name = "Третьяковская галерея",
            Description = "Крупнейший музей русского изобразительного искусства.",
            History = "Основана в 1856 году купцом Павлом Третьяковым.",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/Tretyakov_Gallery%2C_Moscow%2C_Russia.jpg/800px-Tretyakov_Gallery%2C_Moscow%2C_Russia.jpg",
            WorkingHours = "Вт-Вс 10:00-18:00, Чт 10:00-21:00",
            Price = "500 руб."
        });

        var spb = new City
        {
            Name = "Санкт-Петербург",
            Region = "Ленинградская область",
            Population = 5600000,
            History = "Санкт-Петербург основан Петром I в 1703 году.",
            CoatOfArms = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Coat_of_Arms_of_Saint_Petersburg_%282003%29.svg/200px-Coat_of_Arms_of_Saint_Petersburg_%282003%29.svg.png",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/72/Saint_Petersburg_Montage_2023.jpg/800px-Saint_Petersburg_Montage_2023.jpg"
        };
        spb.Attractions.Add(new Attraction
        {
            Name = "Эрмитаж",
            Description = "Один из крупнейших музеев мира.",
            History = "Основан в 1764 году Екатериной II.",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/Hermitage_Museum%2C_Saint_Petersburg%2C_Russia.jpg/800px-Hermitage_Museum%2C_Saint_Petersburg%2C_Russia.jpg",
            WorkingHours = "Вт-Вс 10:30-18:00, Ср 10:30-21:00",
            Price = "500 руб."
        });
        spb.Attractions.Add(new Attraction
        {
            Name = "Петропавловская крепость",
            Description = "Историческое ядро Санкт-Петербурга.",
            History = "Заложена 27 мая 1703 года.",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6c/Peter_and_Paul_Fortress_in_SPB_03.jpg/800px-Peter_and_Paul_Fortress_in_SPB_03.jpg",
            WorkingHours = "Ежедневно 10:00-18:00",
            Price = "350 руб."
        });

        var kazan = new City
        {
            Name = "Казань",
            Region = "Республика Татарстан",
            Population = 1308000,
            History = "Казань — столица Республики Татарстан, основана в 1005 году.",
            CoatOfArms = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Coat_of_Arms_of_Kazan.svg/200px-Coat_of_Arms_of_Kazan.svg.png",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Kazan_city_montage_2023.jpg/800px-Kazan_city_montage_2023.jpg"
        };
        kazan.Attractions.Add(new Attraction
        {
            Name = "Казанский Кремль",
            Description = "Древнейшая часть Казани, объект ЮНЕСКО.",
            History = "Построен в X-XVI веках.",
            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Kazan_Kremlin_exterior_view.jpg/800px-Kazan_Kremlin_exterior_view.jpg",
            WorkingHours = "Ежедневно 8:00-18:00",
            Price = "Бесплатно (территория)"
        });

        db.Cities.AddRange(moscow, spb, kazan);
        db.SaveChanges();
    }
}
