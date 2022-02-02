using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ManagerContext _context;

        public UsuarioRepository(ManagerContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            var user = await _context.Usuarios
                                        .Where(x => x.Email.ToLower() == email.ToLower())
                                        .AsNoTracking()
                                        .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<List<Usuario>> SearchByEmail(string email)
        {
            var allUsuarios = await _context.Usuarios
                                    .Where(x => x.Email.ToLower().Contains(email.ToLower()))
                                    .AsNoTracking()
                                    .ToListAsync();
            return allUsuarios;
        }

        public async Task<List<Usuario>> SearchByName(string name)
        {
            var allUsuarios = await _context.Usuarios
                                    .Where(x => x.Nome.ToLower().Contains(name.ToLower()))
                                    .AsNoTracking()
                                    .ToListAsync();
            return allUsuarios;
        }
    }
}
