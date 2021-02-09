using System.Collections.Generic;

namespace WorkFlowPattern
{
    #region Model
    public class Employee
    {
        public string FirstName { get; set; }
        public string Department { get; set; }
        public int YearOfResumption { get; set; }

    }
    #endregion

    #region spec Employees
    public interface IEmployeeSpecification
    {
        bool IsSatisfiedBy(Employee employee);
    }
    public class EmployeeDepartmentSpecification : IEmployeeSpecification
    {
        private readonly string _department;
        public EmployeeDepartmentSpecification(string depatrment)
        {
            _department = depatrment;
        }
        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.Department.Equals(_department);
        }
    }
    public class EmployeeYearSpecification : IEmployeeSpecification
    {
        private readonly int _year;
        public EmployeeYearSpecification(int year)
        {
            _year = year;
        }
        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.YearOfResumption.Equals(_year);
        }
    }
    public class GetEmployee
    {
        public static List<Employee> GetEmployeeBy(IEmployeeSpecification specification, Employee[] employees)
        {
            List<Employee> NeededEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (specification.IsSatisfiedBy(employee))
                {
                    NeededEmployees.Add(employee);
                }
            }
            return NeededEmployees;
        }
    }

    #endregion


    #region patter Spec 
    // COMPOSITE SPECIFICATIONS  
    public abstract class CompositeSpecification : IEmployeeSpecification
    {
        protected IEmployeeSpecification specification1;
        protected IEmployeeSpecification specification2;
        public CompositeSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2)
        {
            specification1 = spec1;
            specification2 = spec2;
        }
        public abstract bool IsSatisfiedBy(Employee employee);
    }



    public class AndSpecification : CompositeSpecification
    {
        public AndSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
        public override bool IsSatisfiedBy(Employee employee)
        {
            return specification1.IsSatisfiedBy(employee) && specification2.IsSatisfiedBy(employee);
        }
    }
    public class OrSpecification : CompositeSpecification
    {
        public OrSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
        public override bool IsSatisfiedBy(Employee employee)
        {
            return specification1.IsSatisfiedBy(employee) || specification2.IsSatisfiedBy(employee);
        }
    }
    public class NORSpecification : CompositeSpecification
    {
        public NORSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
        public override bool IsSatisfiedBy(Employee employee)
        {
            return !(specification1.IsSatisfiedBy(employee) || specification2.IsSatisfiedBy(employee));
        }
    }
    public class NANDSpecification : CompositeSpecification
    {
        public NANDSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
        public override bool IsSatisfiedBy(Employee employee)
        {
            return !(specification1.IsSatisfiedBy(employee) && specification2.IsSatisfiedBy(employee));
        }
    }
    public class NotSpecification : IEmployeeSpecification
    {
        private IEmployeeSpecification specification;
        public NotSpecification(IEmployeeSpecification spec)
        {
            specification = spec;
        }
        public bool IsSatisfiedBy(Employee employee)
        {
            return !specification.IsSatisfiedBy(employee);
        }
    }

    #endregion
}
