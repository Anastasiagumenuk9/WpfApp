namespace WpfApp.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Rend : DbContext
    {
        // Контекст настроен для использования строки подключения "Rend" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WpfApp.Model.Rend" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Rend" 
        // в файле конфигурации приложения.
        public Rend()
            : base("name=Rend")
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet <Locations> Location { get; set; }
        public DbSet<Lease> Lease { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<PromotionCar> PromotionCar { get; set; }
        public DbSet<Transmission> Transmission { get; set; }
        public DbSet<ClassCar> ClassCar { get; set; }
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}