using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDBContext(serviceProvider.GetRequiredService<DbContextOptions<AppDBContext>>()))
            {
                if (context.spongeBobFriends.Any())
                {
                    return;
                }


                context.spongeBobFriends.AddRange(
                    new SpongeBobFriends
                    {
                        FirstName = "user1@user.com",
                        LastName = "qwerty123",
                        Job = "Smith",
                        JobPlace = "Male",
                        SkinCollor = "",
                        HomeId ="",
                    },
                    new SpongeBobFriends
                    {
                        FirstName = "user1@user.com",
                        LastName = "qwerty123",
                        Job = "Smith",
                        JobPlace = "Male",
                        SkinCollor = "",
                        HomeId = "",
                    },
                    new SpongeBobFriends
                    {
                        FirstName = "user1@user.com",
                        LastName = "qwerty123",
                        Job = "Smith",
                        JobPlace = "Male",
                        SkinCollor = "",
                        HomeId = "",
                    },
                    new SpongeBobFriends
                    {
                        FirstName = "user1@user.com",
                        LastName = "qwerty123",
                        Job = "Smith",
                        JobPlace = "Male",
                        SkinCollor = "",
                        HomeId = "",
                    }
                    );

                context.SaveChanges();
            }

        }

    }
}
