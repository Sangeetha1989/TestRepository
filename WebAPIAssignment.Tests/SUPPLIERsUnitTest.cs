using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using WebAPIAssignment.Controllers;
using WebAPIAssignment.Models;
using System.Web.Http;

namespace WebAPIAssignment.Tests
{
    [TestClass]
    public class SUPPLIERsUnitTest
    {
        [TestMethod]
        public void GetItemsByIdSuccess()
        {
            // Set up Prerequisites   
            var controller = new SUPPLIERsController();
            // Act on Test  
            var response = controller.GetSUPPLIER("1");
            var contentResult = response as OkNegotiatedContentResult<ITEM>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ITCODE);
        }

        [TestMethod]
        public void GetItemsNotFound()
        {
            // Set up Prerequisites   
            var controller = new SUPPLIERsController();
            // Act  
            IHttpActionResult actionResult = controller.GetSUPPLIER("100");
            // Assert  
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddItemsTest()
        {
            // Arrange  
            var controller = new SUPPLIERsController();
            SUPPLIER objItem = new SUPPLIER
            {
                SUPLNO = "3",
                SUPLNAME = "SuplierName3",
                SUPLADDR = "Test Supplier Address3"
            };
            // Act  
            IHttpActionResult actionResult = controller.PostSUPPLIER(objItem);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<SUPPLIER>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void UpdateItemsTest()
        {
            // Arrange  
            var controller = new SUPPLIERsController();
            SUPPLIER objItem = new SUPPLIER
            {
                SUPLNO = "1",
                SUPLNAME = "NameUpdate",
                SUPLADDR = "Test Supplier Address Update"
            };
            // Act  
            IHttpActionResult actionResult = controller.PutSUPPLIER("1", objItem);
            var contentResult = actionResult as NegotiatedContentResult<SUPPLIER>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(System.Net.HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
        }
        [TestMethod]
        public void DeleteItemsTest()
        {
            // Arrange  
            var controller = new SUPPLIERsController();
            // Act  
            IHttpActionResult actionResult = controller.DeleteSUPPLIER("1");
            var contentResult = actionResult as NegotiatedContentResult<SUPPLIER>;
            Assert.IsNotNull(contentResult);
            // Assert.AreEqual(System.Net.HttpStatusCode.Accepted, contentResult.StatusCode);
            // Assert.IsNotNull(contentResult.Content);
        }
    }
}

