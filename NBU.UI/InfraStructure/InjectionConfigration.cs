using Microsoft.Extensions.DependencyInjection;
using NBU.BLL._Department;
using NBU.BLL._Employee;
using NBU.BLL._EmployeeCertification;
using NBU.BLL._Gender;
using NBU.BLL._Job;
using NBU.Common.EmailConfigure;
using NBU.DAL.Entities;
using NBU.DAL.Repository;
using NBU.Resources.cs;

namespace NBU.UI.InfraStructure
{
    public class InjectionConfigration
    {
        // here we inject interface and its implementation in Bll Class you will get this 2 liens and past  
        //  services.AddTransient<IRepositoryBase<Entity>, RepositoryBase<Entity>>();
        //  services.AddTransient<Interface, Class>();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepositoryBase<Gender>, RepositoryBase<Gender>>();
            services.AddTransient<IGenderBLL , GenderBLL>();

            services.AddTransient<IRepositoryBase<Employee>, RepositoryBase<Employee>>();
            services.AddTransient<IEmployeeBLL, EmployeeBLL>();

            services.AddTransient<IRepositoryBase<Department>, RepositoryBase<Department>>();
            services.AddTransient<IDepartmentBLL, DepartmentBLL>();

            services.AddTransient<IRepositoryBase<Job>, RepositoryBase<Job>>();
            services.AddTransient<IJobBLL, JobBLL>();
            services.AddTransient<IRepositoryBase<EmployeeCertification>, RepositoryBase<EmployeeCertification>>();
            services.AddTransient<IEmployeeCertificationBLL, EmployeeCertificationBLL>();
            //Localization Confiure
            services.AddSingleton<I_LayoutResx, _LayoutResx>();
            //Sending Email service
            services.AddTransient<ISendEmail, SendEmail>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
