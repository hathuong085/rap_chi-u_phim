using Cimena.API.DbContext;
using Cimena.BAL;
using Cimena.BAL.INTERFACE;
using Cimena.DAL;
using Cimena.DAL.INTERFACE;
using Cimena.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cimena.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Common.connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<ICategoryFilmRepository,CategoryFilmRepository>();
            services.AddScoped<ICategoryFilmService,CategoryFilmService>();
            services.AddScoped<IShowingRepository, ShowingRepository>();
            services.AddScoped<IShowingService, ShowingService>();
            services.AddScoped<IChairOnRepository, ChairOnRepository>();
            services.AddScoped<IChairOnService, ChairOnService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IComboFoodRepository, ComboFoodRepository>();
            services.AddScoped<IComboFoodService, ComboFoodService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookFilmRepository, BookFilmRepository>();
            services.AddScoped<IBookFilmService, BookFilmService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomSevice, RoomSevice>();
            services.AddScoped<IEventRepository, EventReposirory>();
            services.AddScoped<IEventService, EventService>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(); 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema APIs");
            });
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
