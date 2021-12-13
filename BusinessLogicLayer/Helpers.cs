using Model.WebModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class Helpers
    {
        public static byte[] FileToStream(string path)
        {
            byte[] byteArray = File.ReadAllBytes(path);
            return byteArray;
        }

        public static List<string> GetBurgerList()
        {
            List<string> burgerList = new List<string>();

            burgerList.Add("Burger ABC");
            burgerList.Add("Burger XYZ");
            burgerList.Add("Burger 2020");
            burgerList.Add("Burger 2021");
            burgerList.Add("Burger XL");
            burgerList.Add("Burger small");
            return burgerList;
        }
        

        public static Review RandomReviews(Guid userId, Guid companyID)
        {
            Random random = new Random();           

            Review review = new Review();
            review.TasteRating = random.Next(1, 10);
            review.TextureRating = random.Next(1, 10);
            review.VisualRating = random.Next(1, 10);
            review.Timestamp = DateTime.Now.AddMonths(random.Next(1, 10));
            review.ReviewID = Guid.NewGuid();
            review.ProductName = GetBurgerList()[random.Next(0, 5)];
            review.UserID = userId;
            review.CompanyID = companyID;
            return review;
        }
    }
}
