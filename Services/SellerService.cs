using WebSallesMvc.Models;

namespace WebSallesMvc.Services
{
    public class SellerService
    {
        private readonly WebSallesMvcContext _context;

        public SellerService(WebSallesMvcContext context)
        {
            _context = context;
        }   

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Intert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
