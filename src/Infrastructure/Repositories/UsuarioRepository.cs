using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly MySqlContext _context;

        public UsuarioRepository(MySqlContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            var user = await _context.Usuario
                                        .Where(x => x.Email.ToLower() == email.ToLower())
                                        .AsNoTracking()
                                        .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<List<Usuario>> SearchByEmail(string email)
        {
            var allUsuarios = await _context.Usuario
                                    .Where(x => x.Email.ToLower().Contais(email.ToLower()))
                                    .AsNoTracking()
                                    .ToListAsync();
            return allUsuarios;
        }

        public async Task<List<Usuario>> SearchByName(string name)
        {
            var allUsuarios = await _context.Usuario
                                    .Where(x => x.Name.ToLower().Contais(name.ToLower()))
                                    .AsNoTracking()
                                    .ToListAsync();
            return allUsuarios;
        }
    }
}
