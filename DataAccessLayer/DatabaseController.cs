using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Model.WebModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseController
    {
        FakeDatabase fake = new FakeDatabase();
        Storage database = new Storage();

        public DatabaseController()
        {
            database = fake.GetDatabase();
        }

        public Company GetCompanyById(Guid companyID)
        {
            // Database emulering
            List<Company> companylist = database.CompanyList;
            Company respont = companylist.FirstOrDefault(x => x.CompanyID == companyID);
            return respont;
        }

        public List<Company> GetCompanyList()
        {
            List<Company> respont = database.CompanyList;
            return respont;
        }

        public User GetUserByLogin(string username, string password)
        {
            return database.UserList.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

        public List<User> GetAllUsers()
        {
            return database.UserList;
        }

        public List<Review> GetReviewByCompanyID(Guid companyID)
        {
            List<Review> respont = database.ReviewList.Where(x => x.CompanyID == companyID).OrderByDescending(x=> x.Timestamp).ToList();

            return respont;
        }

        public User GetUserByID(Guid userID)
        {
            User respont = database.UserList.FirstOrDefault(x => x.UserID == userID);
            return respont;
        }

        public void UserUpdate(User input)
        {
            User dbUser = database.UserList.FirstOrDefault(x => x.UserID == input.UserID);

            dbUser.UserName = input.UserName;
            dbUser.Mail = input.Mail; // ToDo validate mail
            dbUser.Password = input.Password;
            dbUser.ProfileText = input.ProfileText;

            fake.SaveData(database);
        }

        public void ReviewDelete(Guid reviewID)
        {
            Review dbValue = database.ReviewList.FirstOrDefault(x => x.ReviewID == reviewID);

            database.ReviewList.Remove(dbValue);

            fake.SaveData(database);
        }

        public List<Review> GetReviewByUserID(Guid userID)
        {
            List<Review> respont = database.ReviewList.Where(x => x.UserID == userID).ToList();

            return respont;
        }

        public void CreateUser(User input)
        {
            User user = database.UserList.FirstOrDefault(x => x.Mail == input.Mail || x.UserName == input.UserName);
            if (user == null)
            {
                input.UserID = Guid.NewGuid();
                database.UserList.Add(input);

                fake.SaveData(database);
            }
        }

        // ToDo save on SQL
        public Review ReviewCreate(Review input)
        {
            database.ReviewList.Add(input);
            fake.SaveData(database);

            return input;
        }
    }
}
