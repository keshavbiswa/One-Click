using OneClick.Domain._Entities;
using OneClick.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Concrete
{
    public class EFNoteRepository : INoteRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Note> notes
        {
            get { return context.Notes; }   
        }
    }
}
