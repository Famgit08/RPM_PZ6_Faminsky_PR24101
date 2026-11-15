using PZ6.Models;

namespace PZ6
{
    internal class Helper
    {
        public static LeasingCompanyEntities _context;

        public static LeasingCompanyEntities GetContext()
        {
            if (_context == null)
            {
                _context = new LeasingCompanyEntities();
            }
            return _context;
        }
    }
}