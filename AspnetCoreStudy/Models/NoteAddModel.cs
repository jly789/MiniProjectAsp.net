using System.ComponentModel.DataAnnotations;

namespace AspnetCoreStudy.Models
{
    public class NoteAddModel
    {

        [Key]
        public int NoteNo { get; set; }

        [Required(ErrorMessage = "게시판 제목을 입력하세요")]
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required(ErrorMessage = "게시판 내용을 입력하세요")]
        public string NoteContents { get; set; }


        [Required]
        public int UserNo { get; set; }
    }
}
