using System.ComponentModel.DataAnnotations;

namespace CarSite.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassengerCar,
        [Display(Name = "Седан")]
        Sedan,
        [Display(Name = "Хэтчбек")]
        HatchBack,
        [Display(Name = "Минивэн")]
        Minivan,
        [Display(Name = "Спортивная машина")]
        SportsCar,
        [Display(Name = "Внедорожник")]
        Suv
    }
}