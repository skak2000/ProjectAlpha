using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.WebModel;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetUserByID()
        {
            BusinessLogicLayer.BusinessController bc = new BusinessLogicLayer.BusinessController();

            Guid userID = Guid.Parse("0d85ffe5-0678-4249-b312-eaad86401ab1");
            User respont = bc.GetUserByID(userID);

            Assert.AreEqual(userID, respont.UserID, "User test");
        }

        [TestMethod]
        public void TestGetCompanyById()
        {
            BusinessLogicLayer.BusinessController bc = new BusinessLogicLayer.BusinessController();

            Guid companyID = Guid.Parse("6888d3dc-4bc1-40f8-8e59-754abe36f8ec");
            Company respont = bc.GetCompanyById(companyID);

            Assert.AreEqual(companyID, respont.CompanyID, "Company test");
        }
    }
}
