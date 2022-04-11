using System.Threading.Tasks;
using Vineforce.TusharBhagat.Models.TokenAuth;
using Vineforce.TusharBhagat.Web.Controllers;
using Shouldly;
using Xunit;

namespace Vineforce.TusharBhagat.Web.Tests.Controllers
{
    public class HomeController_Tests: TusharBhagatWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}