using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMR.MVC.Startup))]
namespace TMR.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //Build a seed method that creates an instance of each 1)AppDbContext 2)UserManager<ApplicationUser> 3) RoleManager<IdentityRole>

        //var context = new ApplicationDbContext();

        //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


        //Check if an Admin Role exists
        //If not, use the Role Manager to create one
        //then use UserManager to create a default admin user, and add that user to the Admin Role
        //have a line or 2 that creates a generic User Role for basic functionality

        //Create an Admin Controller and create an instance of both UserManager and RoleManager
        //Create methods that do CRUD for Roles, and Adding or removing Roles from specific users

        //You can also add a line of code to automatically add a generic Role to Users that register via the Account\Register API endpoint in the Account controller

    }
}
