using System.ComponentModel.DataAnnotations;

namespace SibalaGame
{
    public enum CategoryType
    {
        [Display(Name = "normal point")]
        NormalPoint,
        [Display(Name = "all of a kind")]
        AllOfAKind
    }
}