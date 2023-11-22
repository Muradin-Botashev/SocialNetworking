using FluentMigrator;
using SocialNetworking.Models.Entities;

namespace SocialNetworking.Storages.Migrations
{
    [Migration(2023100701)]
    public class InitialMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("users");
        }

        public override void Up()
        {
            Create.Table("users")
                .WithColumn(nameof(User.Id).ToLowerInvariant()).AsInt32().PrimaryKey().Identity()
                .WithColumn(nameof(User.Age).ToLowerInvariant()).AsInt32()
                .WithColumn(nameof(User.Birthdate).ToLowerInvariant()).AsDateTime()
                .WithColumn(nameof(User.FirstName).ToLowerInvariant()).AsString()
                .WithColumn(nameof(User.SecondName).ToLowerInvariant()).AsString()
                .WithColumn(nameof(User.Biography).ToLowerInvariant()).AsString()
                .WithColumn(nameof(User.City).ToLowerInvariant()).AsString()
                .WithColumn(nameof(User.PasswordHash).ToLowerInvariant()).AsString();
        }
    }
}