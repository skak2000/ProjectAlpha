using DataAccessLayer;
using Model.WebModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogicLayer
{
    public class BusinessController
    {
        DatabaseController db = new DatabaseController();
        public List<Company> GetCompanyList()
        {
            
            return db.GetCompanyList();
        }

        public Company GetCompanyById(Guid companyID)
        {
            Company respont = db.GetCompanyById(companyID);
            respont.ReviewList = db.GetReviewByCompanyID(companyID);
            return respont;
        }

        public User GetUserByLogin(string username, string password)
        {
            return db.GetUserByLogin(username, password);
        }

        public User GetUserByID(Guid userID)
        {
            User respont = db.GetUserByID(userID);
            respont.ReviewList = db.GetReviewByUserID(userID);
            return respont;
        }

        public List<UserPublic> GetAllUsers()
        {
            List<User> userList = db.GetAllUsers();
            List<UserPublic> respont = new List<UserPublic>();

            foreach (User item in userList)
            {
                UserPublic temp = Mapper.User(item);
                temp.ReviewList = db.GetReviewByUserID(item.UserID);
                respont.Add(temp);
            }

            return respont;
        }

        public UserPublic GetPublicUserByID(Guid userID)
        {
            User temp = db.GetUserByID(userID);
            UserPublic respont = Mapper.User(temp);
            respont.ReviewList = db.GetReviewByUserID(userID);
            return respont;
        }

        public void ReviewCreate(Review input)
        {
            // Do not do this!!! Save on database
            string path = Directory.GetCurrentDirectory();
            string filename = "\\" + input.ReviewID + ".jpg";

            if (input.Image != null)
            {
                using (var fileStream = new FileStream(path + filename, FileMode.Create))
                {
                    fileStream.Position = 0;
                    input.Image.CopyToAsync(fileStream);
                }
            }

            // Save as json fix
            input.Image = null;

            db.ReviewCreate(input);
        }

        public void ReviewEdit(Review input)
        {
            throw new NotImplementedException();
        }

        public void ReviewDelete(Review input)
        {
            db.ReviewDelete(input.ReviewID);
        }
        public void CreateUser(User input)
        {
            db.CreateUser(input);
        }

        public void UserUpdate(User input)
        {
            db.UserUpdate(input);
        }

        public List<Review> GetReviewImages(List<Review> reviewList)
        {

            foreach (Review item in reviewList)
            {
                string fileName = item.ReviewID.ToString() + ".jpg";
                item.Base64String = GetImage(fileName);
            }

            return reviewList;
        }

        public string GetImage(string fileName)
        {
            string path = Directory.GetCurrentDirectory();
            string filePath = path + "\\" + fileName;

            byte[] byteArray = Helpers.FileToStream(filePath);
            string base64String = Convert.ToBase64String(byteArray);

            // Do not work... ToDo
            //IFormFile file = new FormFile(stream, 0, byteArray.Length, "name", "fileName");
            //item.Image = file;
            return base64String; 
        }
    }
}
