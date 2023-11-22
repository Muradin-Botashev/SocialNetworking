using Dapper;
using Npgsql;
using SocialNetworking.Extensions;
using SocialNetworking.Models.Entities;

namespace SocialNetworking.Storages.UserStorage
{
    public class UserStorage : IUserStorage
    {
        private readonly NpgsqlConnection _connection;

        public UserStorage(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<User> FindByIdAsync(int id)
        {
            var sql = $@"SELECT
                             {nameof(User.Id)},
                             {nameof(User.FirstName)},
                             {nameof(User.SecondName)},
                             {nameof(User.Biography)},
                             {nameof(User.City)},
                             {nameof(User.PasswordHash)},
                             {nameof(User.Age)},
                             {nameof(User.Birthdate)}
                         FROM
                             public.users
                         where
                             id = {id};";

            var result = await _connection.QueryFirstOrDefaultAsync<User>(sql);
            return result;
        }

        public async Task<User> CreateAsync(User user)
        {
            var sql = $@"INSERT INTO
                            public.users (
                                {nameof(User.FirstName)},
                                {nameof(User.SecondName)},
                                {nameof(User.Biography)},
                                {nameof(User.City)},
                                {nameof(User.PasswordHash)},
                                {nameof(User.Age)},
                                {nameof(User.Birthdate)}
                            )
                        VALUES
                            (
                                '{user.FirstName}',
                                '{user.SecondName}',
                                '{user.Biography}',
                                '{user.City}',
                                '{user.PasswordHash}',
                                {user.Age},
                                '{user.Birthdate.ToDbDateTime()}'
                            )
                        RETURNING *;";
            var result = await _connection.QueryFirstOrDefaultAsync<User>(sql);
            return result;
        }
    }
}