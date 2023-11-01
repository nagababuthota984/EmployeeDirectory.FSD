using Mapster;

namespace EmployeeDirectory.Mapster
{
    public class MappingRegistration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Concerns.Employee, Data.DataConcerns.Employee>().PreserveReference(true).MaxDepth(3);
            config.NewConfig<Concerns.Department, Data.DataConcerns.Department>();
            config.NewConfig<Concerns.Office, Data.DataConcerns.Office>();
            config.NewConfig<Concerns.JobTitle, Data.DataConcerns.JobTitle>();
        }
    }
}
