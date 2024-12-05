using System;

namespace CarBook.Domain.Entities;

public class UserRole
{
    public int Id { get; set; }
    public string UserRoleName { get; set; }
    public List<User> Users { get; set; }
}
