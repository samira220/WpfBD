//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfBD.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int ID_User { get; set; }
        public string FName { get; set; }
        public string Name { get; set; }
        public int ID_Pass_Log { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<int> ID_Book { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Log_Us Log_Us { get; set; }
    }
}
