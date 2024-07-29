using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreStudy.Models
{
    public class Note
    {
        /// <summary>
        /// 게시물번호
        /// </summary>

        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>

       [Required(ErrorMessage = "게시판 제목을 입력하세요")]
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
       [Required(ErrorMessage = "게시판 내용을 입력하세요")]
        public string  NoteContents { get; set; }

        /// <summary>
        /// 작성자 번호
        /// </summary>

        [Required]
       public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }
}
