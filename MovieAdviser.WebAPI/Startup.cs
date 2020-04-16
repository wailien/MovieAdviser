using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAdviser.BusinessLogic.Implementations;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Context;
using MovieAdviser.DataAccess.Implementations;
using MovieAdviser.DataAccess.Interfaces;

namespace MovieAdviser.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(IGenreCreateService),typeof(GenreCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGenreGetService),typeof(GenreGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGenreUpdateService),typeof(GenreUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMovieCreateService),typeof(MovieCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMovieGetService),typeof(MovieGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMovieUpdateService),typeof(MovieUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICartoonCreateService),typeof(CartoonCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICartoonGetService),typeof(CartoonGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICartoonUpdateService),typeof(CartoonUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(IGenreDataAccess), typeof(GenreDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IMovieDataAccess), typeof(MovieDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICartoonDataAccess), typeof(CartoonDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            services.AddDbContext<GenreContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("MovieAdviser")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<GenreContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
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