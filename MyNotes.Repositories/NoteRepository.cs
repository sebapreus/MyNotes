using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNotes.Models;
using MyNotes.Repositories.Interfaces;
using MyNotes.EF;
using System.Data.Entity;

namespace MyNotes.Repositories
{
    public class NoteRepository : BaseRepository<Note>
    {
        public NoteRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
