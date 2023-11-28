using System;

public class Articolo
{
    public string Codice { get; set; }
    public string Descrizione { get; set; }
    public double PrezzoUnitario { get; set; }

    public Articolo(string codice, string descrizione, double prezzoUnitario)
    {
        Codice = codice;
        Descrizione = descrizione;
        PrezzoUnitario = prezzoUnitario;
    }

    public virtual void Sconta(bool CartaFedelta)
    {
        if (CartaFedelta)
        {
            PrezzoUnitario -= PrezzoUnitario * 0.05;
        }
    }
}

public class ArticoloAlimentare : Articolo
{
    public int AnnoScadenza { get; set; }

    public ArticoloAlimentare(string codice, string descrizione, double prezzoUnitario, int annoScadenza)
        : base(codice, descrizione, prezzoUnitario)
    {
        AnnoScadenza = annoScadenza;
    }

    public override void Sconta(bool CartaFedelta)
    {
        base.Sconta(CartaFedelta);

        DateTime today = DateTime.Today;
        if (AnnoScadenza == today.Year)
        {
            PrezzoUnitario -= PrezzoUnitario * 0.20;
        }
    }
}

