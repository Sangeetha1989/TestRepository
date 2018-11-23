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
    public class PODETAILsUnitTest
    {
        [TestMethod]
        public void GetItemsByIdSuccess()
        {
            // Set up Prerequisites   
            var controller = new PODETAILsController();
            // Act on Test  
            var response = controller.GetPODETAIL("1");
            var contentResult = response as OkNegotiatedContentResult<POMASTER>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.PONO);
        }

        [TestMethod]
        public void GetItemsNotFound()
        {
            // Set up Prerequisites   
            var controller = new PODETAILsController();
            // Act  
            IHttpActionResult actionResult = controller.GetPODETAIL("100");
            // Assert  
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddItemsTest()
        {
            // Arrange  
            var controller = new PODETAILsController();
            PODETAIL objItem = new PODETAIL
            {
               PONO = "1",
                ITCODE = "1",
                QTY = 20
            };
            // Act  
            IHttpActionResult actionResult = controller.PostPODETAIL(objItem);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<POMASTER>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void UpdateItemsTest()
        {
            // Arrange  
            var controller = new PODETAILsController();
            PODETAIL objItem = new PODETAIL
            {
                PONO = "1",
                ITCODE = "1",
                QTY = 30
            };
            // Act  
            IHttpActionResult actionResult = controller.PutPODETAIL("1", objItem);
            var contentResult = actionResult as NegotiatedContentResult<POMASTER>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(System.Net.HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
        }
        [TestMethod]
        public void DeleteItemsTest()
        {
            // Arrange  
            var controller = new PODETAILsController();
            // Act  
            IHttpActionResult actionResult = controller.DeletePODETAIL("1");
            var contentResult = actionResult as NegotiatedContentResult<POMASTER>;
            Assert.IsNotNull(contentResult);
            // Assert.AreEqual(System.Net.HttpStatusCode.Accepted, contentResult.StatusCode);
            // Assert.IsNotNull(contentResult.Content);
        }
    }
}

