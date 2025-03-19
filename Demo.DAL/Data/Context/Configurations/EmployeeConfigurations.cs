

namespace Demo.DAL.Data.Context.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(e => e.Adress)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(e => e.Gender)
                .HasConversion
                (
                    Gender => Gender.ToString(), Gender => Enum.Parse<Gender>(Gender)
                );

            builder.Property(e => e.EmployeeType)
               .HasConversion
               (
                   EmployeeType => EmployeeType.ToString(), EmployeeType => Enum.Parse<EmployeeType>(EmployeeType)
               );

        }
    }
}
