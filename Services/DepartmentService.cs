namespace WebSallesMvc.Services
{
    public class DepartmentService
    {
        private readonly WebSallesMvcContext _context;

        public DepartmentService(WebSallesMvcContext context)
        {
            _context = context;
        }

        public List<Models.Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
