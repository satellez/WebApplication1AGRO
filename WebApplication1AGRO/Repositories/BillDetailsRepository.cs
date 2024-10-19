using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class BillDetailsRepository : IBillDetailsRepository
    {
        private readonly AgroDbContext _context;

        public BillDetailsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateBillDetailsAsync(BillDetails billDetails)
        {
            // Validar Product y Bill antes de crear
            var products = await _context.Products.FindAsync(billDetails.Product_id);
            if (products == null)
            {
                throw new Exception("Producto no encontrado");
            }

            var bills = await _context.Bills.FindAsync(billDetails.Bill_id);
            if (bills == null)
            {
                throw new Exception("Factura no encontrada");
            }

            // Asignar relaciones
            billDetails.Products = products;
            billDetails.Bills = bills;

            // Establecer IsDeleted como false al crear
            billDetails.IsDeleted = false;

            _context.BillDetails.Add(billDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillDetails>> GetAllBillDetailsAsync()
        {
            return await _context.BillDetails
                .Where(s => !s.IsDeleted)
                .Include(bd => bd.Products)
                    .ThenInclude(p => p.ProductCategories)  // Incluir ProductCategories
                .Include(bd => bd.Bills)
                    .ThenInclude(b => b.Users)
                        .ThenInclude(u => u.UserTypes)      // Incluir UserTypes
                .Include(bd => bd.Bills)
                    .ThenInclude(b => b.Users)
                        .ThenInclude(u => u.Documents)     // Incluir Documents
                .Include(bd => bd.Bills)
                    .ThenInclude(b => b.PaymentMethods)    // Incluir PaymentMethods
                .ToListAsync();
        }

        public async Task<BillDetails?> GetBillDetailsByIdAsync(int id)
        {
            return await _context.BillDetails
                .Include(bd => bd.Products)
                    .ThenInclude(p => p.ProductCategories)  // Incluir ProductCategories
                .Include(bd => bd.Bills)
                    .ThenInclude(b => b.Users)
                        .ThenInclude(u => u.UserTypes)      // Incluir UserTypes
                .Include(bd => bd.Bills)
                    .ThenInclude(b => b.Users)
                        .ThenInclude(u => u.Documents)     // Incluir Documents
                .Include(bd => bd.Bills)
                    .ThenInclude(b => b.PaymentMethods)    // Incluir PaymentMethods
                .FirstOrDefaultAsync(s => s.BillDeta_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteBillDetailsAsync(int id)
        {
            var billDetails = await _context.BillDetails.FindAsync(id);
            if (billDetails != null)
            {
                billDetails.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBillDetailsAsync(BillDetails updatedBillDetails)
        {
            var existingBillDetails = await _context.BillDetails.FindAsync(updatedBillDetails.BillDeta_id);
            if (existingBillDetails != null && !existingBillDetails.IsDeleted)
            {
                // Validar Product y Bill antes de actualizar
                var product = await _context.Products.FindAsync(updatedBillDetails.Product_id);
                if (product == null)
                {
                    throw new Exception("Producto no encontrado.");
                }

                var bill = await _context.Bills.FindAsync(updatedBillDetails.Bill_id);
                if (bill == null)
                {
                    throw new Exception("Factura no encontrada.");
                }

                // Asignar relaciones
                existingBillDetails.Products = product;
                existingBillDetails.Bills = bill;

               

                // Guardar cambios
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"BillDetails with ID {updatedBillDetails.BillDeta_id} not found.");
            }
        }
    }
}
