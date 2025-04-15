using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class UserContext : IDb<User, int>
    {
        private PeopleIntrestDbContext dbContext;
        public UserContext(PeopleIntrestDbContext appContext)
        {
            dbContext = appContext;
        }
        public void Create(User item)
        {
            dbContext.Users.Add(item);
            dbContext.SaveChanges();
        }
        public User Read(int id, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<User> query = dbContext.Users;
            if (useNavigationalProperties)
            {
                query = query.Include(u => u.Friends).Include(u => u.Interests);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            User user = query.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }
        public List<User> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<User> query = dbContext.Users;
            if (useNavigationalProperties)
            {
                query = query.Include(u => u.Friends).Include(u => u.Interests);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return query.ToList();
        }
        public void Update(User user, bool useNavigationalProperties = false)
        {
            User userFromContext = dbContext.Users.Find(user.Id);
            userFromContext.FirstName = user.FirstName;
            userFromContext.LastName = user.LastName;
            userFromContext.Age = user.Age;
            userFromContext.Username = user.Username;
            userFromContext.Password = user.Password;
            userFromContext.Email = user.Email;
            if (useNavigationalProperties)
            {
                List<User> friends = new List<User>();
                List<Interest> interests = new List<Interest>();
                for (int i = 0; i < user.Friends.Count; i++)
                {
                    User friend = dbContext.Users.Find(user.Friends[i]);
                    if (friend != null)
                    {
                        friends.Add(friend);
                    }
                    else
                    {
                        friends.Add(user.Friends[i]);
                    }
                }
                for (int i = 0; i < user.Interests.Count; i++)
                {
                    Interest interest = dbContext.Interests.Find(user.Interests[i]);
                    if (interest != null)
                    {
                        interests.Add(interest);
                    }
                    else
                    {
                        interests.Add(user.Interests[i]);
                    }
                }
                userFromContext.Friends = friends;
                userFromContext.Interests = interests;
            }
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            User user = dbContext.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }
    }
}
