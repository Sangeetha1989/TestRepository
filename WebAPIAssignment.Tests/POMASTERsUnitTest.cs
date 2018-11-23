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
    /// <summary>
    /// Summary description for ITEMSUnitTest
    /// </summary>
    [TestClass]
    public class POMASTERsUnitTest
    {
        [TestMethod]
        public void GetItemsByIdSuccess()
        {
            // Set up Prerequisites   
            var controller = new POMASTERsController();
            // Act on Test  
            var response = controller.GetPOMASTER("1");
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
            var controller = new POMASTERsController();
            // Act  
            IHttpActionResult actionResult = controller.GetPOMASTER("100");
            // Assert  
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddItemsTest()
        {
            // Arrange  
            var controller = new POMASTERsController();
            POMASTER objItem = new POMASTER
            {
                PONO = "1",
                PODATE = DateTime.Now,
                SUPLNO = "1"
            };
            // Act  
            IHttpActionResult actionResult = controller.PostPOMASTER(objItem);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<POMASTER>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        //[TestMethod]
        //public void UpdateItemsTest()
        //{
        //    // Arrange  
        //    var controller = new ITEMsController();
        //    ITEM objItem = new ITEM
        //    {
        //        ITCODE = "1",
        //        ITDESC = "TestitemUpdate ",
        //        ITRATE = 20
        //    };
        //    // Act  
        //    IHttpActionResult actionResult = controller.PutITEM("1", objItem);
        //    var contentResult = actionResult as NegotiatedContentResult<ITEM>;
        //    Assert.IsNotNull(contentResult);
        //    Assert.AreEqual(System.Net.HttpStatusCode.Accepted, contentResult.StatusCode);
        //    Assert.IsNotNull(contentResult.Content);
        //}
        [TestMethod]
        public void DeleteItemsTest()
        {
            // Arrange  
            var controller = new POMASTERsController();
            // Act  
            IHttpActionResult actionResult = controller.DeletePOMASTER("1");
            var contentResult = actionResult as NegotiatedContentResult<POMASTER>;
            Assert.IsNotNull(contentResult);
            // Assert.AreEqual(System.Net.HttpStatusCode.Accepted, contentResult.StatusCode);
            // Assert.IsNotNull(contentResult.Content);
        }
    }
}
