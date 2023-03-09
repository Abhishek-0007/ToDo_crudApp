using AuthenticationMicrservice.DAL.DbContexts;
using AuthenticationMicrservice.DAL.Entities;
using AuthenticationMicrservice.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicrservice.DAL.Repository.Imeplemetations
{
    public class AuthenticateRepository: IAuthenticateRepository
    {
        private readonly AppDbContext _context;
        public AuthenticateRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<AppDbContext>();
        }

        public async Task<IActionResult> Login(User user)
        {
            try
            {
                if (_context.Users.Where(t => t.Email.Equals(user.Email) &&
                                                    t.Password.Equals(user.Password)).Any())
                {
                    var item = await _context.Users.Where(t => t.Email.Equals(user.Email) &&
                                                    t.Password.Equals(user.Password)).FirstOrDefaultAsync();
                    item.isLogin = true;
                    await _context.SaveChangesAsync();

                    return new OkResult();
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        public async Task<IActionResult> Register(User user)
        {
            try
            {
                if (!_context.Users.Where(t => t.Email.Equals(user.Email) &&
                                                    t.Password.Equals(user.Password)).Any())
                {
                    await _context.AddAsync(user);
                    await _context.SaveChangesAsync();

                    return new OkResult();
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}
