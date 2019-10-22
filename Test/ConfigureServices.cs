using EFCore.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCore.Configuration.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    public class ConfigureServices
    {

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton<IOperationSingleton, Operation>();

        //}
        private IServiceCollection _service { get; set; }
        private ServiceProvider _provider { get; set; }

        public ConfigureServices()
        {
            _service = new ServiceCollection();

            _service.AddSingleton<IInspectionRepository, SqlEfCoreInspectionRepository>();
            _service.AddSingleton<IInMemoryEFCoreInspectionRepository, InMemoryEFCoreInspectionRepository>();

        }

        public void ConfigureEFCore()
        {
            CheckEfCoreRegistration();


            //_service.AddDbContext<EfContext>(options => 
            //    options.UseSqlServer(@"Server=SI-FDPR-03\FOOTBALL;Initial Catalog=SMS;Persist Security Info=True;User ID=sa;Password=sharm;MultipleActiveResultSets=True"));

            var context = new EfContext();
            _provider = _service.BuildServiceProvider();
        }


        public void ConfigureEFCoreInMemory()
        {
            var context = new MemoryContext();
        }


        private void CheckEfCoreRegistration()
        {
            if (!_service.Any(x => x.ServiceType != typeof(SqlEfCoreInspectionRepository)))
            {
                throw new Exception();
            }
        }

        public IInspectionRepository GetSqlEfCoreInspectionRepository()
        {
            CheckEfCoreRegistration();

            return _provider.GetService<IInspectionRepository>();

        }


        public IInMemoryEFCoreInspectionRepository GetInMemoryEFCoreInspectionRepository()
        {

            return _provider.GetService<IInMemoryEFCoreInspectionRepository>();

        }

    }

}
