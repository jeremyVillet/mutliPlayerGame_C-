//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharpmonGame
{
    using System;
    using System.Collections.Generic;
    
    public partial class DB_Attacks
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Nullable<int> damage { get; set; }
        public Nullable<int> boostPower { get; set; }
        public Nullable<int> boostDefense { get; set; }
        public Nullable<int> boostDodge { get; set; }
        public string sharpmonOwner { get; set; }
    }
}
