using Kelasys_backend.Enums;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Kelasys_backend.Models.VO {
    public class Utilisateur : IEquatable<Utilisateur> {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Postnom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public Sexe Sexe { get; set; }
        public DateTime DataNascimento { get; set; }
        public NiveauAcces NiveauAcces { get; set; }

        #region Equals and GetHashCode methods

        public override bool Equals(object obj) {
            return Equals(obj as Utilisateur);
        }

        public bool Equals([AllowNull] Utilisateur other) {
            return other != null &&
                   Id == other.Id &&
                   Nom == other.Nom &&
                   Postnom == other.Postnom &&
                   Prenom == other.Prenom &&
                   Email == other.Email &&
                   MotDePasse == other.MotDePasse &&
                   Sexe == other.Sexe &&
                   DataNascimento == other.DataNascimento &&
                   NiveauAcces == other.NiveauAcces;
        }

        public override int GetHashCode() {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nom);
            hash.Add(Postnom);
            hash.Add(Prenom);
            hash.Add(Email);
            hash.Add(MotDePasse);
            hash.Add(Sexe);
            hash.Add(DataNascimento);
            hash.Add(NiveauAcces);
            return hash.ToHashCode();
        }

        #endregion
    }
}
