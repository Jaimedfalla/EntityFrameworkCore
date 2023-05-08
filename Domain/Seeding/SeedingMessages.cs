using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Domain.Seeding;

public static class SeedingMessages
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        Person felipe = new(){
            Id=1,
            Name ="Felipe"
        };
        Person claudia = new(){
            Id=2,
            Name ="Claudia"
        };

        Domain.Entities.Message msg1 = new(){Id=1,Content="Hola Claudia", EmittingId = felipe.Id, RecipientId = claudia.Id};
        Domain.Entities.Message msg2 = new(){Id=2,Content="Hola Felipe, ¿Como te va?", EmittingId = claudia.Id, RecipientId = felipe.Id};
        Domain.Entities.Message msg3 = new(){Id=3,Content="Todo bien, ¿Y tu?", EmittingId = felipe.Id, RecipientId = claudia.Id};
        Domain.Entities.Message msg4 = new(){Id=4,Content="Muy bien :)", EmittingId = claudia.Id, RecipientId = felipe.Id};

        modelBuilder.Entity<Person>().HasData(felipe);
        modelBuilder.Entity<Person>().HasData(claudia);

        modelBuilder.Entity<Message>().HasData(msg1,msg2,msg3,msg4);
    }
}