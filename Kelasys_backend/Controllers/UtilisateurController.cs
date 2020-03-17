using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Kelasys_backend.DAO;
using Kelasys_backend.Models.VO;
using Kelasys_backend.Interfaces;

namespace Kelasys_backend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UtilisateurController : ControllerBase, ICrud<Utilisateur> {

        private readonly ILogger<UtilisateurController> _logger;
        private readonly ApplicationDbContext _context;

        public UtilisateurController(
            ApplicationDbContext context,
            ILogger<UtilisateurController> logger) {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getallutilisateurs")]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAll() {
            return await _context.Utilisateurs.ToListAsync();
        }

        [HttpGet("getutilisateurbyid/{id}")]
        public async Task<ActionResult<Utilisateur>> GetById(int id) {
            Utilisateur utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null) {
                return NotFound();
            }

            return utilisateur;
        }


        [HttpPost("createutilisateur")]
        public async Task<ActionResult<Utilisateur>> Create(Utilisateur utilisateur) {
            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            return utilisateur;
        }

        [HttpPut("updateutilisateur")]
        public async Task<ActionResult<bool>> Update(Utilisateur utilisateur) {
            _context.Entry(utilisateur).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!IsUtilisateurExiste(utilisateur.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return true;
        }

        [HttpDelete("deleteutilisateurbyid/{id}")]
        public async Task<ActionResult<bool>> Delete(int id) {
            Utilisateur utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null) {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool IsUtilisateurExiste(int id) {
            return _context.Utilisateurs.Any(u => u.Id == id);
        }
    }
}
