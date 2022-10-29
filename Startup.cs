using EjercicioMVC16.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EjercicioMVC16.Startup))]
namespace EjercicioMVC16
{
    public partial class Startup
    {

        ApplicationDbContext context = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolesConUsuario();
        }

        private void CrearRolesConUsuario()
        {

            //Manejador de roles y usuarios

            var ManejadorDeRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var ManejadorDeUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //si el rol no existe creamos el rol
            if (!ManejadorDeRol.RoleExists("Admin"))
            {

                //creamos el nuevo rol
                var rol = new IdentityRole();

                //establecemos parametros
                rol.Name = "Admin";
                ManejadorDeRol.Create(rol);

                //Creamos el nuevo usuario
                var user = new ApplicationUser();

                user.UserName = "jeanmorales@unan.edu.ni";
                user.Email = "jeanmorales@unan.edu.ni";

                string pwd = "18040491";

                //agregamos el usuario, si se agrego con exito la variable almacenara true
                var verificar = ManejadorDeUsuario.Create(user, pwd);



                if (verificar.Succeeded)
                {
                    //asignamos el rol a usuario
                    var result = ManejadorDeUsuario.AddToRole(user.Id, "Admin");


                }
            }

            //si el rol no existe creamos el rol
            if (!ManejadorDeRol.RoleExists("Empleado"))
            {

                //creamos el nuevo rol
                var rol = new IdentityRole();

                //establecemos parametros
                rol.Name = "Empleado";
                ManejadorDeRol.Create(rol);

                //Creamos el nuevo usuario
                var user = new ApplicationUser();

                user.UserName = "Empleado@unan.edu.ni";
                user.Email = "Empleado@unan.edu.ni";

                string pwd = "18040491";

                //agregamos el usuario, si se agrego con exito la variable almacenara true
                var verificar = ManejadorDeUsuario.Create(user, pwd);



                if (verificar.Succeeded)
                {
                    //asignamos el rol a usuario
                    var result = ManejadorDeUsuario.AddToRole(user.Id, "Empleado");


                }
            }

            //si el rol no existe creamos el rol
            if (!ManejadorDeRol.RoleExists("Gerente"))
            {

                //creamos el nuevo rol
                var rol = new IdentityRole();

                //establecemos parametros
                rol.Name = "Gerente";
                ManejadorDeRol.Create(rol);

                //Creamos el nuevo usuario
                var user = new ApplicationUser();

                user.UserName = "Gerente@unan.edu.ni";
                user.Email = "Gerente@unan.edu.ni";

                string pwd = "18040491";

                //agregamos el usuario, si se agrego con exito la variable almacenara true
                var verificar = ManejadorDeUsuario.Create(user, pwd);



                if (verificar.Succeeded)
                {
                    //asignamos el rol a usuario
                    var result = ManejadorDeUsuario.AddToRole(user.Id, "Gerente");


                }
            }

        }


    }
}
