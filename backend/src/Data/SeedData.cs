using FormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormAPI.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<UserEntity>().HasData(new List<UserEntity>
        {
            new UserEntity
            {
                Id = 1,
                Email = "a@a.com",
                Password = "12345678",
                Organization = "A.com"
            },
            new UserEntity
            {
                Id = 2,
                Email = "johnny@testepartementet.no",
                Password = "johnny123",
                Organization = "Testdepartementet"
            },
            new UserEntity
            {
                Id = 3,
                Email = "test@test.com",
                Password = "12345678",
                Organization = ""
            }
        });

        builder.Entity<FormEntity>().HasData(new List<FormEntity>
        {
            new FormEntity()
            {
                Id = Guid.NewGuid(),
                User = "user1@example.com",
                Organization = "Org1",
                Title = "Test Survey",
                Description = "This form was created as a test.",
                Status = "draft",
                Published = null,
                Expires = null,
                Components = null
            }
        });
    }
}