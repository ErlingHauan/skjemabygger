using FormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormAPI.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<UserEntity>().HasData(new List<UserEntity>
        {
            new()
            {
                Id = 1,
                Email = "a@a.com",
                Password = "12345678",
                Organization = "A.com"
            },
            new()
            {
                Id = 2,
                Email = "johnny@testepartementet.no",
                Password = "johnny123",
                Organization = "Testdepartementet"
            },
            new()
            {
                Id = 3,
                Email = "test@test.com",
                Password = "12345678",
                Organization = ""
            }
        });

        var componentList = new List<FormComponent>
        {
            new()
            {
                Name = "question1",
                Label = "Question 1",
                Required = true,
                Order = 0,
                Type = "textfield"
            },

            new()
            {
                Name = "question2",
                Label = "Question 2",
                Required = true,
                Order = 1,
                Type = "radio",
                RadioChoices = ["Yes", "No", "Maybe"],
            }
        };

        builder.Entity<FormEntity>().HasData(new List<FormEntity>
        {
            new()
            {
                Id = new Guid("f7795736-611b-4951-a1f1-f9992b236718"),
                User = "user1@example.com",
                Organization = "Org1",
                Title = "Test Survey",
                Description = "This form was created as a test.",
                Status = "Draft",
                Published = null,
                Expires = null,
                Components = componentList
            }
        });

        var responseList = new List<SubmissionResponse>
        {
            new()
            {
                Name = "question1",
                Label = "Question 1",
                Order = 0,
                Response = "Yes, I agree"
            },

            new()
            {
                Name = "question2",
                Label = "Question 2",
                Order = 1,
                Response = "No"
            }
        };

        builder.Entity<SubmissionEntity>().HasData(new List<SubmissionEntity>
        {
            new()
            {
                Id = Guid.NewGuid(),
                FormId = new Guid("f7795736-611b-4951-a1f1-f9992b236718"),
                Submitted = DateTimeOffset.UtcNow,
                Responses = responseList
            },

            new()
            {
                Id = Guid.NewGuid(),
                FormId = new Guid("f7795736-611b-4951-a1f1-f9992b236718"),
                Submitted = DateTimeOffset.UtcNow,
                Responses = responseList
            }
        });
    }
}