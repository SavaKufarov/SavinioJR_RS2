using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DistrictContext : IDb<District, int>
    {
        private PeopleIntrestDbContext dbContext;
        public DistrictContext(PeopleIntrestDbContext appContext)
        {
            dbContext = appContext;
        }
        public void Create(District item)
        {
            dbContext.Districts.Add(item);
            dbContext.SaveChanges();
        }
        public District Read(int id, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<District> query = dbContext.Districts;
            if (useNavigationalProperties)
            {
                query = query.Include(f => f.Users);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            District district = query.FirstOrDefault(f => f.Id == id);
            if (district == null)
            {
                throw new Exception("District not found!");
            }
            return district;
        }
        public List<District> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<District> query = dbContext.Districts;
            if (useNavigationalProperties)
            {
                query = query.Include(f => f.Users);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return query.ToList();
        }
        public void Update(District district, bool useNavigationalProperties = false)
        {
            District districtFromContext = dbContext.Districts.Find(district.Id);
            districtFromContext.Name = district.Name;
            if (useNavigationalProperties)
            {
                List<User> users = new List<User>();
                for (int i = 0; i < district.Users.Count; i++)
                {
                    User user = dbContext.Users.Find(district.Users[i]);
                    if (user != null)
                    {
                        users.Add(user);
                    }
                    else
                    {
                        users.Add(district.Users[i]);
                    }
                }
                districtFromContext.Users = users;
            }
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            District district = dbContext.Districts.Find(id);
            if (district != null)
            {
                dbContext.Districts.Remove(district);
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("District not found!");
            }
        }
    }
}
