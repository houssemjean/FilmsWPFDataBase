using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Films
{
    enum Genre { action,drame, animation, aventure, thriller, Arts_martiaux,Epouvante_Horreur,science_fiction,fantastique}
    enum VuOuNon {Vu, A_voir, A_recommander }
    enum MonAvis { A_recommander , A_ne_pas_recommander, genial, pas_mal,pas_terrible, mauvais}
    class Film
    {
        public string Titre { get; set; }
        public Genre Genre1 { get; set; }
        public Genre Genre2 { get; set; }
        public string ImagePath { get; set; }
        public int Annee { get; set; }
        public string TitreOriginal { get; set; }
        public string Description { get; set; }
        public VuOuNon VuOuNon {get;set;}
        public MonAvis MonAvis { get; set; }
        public double MaNote { get; set; }
        public double NotePresse { get; set; }
        public double NoteSpectateurs { get; set; }
        public string Lien {get;set;}

        public Film(string titre) {
            this.Titre = titre;
        }

        public Film(string titre,double maNote ,Genre genre1 )
        {
            this.Titre = titre;
            this.Genre1 = genre1;
            this.MaNote = maNote;
        }

        public Film(string titre, double maNote, Genre genre1,int anee, string imagePath)
        {
            this.Titre = titre;
            this.Genre1 = genre1;
            this.MaNote = maNote;
            this.Annee = anee;
            this.ImagePath = imagePath;
        }

        public override string ToString()
        {
            return Titre;
        }
        
    }
}
