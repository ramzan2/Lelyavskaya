//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lelyavskaya.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Saloon
    {
        public int IdSaloon { get; set; }
        public int IdAdress { get; set; }
        public string LastNameClient { get; set; }
        public string FirstNameClient { get; set; }
        public string MiddleNameClient { get; set; }
        public string PhoneNumberClient { get; set; }
        public string PhoneNumberSaloon { get; set; }
        public int IdGender { get; set; }
        public int IdStaff { get; set; }
        public System.DateTime DateOfVisit { get; set; }
        public int IdManicure { get; set; }
    
        public virtual Adress Adress { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Manicure Manicure { get; set; }
        public virtual Staff Staff { get; set; }
    }
}