using MyDoktor.BusinessLayer.Abstract;
using MyDoktor.DataAccessLayer.EntityFramework;
using MyDoktor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoktor.BusinessLayer
{
    public class NoteManager : ManagerBase<Note>
    {
        
        public override int Delete(Note note)
        {
            
            LikedManager likedManager = new LikedManager();
            CommentManager commentManager = new CommentManager();

            // Note ile ilişkili commentlerin sil
            foreach (Comment comment in note.Comments.ToList())
            {
                commentManager.Delete(comment);
            }
            // Note ile ilişikili likeları sil
            foreach (Liked like in note.Likes.ToList())
            {
                likedManager.Delete(like);
            }
            return base.Delete(note);

        }
    }
}
