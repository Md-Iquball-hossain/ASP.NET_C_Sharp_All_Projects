using CandidateBlazorApp.Shared.Models;
using CandidateBlazorApp.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandidateBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateDbContext db;
        private readonly IWebHostEnvironment env;
        public CandidatesController(CandidateDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
        {
            var data = await db.Candidates.ToListAsync();
            return data;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            var data = await db.Candidates
                .Include(p=>p.PersonalInfo)
                .Include(j=>j.JobDetail)
                .Include(e=>e.Educations)
                .Include(e=>e.Experiences)
                .Include(r=>r.Resumes)
                .Include(r=>r.References)
                .Include(t=>t.Training)
                .Include(p=>p.Projects)
                .Include(s=>s.Skills)
                .FirstOrDefaultAsync(c=>c.CandidateId == id);
            if(data != null)
            {
                return data;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
               await db.Candidates.AddAsync(candidate);
                await db.SaveChangesAsync();
                return candidate;
            }
            return candidate;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Candidate>> PutCandidate(Candidate candidate)
        {

                if (ModelState.IsValid)
                {
                    db.Entry(candidate).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return candidate;
                }
            return candidate;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCandidate(int id)
        {

            var existing = await db.Candidates.FirstOrDefaultAsync(x => x.CandidateId == id);
            if (existing == null) return NotFound();
            db.Candidates.Remove(existing);
            await db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("Upload")]
        public async Task<ImageUploadResponse> Upload(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            var randomFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            var storedFileName = randomFileName + ext;
            using FileStream fs = new FileStream(Path.Combine(env.WebRootPath, "Pictures", storedFileName), FileMode.Create);
            await file.CopyToAsync(fs);
            fs.Close();
            return new ImageUploadResponse { FileName = file.FileName, StoredFileName = storedFileName };
        }
    }
}
