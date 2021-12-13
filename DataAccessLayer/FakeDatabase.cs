using Model.WebModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FakeDatabase
    {    
        public Storage GetDatabase()
        {
            Storage database = new Storage();
            // Hack Database Emulering // Sorry      
            try
            {
                string json = File.ReadAllText("MyData.json");
                database = JsonConvert.DeserializeObject<Storage>(json);
            }
            catch (Exception e)
            {

                // ToDo log error
                database.CompanyList = GetCompanyList();
                database.ReviewList = GetReviewList();
                database.UserList = GetUserList();
                SaveData(database);
            }    
            return database;
        }

        public void SaveData(Storage database)
        {
            try
            {
                string json = JsonConvert.SerializeObject(database);
                File.WriteAllText("MyData.json", json);
            }
            catch (Exception e)
            {
                // ToDo log error
            }
        }

        private List<Company> GetCompanyList()
        {
            List<Company> respont = new List<Company>();

            Company company = new Company()
            {
                CompanyID = Guid.Parse("6888d3dc-4bc1-40f8-8e59-754abe36f8ec"),
                Address = "Vejlevej 129",
                City = "Kolding",
                ZipCode = "6000",
                Name = "Mc Donalds",
                OpeningHours = "Mandag-søndag: 7-22"
            };
            respont.Add(company);

            company = new Company()
            {
                CompanyID = Guid.Parse("fa8a896f-3f40-4cd6-9d3f-4e0d92746d9a"),
                Address = "Munkegade 7",
                City = "Kolding",
                ZipCode = "6000",
                Name = "Burger Shack Kolding",
                OpeningHours = "Mandag-lørdag: 9-23"
            };
            respont.Add(company);

            company = new Company()
            {
                CompanyID = Guid.Parse("88b85940-7730-49e2-ba29-7bbb61b02158"),
                Address = "Vonsildvej 1A",
                City = "Kolding",
                ZipCode = "6000",
                Name = "Burger King",
                OpeningHours = "Mandag-lørdag: 9-23"
            };
            respont.Add(company);

            return respont;
        }

        private List<Review> GetReviewList()
        {
            List<Review> respont = new List<Review>();

            Review review = new Review()
            {
                ProductName = "Super burger x",
                CompanyID = Guid.Parse("6888d3dc-4bc1-40f8-8e59-754abe36f8ec"), //Mc Donalds
                TasteRating = 8,
                TextureRating = 4,
                VisualRating = 10,
                Timestamp = DateTime.Now,
                UserID = Guid.Parse("717dfaed-4b97-492c-98c0-68e7444a0e95"), // Anne
            };
            respont.Add(review);

            review = new Review()
            {
                ProductName = "Super burger XL",
                CompanyID = Guid.Parse("6888d3dc-4bc1-40f8-8e59-754abe36f8ec"), // Mc Donalds
                TasteRating = 3,
                TextureRating = 14,
                VisualRating = 5,
                Timestamp = DateTime.Now,
                UserID = Guid.Parse("0d85ffe5-0678-4249-b312-eaad86401ab1"), // Mette
            };
            respont.Add(review);


            review = new Review()
            {
                ProductName = "Super burger revers",
                CompanyID = Guid.Parse("fa8a896f-3f40-4cd6-9d3f-4e0d92746d9a"), // Burger Shack Kolding
                TasteRating = 13,
                TextureRating = 14,
                VisualRating = 5,
                Timestamp = DateTime.Now,
                UserID = Guid.Parse("717dfaed-4b97-492c-98c0-68e7444a0e95"), // Anne
            };
            respont.Add(review);

            review = new Review()
            {
                ProductName = "Super burger revers",
                CompanyID = Guid.Parse("fa8a896f-3f40-4cd6-9d3f-4e0d92746d9a"), // Burger Shack Kolding
                TasteRating = 3,
                TextureRating = 4,
                VisualRating = 5,
                Timestamp = DateTime.Now,
                UserID = Guid.Parse("4def2cf8-537a-4bad-8f73-a33ed6b1a828"), // Mads
            };
            respont.Add(review);


            review = new Review()
            {
                ProductName = "Super burger new",
                CompanyID = Guid.Parse("88b85940-7730-49e2-ba29-7bbb61b02158"), // Burger King
                TasteRating = 3,
                TextureRating = 4,
                VisualRating = 5,
                Timestamp = DateTime.Now,
                UserID = Guid.Parse("717dfaed-4b97-492c-98c0-68e7444a0e95"), // Anne
            };
            respont.Add(review);

            review = new Review()
            {
                ProductName = "Burger classik",
                CompanyID = Guid.Parse("88b85940-7730-49e2-ba29-7bbb61b02158"), // Burger King
                TasteRating = 3,
                TextureRating = 4,
                VisualRating = 5,
                Timestamp = DateTime.Now,
                UserID = Guid.Parse("4def2cf8-537a-4bad-8f73-a33ed6b1a828"), // Mads
            };
            respont.Add(review);

            return respont;
        }

        private List<User> GetUserList()
        {
            List<User> respont = new List<User>();

            User user = new User()
            {
                Mail = "Annejensen@mail.dk",
                UserName = "Anne",
                UserID = Guid.Parse("717dfaed-4b97-492c-98c0-68e7444a0e95"),
                Password = "1234",
            };
            respont.Add(user);

            user = new User()
            {
                Mail = "Mettejensen@mail.dk",
                UserName = "Mette",
                UserID = Guid.Parse("0d85ffe5-0678-4249-b312-eaad86401ab1"),
                Password = "1234"
            };
            respont.Add(user);

            user = new User()
            {
                Mail = "Madshansen@mail.dk",
                UserName = "Mads",
                UserID = Guid.Parse("4def2cf8-537a-4bad-8f73-a33ed6b1a828"),
                Password = "1234"
            };
            respont.Add(user);

            return respont;
        }
    }
}
