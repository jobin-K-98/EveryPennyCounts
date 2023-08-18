using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveryPennyCounts.Models;
using EveryPennyCountsAPI.Controllers;
using EveryPennyCountsAPI.Data;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EveryPennyCountsTests
{
    public class APIUnitTests
    {
        //this test also doesn't work.  Visual studio doesn't tell you why it's not running tests, which is unhelpful.
        [Fact]
        public async Task GetCategory_Returns_The_Correct_Number_of_Categories()
        {
            int count = 6;
            var fakeCategories = A.CollectionOfDummy<Category>(count).AsEnumerable();
            var context = A.Fake<EveryPennyCountsAPIContext>();
            foreach(Category category in fakeCategories)
            {
                A.CallTo(() => context.Categories.Add(category));
            }
            var controller = new CategoriesController(context);

            var actionResult = await controller.GetCategory();

            var result = actionResult.Result as OkObjectResult;
            var returnCategories = result.Value as IEnumerable<Category>;
            Assert.Equals(count, returnCategories.Count());
        }
    }
}
