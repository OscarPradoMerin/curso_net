/*************************************

The contents of this file should be copied into Seed() method of Migrations/Configuration

This will populate our database with users and roles

*************************************/

// Seed Roles

if (!context.Roles.Any(r => r.Name == RolesData.Admin))
{
	var store = new RoleStore<IdentityRole>(context);
	var manager = new RoleManager<IdentityRole>(store);
	var role = new IdentityRole { Name = RolesData.Admin };

	manager.Create(role);
}

if (!context.Roles.Any(r => r.Name == RolesData.Moderator))
{
	var store = new RoleStore<IdentityRole>(context);
	var manager = new RoleManager<IdentityRole>(store);
	var role = new IdentityRole { Name = RolesData.Moderator };

	manager.Create(role);
}

// Seed Users

if (!context.Users.Any(u => u.UserName == "oscarprado"))
{
	var store = new UserStore<ApplicationUser>(context);
	var manager = new UserManager<ApplicationUser>(store);
	var user = new ApplicationUser { UserName = "oscarprado", Email = "oscarpradomerin@gmail.com" };

	//manager.Create(user, "Cur$0Net");
	manager.AddToRole(user.Id, RolesData.Admin);
}

if (!context.Users.Any(u => u.UserName == "pringao"))
{
	var store = new UserStore<ApplicationUser>(context);
	var manager = new UserManager<ApplicationUser>(store);
	var user = new ApplicationUser { UserName = "pringao", Email = "pringao@gmail.com" };

	//manager.Create(user, "Cur$0Net");
}

if (!context.Users.Any(u => u.UserName == "menospringao"))
{
	var store = new UserStore<ApplicationUser>(context);
	var manager = new UserManager<ApplicationUser>(store);
	var user = new ApplicationUser { UserName = "menospringao", Email = "menospringao@gmail.com" };

	//manager.Create(user, "Cur$0Net");
	manager.AddToRole(user.Id, RolesData.Moderator);
}