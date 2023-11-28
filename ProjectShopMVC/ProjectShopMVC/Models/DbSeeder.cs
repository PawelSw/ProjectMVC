namespace ProjectShopMVC.Models
{
    public class DbSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ProjectDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ProjectDbContext>();


            if (!context.Projects.Any())
            {
                context.AddRange
                (
                 new Project { Name = "Home 1", Price = 123, ShortDescription = "Energy saving, modern home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/1small.jpg", InStock = true, IsProjectOfTheWeek = true, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/1small.jpg" },
                   new Project { Name = "Home 2", Price = 233, ShortDescription = "Comfortable, modern home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/2small.jpg", InStock = true, IsProjectOfTheWeek = false, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/2small.jpg" },
                   new Project { Name = "Home 3", Price = 244, ShortDescription = "Classic home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/3small.jpg", InStock = true, IsProjectOfTheWeek = true, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/3small.jpg" },
                   new Project { Name = "Home 4", Price = 444, ShortDescription = "Peaceful, modern home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/1small.jpg", InStock = true, IsProjectOfTheWeek = true, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/1small.jpg" },
                   new Project { Name = "Home 5", Price = 121, ShortDescription = "Modest, comfortable home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/2small.jpg", InStock = true, IsProjectOfTheWeek = false, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/2small.jpg" },
                   new Project { Name = "Home 6", Price = 244, ShortDescription = "High class, modern home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/3small.jpg", InStock = true, IsProjectOfTheWeek = true, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/3small.jpg" },
                   new Project { Name = "Home 7", Price = 121, ShortDescription = "Basic, small home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/2small.jpg", InStock = true, IsProjectOfTheWeek = false, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/2small.jpg" },
                   new Project { Name = "Home 8", Price = 456, ShortDescription = "Advanced technology, modern home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/3small.jpg", InStock = true, IsProjectOfTheWeek = true, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/3small.jpg" },
                   new Project { Name = "Home 9", Price = 567, ShortDescription = "One floor, modern home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/1small.jpg", InStock = true, IsProjectOfTheWeek = false, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/1small.jpg" },
                   new Project { Name = "Home 10", Price = 441, ShortDescription = "Two floors, modern home for family.", LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", ImageUrl = "https://nitotechnika.com.pl/pictures/2small.jpg", InStock = true, IsProjectOfTheWeek = true, ImageThumbnailUrl = "https://nitotechnika.com.pl/pictures/2small.jpg" }
                );
            }

            context.SaveChanges();
        }

    }
}
