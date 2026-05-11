using GameClub.Domain.Enums;
using LinqToDB.Mapping;

namespace GameClub.Domain.Entities
{
    /// <summary>
    /// Сущность "Пользователь"
    /// </summary>
    [Table(Name = "Users")]
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Column(Name = "UserId", IsPrimaryKey = true, IsIdentity = true)]
        public int UserId { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [Column(Name = "Login")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Column(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Строковое значение роли для маппинга в БД
        /// </summary>
        [Column(Name = "UserRole")]
        public string UserRoleValue { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public UserRole UserRole
        {
            get => Enum.Parse<UserRole>(UserRoleValue);
            set => UserRoleValue = value.ToString();
        }

        /// <summary>
        /// Полное имя
        /// </summary>
        [Column(Name = "FullName")]
        public string FullName { get; set; }
    }
}