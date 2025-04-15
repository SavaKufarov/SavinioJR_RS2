using BusinessLayer;
using DataLayer;
using DataLayer.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;

namespace TestLayer;

[TestFixture]
public class TestManager
{
    internal static PeopleIntrestDbContext dbContext;

    static TestManager()
    {
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseInMemoryDatabase("TestingDb");
        dbContext = new PeopleIntrestDbContext(builder.Options);
    }

    [OneTimeTearDown]
    public void Dispose()
    {
        dbContext.Dispose();
    }
}
